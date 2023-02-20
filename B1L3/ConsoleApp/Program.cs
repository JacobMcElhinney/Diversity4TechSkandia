using ConsoleAppDemo;

namespace ConsoleApp
{
    
    internal class Program
    {
        //[access modifier] [stateless] [return type] [method name] ([parameters])
        public static int ReturnNumber()
        { 
            Random numberGenerator = new Random();

            // return keyword: returns a single value, must match return type.
            return numberGenerator.Next();
        }

        // Overloaded method - notice how only the parameter list needs to differ for method signature to be unique (not ambiguous)
        public static int ReturnNumber(int lowerBound, int exlcusiveUpperBound)
        {
            Random numberGenerator = new Random();
            return numberGenerator.Next(lowerBound, exlcusiveUpperBound); ;
        }

        public static (int,int) ReturnCompoundedData(int arg1, int arg2)
        {
            return (arg1,arg2);
        }

        // Method using the private protected access modifyer on nested class (declaration is nested inside the Program class)
        private protected class PrivateNestedClass
        {
            protected void ProtectedMessage()
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("hello from private nested class");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public void PublicMessage()
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("hello from private nested class");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*InternalGreeter.PrintMessage();*/ // Part of a different Assembly - Internal
            PublicGreeter.PrintMessage(); // Part of a different Assembly - Public
            ConsoleAppDemo.Logger.LogMessage(); // Test: remove "ConsoleAppDemo" and add class Logger.cs

            /*PrivateNestedClass.PrintMessage();*/ // same assemby - private
            DerivedClass derivedClass = new DerivedClass();
            derivedClass.HelloFromDerivedClass();

            // Return keyword
            var number1 = ReturnNumber();
            var number2 = ReturnNumber(lowerBound:1, exlcusiveUpperBound: 7);
            var tuple = ReturnCompoundedData(number1, number2); // value tuple with two components
        }
    }
}

/*
------------------------------Assemblies & Access Modifiers----------------------------------------
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

Assemblies provide the common language runtime with the 
information it needs to be aware of type implementations. 
To the runtime, a type doesn't exist outside the context of an assembly.
All types and type members have an accessibility level (see access modifiers below). 
The accessibility level controls whether they can be used from other 
code in your assembly or other assemblies. An assembly is a .dll or 
.exe created by compiling one or more .cs files in a single compilation. 

ACCESS MODIFIERS: 
public:             The type or member can be accessed by any other code in the same assembly or 
                    another assembly that references it. The accessibility level of public members 
                    of a type is controlled by the accessibility level of the type itself.
private:            The type or member can be accessed ONLY by code IN the same class or struct.
                    See "private protected" for access by derived types.
protected:          The type or member can be accessed only by code IN THE SAME CLASS, or IN a 
                    class that is derived from that class.
internal:           The type or member can be accessed by any code in the same assembly, 
                    but not from another assembly. In other words, internal types or members can 
                    be accessed from code that is part of the same compilation.
protected internal: The type or member can be accessed by any code in the assembly in which it's declared, 
                    or from WITHIN a derived class in another assembly.
private protected:  The type or member can be accessed by types derived from the class that are declared 
                    within its containing assembly.

 */