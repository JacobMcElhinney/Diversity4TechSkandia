using System.Collections.Generic;

namespace Delegate
{
    internal class Program
    {
        /* Asynchronous callback using delegates: assigning or passing a method and later invoking it */
        

        // declaring a delegate to encapsulate a method with matching signature and return type
        // [access modifier] delegate [return type] [delegate name]([parameters])
        public delegate void MyFirstDelegate(string text);
        public delegate int MySecondDelegate(int operandA, int operandB);

        // Declare a method matching our delegate: 
        public static void MyMethod(string message)
        {
            Console.WriteLine("hello from MyMethod: " + message);

        }

        // Pass a delegate as an argument (Delegate is a reference type)
        public static void SomeOtherMethod(MyFirstDelegate myDelegate, string message) 
        {
            myDelegate(message);
        }

        public static void MyThirdMethod(string text)
        { 
            Console.WriteLine("Hello from third method: {0}", text); 
        }

        static void Main(string[] args)
        {
            MyMethod("Invoking my method directly");

            // Instantiate the delegate (wraps a named method in the delegate object)
            MyFirstDelegate handler = MyMethod; // return type and parameter list must match delegate
            var alternativeSyntax = new MyFirstDelegate(MyMethod); // alternative syntax

            // Invoke the delegate...
            handler(" Invoking delegate: delegating method call and passing parameters to MyMethod");

            // ...Or pass it as an argument
            SomeOtherMethod(handler, "Hello, from delegate inside SomeOtherMethod");

            // Instatiating the delegate with a lambda expression
            string message = "Invoking the delegate which in turn invokes ";
            handler = (message) => { Console.WriteLine(message); };
            handler(message);

            // Assingning a lambda expression to a delegate object
            MySecondDelegate performAddition = (int firstNumber, int secondNumber) => { return firstNumber + secondNumber;  };

            // Invoking lambda expression stored in delegate
            var sum = performAddition(5,9);


            /* 
                Lets explore the Multicast Delegate: points to multiple methods 
                (add method to invocation list using + or += operator)
                Remember the MotorCycle class? The Drive method could include a multicast delegate parameter
                and allow subsidiary calls to invoke methods like Clutch(bool engaged), Shift(int gear), 
                Throttle(int percentage) inside the Drive method.
            */

            MyFirstDelegate del1, del2, del3;
            del1 = (string message) => { Console.WriteLine("Hello from the inline lambda expression: " + message); };
            del2 = MyMethod;
            del3 = MyThirdMethod;

            // using += to wrap additional methods/add to invocation list
            MyFirstDelegate multicastDelegate = del1;
            multicastDelegate += del2;
            multicastDelegate += del3;

            // Alternative syntax using + operator
            var multicastDeligate = del1 + del2 + del3;

            var invocationList = multicastDelegate.GetInvocationList();
            Console.WriteLine($"\nInvoke every method ({invocationList.Length}) in invocation list ({invocationList})");
            multicastDelegate("\"the argument\"");

            // If a delegate returns a value, then the last assigned target method's value will be return when a multicast delegate called
            MySecondDelegate multicastWithReturn = performAddition + new MySecondDelegate((int op1, int op2)=>{ return (op1 + op2) * 5; });
            var invocationlist2 = multicastWithReturn.GetInvocationList();
            var resultReturned = multicastWithReturn(operandA: 1,operandB: 1);
            Console.WriteLine("\nCall delegated to {0} methods. \nResult returned from second delegate: {1}", invocationlist2.Length, resultReturned );

            // You can also use the delegate keyword to declare anonymous methods
            MyFirstDelegate anonymousMethod = delegate (string message) 
            { 
                Console.WriteLine("Anonymous method says: " + message + 
                    " e.g:\n" + invocationList[0] + "\tresult returned: " + resultReturned); 
            };

            //alternative invocation syntax: anonymousMethod.Invoke("Hello, world!");
            anonymousMethod("I can access variables in the scope where I am declared");  

            // The anonomous methods signature matches the second delegate we declared: MySecondDelegate and is implicitly casted.
            MySecondDelegate anonymousMethodWithReturn = delegate (int num1, int num2) { return (num1 + num2) + sum; };
            Console.WriteLine("\nAnonymous method with return: " + anonymousMethodWithReturn(1, 1) + ". Can you see why the result is perhaps different than expected?");
        }
    }
}