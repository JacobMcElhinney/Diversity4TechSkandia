using System.Diagnostics;
using System.Text.RegularExpressions;
using DefensiveProgramming.Guards;
using DefensiveProgramming.Helpers;
using DefensiveProgramming.Models;


namespace DefensiveProgramming
{
    /// <summary>
    /// Contains methods for logging exceptions
    /// </summary>
    public class StreamLogger
    {
        /// <summary>
        /// Writes error message to file.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static async Task LogException(string errorMessage, string logFileName = "Log.txt")
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
                ConsoleHelper.PrintInColor(error.Message, ConsoleHelper.Color.Blue);
            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string logFileName = "Log.txt";
            bool exceptions = false;

            while (!exceptions)
            {
                try
                {
                    Console.Write("To register as a customer, please enter full name:\t");
                    var name = Console.ReadLine();

                    StringGuard.AgainstNullOrEmpty(name, errorMessage: "No input supplied") //You can also use: String.IsNullOrEmpty
                        .AgainstInvalidInput(errorMessage: "Invalid input!")
                        .AgainstExceedingWordCountLimit(wordCountLimit: 2,
                        errorMessage: "Valid format: <firstname lastname>");

                    NameRegistry.RegisterNewName(name.AgainstNullOrEmpty());

                    Customer customer = Customer.GetCustomerByName(name);
                }
                catch (Exception error)
                {
                    ConsoleHelper.PrintInColor(error.Message, ConsoleHelper.Color.Red);
                    ConsoleHelper.PrintInColor("Log +", ConsoleHelper.Color.Green);
                    StreamLogger.LogException(error.Message, logFileName).GetAwaiter().GetResult();
                    exceptions = false;
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

/*
Defensive Programming/Coding:   
Murphy's Law: "Anything that can go wrong will go wrong" anticipating problems and writing code to keep the system 
in a good state when problems occur. Guard Clause pattern: common way to perform validation of inputs while also 
minimizing complexity in the function. It follows the FAIL FAST PRINCIPLE, ensuring that any problems are dealt with immediately.

https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/

 */