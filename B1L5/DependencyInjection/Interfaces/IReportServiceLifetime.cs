using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Interfaces
{
    public interface IReportServiceLifetime
    {
        /// <summary>
        /// Service Identifier
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// (enum) Service Lifetime
        /// </summary>
        ServiceLifetime Lifetime { get; }
    }
}
