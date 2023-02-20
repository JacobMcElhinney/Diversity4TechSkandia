using ConsoleAppMethods.Extensions;
using ConsoleAppMethods.Helpers;
using ConsoleAppMethods.Models;

namespace ConsoleAppMethods
{
    internal class Program
    {
        /*
            In C#, every executed instruction is performed in the context of a method. 
            The Main method is the entry point for every C# application and it's called 
            by the common language runtime (CLR) when the program is started.
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DateTimeHelper statefulHelperMethodInstance = new DateTimeHelper();
            string currentDate = statefulHelperMethodInstance.GetCurrentDateString();
            Console.WriteLine("current date: " + currentDate);
            Person jacob = new Person();
            jacob.DaysUntilNextBirthday(); // Extension method not part of the Person class - extending it's functionality.
            
        }
    }
}


/*
 
 */
