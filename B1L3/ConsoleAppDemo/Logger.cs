using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public class Logger
    {
        public static void LogMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logger: In a large application, made up of many projects" +
                ", one might easily call the wrong implementation of Logger without proper" +
                "use of access modifiers");
            Console.ForegroundColor = ConsoleColor.White;
        }

        
    }
}
