using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensiveProgrammingSolid.Interfaces;

namespace DefensiveProgrammingSolid.Utilities
{
    public class ConsoleHelper : IConsoleHelper
    {
        public enum Color 
        {
            Red,
            Green, 
            Blue,
        }
        
             
        public void PrintInColor(string message, Color? color = null)
        {
        }

        public void PrintInColor(string message, IConsoleHelper.Color? color = null)
        {

            switch (color)
            {
                case IConsoleHelper.Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    break;
                case IConsoleHelper.Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    break;
                case IConsoleHelper.Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(message);
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
            Console.WriteLine(message);
            if (!Console.ForegroundColor.Equals(ConsoleColor.White)) Console.ForegroundColor = ConsoleColor.White;
        }
    }   
}
