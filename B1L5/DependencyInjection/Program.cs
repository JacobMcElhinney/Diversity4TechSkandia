using DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
{

    internal class Program
    {

        // DI is managed by adding services and configuring them in an IServiceCollection. The IHost interface exposes the IServiceProvider instance, which acts as a container of all the registered services.
        static void Main(string[] args)
        {
            // Add services to the DI container
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IExampleTransientService, ExampleTransientService>();
                services.AddScoped<IExampleScopedService, ExampleScopedService>();
                services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
                services.AddTransient<ServiceLifetimeReporter>();

            }).Build();

            ExemplifyServiceLifetime(host.Services, "Lifetime 1");
            ExemplifyServiceLifetime(host.Services, "Lifetime 2");

            host.RunAsync().GetAwaiter().GetResult(); 

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostProvider"></param>
        /// <param name="lifetime"></param>
        static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
            logger.ReportServiceLifetimeDetails(
                $"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeLogger>()");

            Console.WriteLine("...");

            logger = provider.GetRequiredService<ServiceLifetimeReporter>();
            logger.ReportServiceLifetimeDetails(
                $"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeLogger>()");

            Console.WriteLine();
        }
    }
}