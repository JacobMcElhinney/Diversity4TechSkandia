using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public static class PublicGreeter
    {
        public static void PrintMessage(string message = "Hello, from public greeter!") // default value
        {
            Console.WriteLine(message);
        }
    }
}
