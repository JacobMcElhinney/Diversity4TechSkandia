using System.Runtime.InteropServices;

namespace ConsoleApp
{
    /// <summary>
    /// A Static class that facilitates working with string arrays.
    /// </summary>
    /// <param name="array"></param>
    internal static class ArrayHelper
    {
        // Declare and initialise string array using alternate syntax


        public static void PrintElementsInArray([Optional] string[] array) //string[]? array = null
        {
            if (array == null)
            {
                Console.WriteLine("No elements in array...");
            }
            else if (array.Length > 0)
            {
                // Iterate over the array and write the value of each elements to the console
                Console.WriteLine("\n\nElements in array: ");
                foreach (var i in array) { Console.Write(i + ", "); }
            }

        }

        public static void ShowAlternativeSyntax()
        {
            Console.WriteLine(
            "\n\n" +
            "// Declare and initialise string array using alternate syntax\n" +
            "string[] array1 = new string[2]; // creates array of length 2, default values (\"\")\n" +
            "string[] array2 = new string[] { \"A\", \"B\" }; // creates populated array of length 2\n" +
            "string[] array3 = { \"A\", \"B\" }; // creates populated array of length 2\n" +
            "string[] array4 = new[] { \"A\", \"B\" }; // created populated array of length 2"
            );

            Console.ReadKey();
        }
    }
}
