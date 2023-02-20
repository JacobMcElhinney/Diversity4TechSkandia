using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    internal static class InternalGreeter
    {
        internal static void PrintMessage(string message = "Hello, from internal logger!") // optional parameter with default value
        { 
            Console.WriteLine(message);
        }


    }
}
