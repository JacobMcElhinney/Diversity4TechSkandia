namespace ConsoleAppExplained // namespace declaration: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
{
    internal class Program // Access Modifiers: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    {
        // static method that returns void (nothing) and takes and array of strings as it's argument
        static void Main(string[] args) // Application entrypoint: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line
        {
            System.Console.WriteLine("Hello, World!"); // Output string literal to console (Strings are reference types)

            System.Console.WriteLine("Type a response: ");

            /* variable type (blue) and identifyer (light blue). Assignment operator (=). 
               Invoking the ReadLine method - part of the static Console class (part of system namespace) - using the method invocation operator ()
               semicolon */
            string userInput = System.Console.ReadLine(); // Stores reference/pointer to string supplied by user (Input operation) in variable
            System.Console.WriteLine("world says: " + userInput);
        }
    }
}