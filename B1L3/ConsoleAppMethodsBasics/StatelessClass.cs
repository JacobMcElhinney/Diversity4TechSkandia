using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethodsBasics
{
    /// <summary>
    /// A static class for introducing the basic method terminology
    /// </summary>
    public static class StatelessClass
    {
        /*
            METHOD SIGNATURE COMPONENTS:
            ---------------------------------
            public: access modifier
            static: static method
            void: return type (returns nothing)
            ExampleMethod: method name
            (string message): parameter list

         */

        // Method Declaration
        public static void ExampleMethod(string message)
        {
            // Method implementation goes here...
            // Method statement
            Console.WriteLine(message);
        }

        // Method Declaration is identical, but method signature is unique since the parameter list is different.
        public static void ExampleMethod(string message, [Optional] string secondMessage) // Overloaded version of ExampleMethod
        {
            // Two Method Statements (the implementation)
            Console.WriteLine(message);
            if (secondMessage != null) Console.WriteLine(secondMessage); // null-check prevents runtime error
        }


    }
}

/*
    
        A return type of a method is not part of the signature of the method for 
        the purposes of method overloading. However, it is part of the signature 
        of the method when determining the compatibility between a delegate and the 
        method that it points to.
 
 
 */