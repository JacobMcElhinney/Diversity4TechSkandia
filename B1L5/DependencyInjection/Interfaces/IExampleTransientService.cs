using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Interfaces
{
    /// <summary>
    /// Subinterface of IReportServiceLifetime
    /// </summary>
    public interface IExampleTransientService : IReportServiceLifetime
    {
        /// <summary>
        /// Implements <Interface.Property> with Microsoft.Extensions.DependencyInjection.ServiceLiftetime.<enum>
        /// </summary>
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
