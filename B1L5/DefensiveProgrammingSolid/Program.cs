using DefensiveProgrammingSolid.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DefensiveProgrammingSolid.Utilities;

namespace DefensiveProgrammingSolid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add services to the DI container
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IConsoleHelper, ConsoleHelper>();
                services.AddTransient<ILogger, OtherLoggerImplementation>();

            }).Build();



            LogSomething(host.Services);

            host.RunAsync().GetAwaiter().GetResult();
        }

        static void LogSomething(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var logger = provider.GetRequiredService<ILogger>();
            var consoleHelper = provider.GetRequiredService<IConsoleHelper>();

            logger.LogException(errorMessage: "My exception", logFileName: "SolidLog.txt");

            Console.WriteLine("...");

            Console.WriteLine();
        }
    }
}