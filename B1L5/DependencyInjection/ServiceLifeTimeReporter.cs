﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    /// <summary>
    /// For demonstration purposes, helps visualise service lifetime
    /// </summary>
    internal sealed class ServiceLifetimeReporter
    {
        private readonly IExampleTransientService _transientService;
        private readonly IExampleScopedService _scopedService;
        private readonly IExampleSingletonService _singletonService;

        public ServiceLifetimeReporter(
            IExampleTransientService transientService,
            IExampleScopedService scopedService,
            IExampleSingletonService singletonService) =>
            (_transientService, _scopedService, _singletonService) =
                (transientService, scopedService, singletonService);

        public void ReportServiceLifetimeDetails(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            LogService(_transientService, "Always different");
            LogService(_scopedService, "Changes only with lifetime");
            LogService(_singletonService, "Always the same");
        }

        private static void LogService<T>(T service, string message)
            where T : IReportServiceLifetime =>
            Console.WriteLine(
                $"    {typeof(T).Name}: {service.Id} ({message})");
    }
}
