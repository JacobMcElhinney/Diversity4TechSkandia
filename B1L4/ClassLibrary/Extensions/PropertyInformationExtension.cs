using System.Reflection;

namespace ClassLibrary.Extensions
{
    public static class PropertyInformationExtension
    {

        public static void PrintProperties(this object instance)
        {
            int i = 1;

            Console.WriteLine("\n" + instance.GetType() + ": ");

            foreach (PropertyInfo property in instance.GetType().GetProperties())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Property {i}: {property.Name}: {property.GetValue(instance, null)}");
                i++;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintMethods(this object instance)
        {
            int i = 1;

            Console.WriteLine("\n" + instance.GetType() + ": ");

            foreach (MethodInfo method in instance.GetType().GetMethods())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Property {i}: {method.Name}: {method.Name}");
                i++;
            }
        }
    }
}

/*
    Learn more about extension methods: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method?redirectedfrom=MSDN
 */

