using ClassLibrary.Extensions;

namespace Generics
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int age = 34;

            // BCL Generic Class
            var b = new KeyValuePair<string, int>(key: "age", value: age);

            // Simple example
            var a = new CustomGenericKeyValuePair<int>(key: nameof(age), value: age);
            a.PrintProperties();
            b.PrintProperties();

            var c = new CustomGenericKeyValuePair<decimal>(key: "accountBalance", value: 13.50m);
            c.PrintProperties();


            /*string genericsAreTypeSafe = c.ExtractStringFromKeyValuePair(a);*/ // Argument 'number' cannot convert from TypeA to TypeB
            string keyValuePair = c.ExtractStringFromKeyValuePair(c);
            Console.WriteLine("\n" + keyValuePair);

            StaticGenericClass<string>.MyProperty = "A string";
            Console.WriteLine(StaticGenericClass<string>.ReturnMyProperty());

            StaticGenericClass<int>.MyProperty = 12345;
            Console.WriteLine(StaticGenericClass<int>.ReturnMyProperty());

        }
    }
}

/*
  Learn more at: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
 */