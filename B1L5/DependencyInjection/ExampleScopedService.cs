using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    // Classes are seled to indicate they are specialised classes not to be extended. 
    // A sealed class cannot be inherited by any class but can be instantiated.
    internal sealed class ExampleScopedService : IExampleScopedService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
