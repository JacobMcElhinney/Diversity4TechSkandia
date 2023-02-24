using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensiveProgrammingSolid.Interfaces;

namespace DefensiveProgrammingSolid
{
    /// <summary>
    /// Contains methods for logging exceptions
    /// </summary>
    public class StreamLogger : ILogger
    {
        private readonly IConsoleHelper _consoleHelper;

        public StreamLogger(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        /// <summary>
        /// Writes error message to file.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public async Task LogException(string errorMessage, string logFileName = "Log.txt")
        {
            try
            {
                var fileName = logFileName;
                string path = AppDomain.CurrentDomain.BaseDirectory;

                using (StreamWriter file = new(fileName, append: true))
                {
                    string timeStamp = DateTime.Now.ToString();
                    Console.WriteLine("{0}: Path to Log.txt: {1} ", timeStamp, path);
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
