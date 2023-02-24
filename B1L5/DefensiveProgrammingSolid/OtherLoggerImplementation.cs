using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensiveProgrammingSolid.Interfaces;

namespace DefensiveProgrammingSolid
{
    internal class OtherLoggerImplementation : ILogger
    {
        private readonly IConsoleHelper _consoleHelper;

        public OtherLoggerImplementation(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }
        public async Task LogException(string errorMessage, string logFileName = "Log.txt")
        {
            try
            {
                var fileName = logFileName;
                string path = AppDomain.CurrentDomain.BaseDirectory;

                using (StreamWriter file = new(fileName, append: true))
                {
                    string timeStamp = DateTime.Now.ToString();
                    _consoleHelper.PrintInColor(nameof(OtherLoggerImplementation), IConsoleHelper.Color.Green);
                    ProcessStartInfo startInfo = new() { Arguments = path, FileName = "explorer.exe" };
                    Process.Start(startInfo);
                    await file.WriteLineAsync($"{timeStamp}:\t{errorMessage}");
                }
            }
            catch (Exception error)
            {
                _consoleHelper.PrintInColor(error.Message, color: IConsoleHelper.Color.Red);
            }
        }
    }
}
