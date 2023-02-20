using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public class PrivateGreeter
    {
        private static void PrintMessage(string? message = null) // optional parameter
        {
            Console.WriteLine(message);
        }

        public static void PrintSafeMessge([Optional] string message) // optional parameter
        { 
            if (string.IsNullOrEmpty(message)) 
            {
                PrintMessage("Hello, from private greeter!"); // this private method is accessible in the class it was declared i.e. here
            }
            
        }
    }
}
