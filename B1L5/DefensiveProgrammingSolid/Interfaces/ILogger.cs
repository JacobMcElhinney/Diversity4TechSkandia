using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DefensiveProgrammingSolid.Interfaces
{
    public interface ILogger
    {
        
        public Task LogException(string errorMessage, string logFileName = "Log.txt");
    }
}
