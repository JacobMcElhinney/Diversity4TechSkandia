using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethods.Utilities
{
    /// <summary>
    /// Stateless Utility Method: Outputs text string in color specified. Options: "red", "green", "blue".
    /// </summary>
    public static class ConsoleColorUtility
    {
        /* 
            Utility classes are static/stateless with only static member methods 
            This method prints a message in the colour supplied by the user or in white if
            no color argument was supplied.
        */
        public static void PrintInColor(string message, string? color = null) // [Optional] parameters must appear last.
        {
            if (color != null)
            {
                string formattedColor = color.ToLower().Trim();

                switch (formattedColor)
                {
                    case "red":
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine(message); 
                        break;
                    case "green":
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine(message); 
                        break;
                    case "blue":
                        Console.ForegroundColor= ConsoleColor.Blue;
                        Console.WriteLine(message);
                        break;
                default:
                        Console.WriteLine(message);
                        break;
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
