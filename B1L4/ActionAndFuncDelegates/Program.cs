namespace ActionAndFuncDelegates
{
    internal class Program
    {
        // A Func delegate can have 0-16 input parameters. The return type is always listed last
        /*public delegate TResult Func<in T, out TResult>(T arg);*/ // in keyword indicates value will not be modified, compiles differently (performance aspect)
        /*public delegate T Func<T1,T>(T1 arg);*/ // identical signature 

        // Notice how the below Func and Action type Delegates can be used withoud declaring them as class members unlike regular Delegate
        public delegate TNumber CustomDelegate<TNumber>(); // Use descriptive names for Delegate<T>

        public delegate void Action<T>(T message);

        static int Sum(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {

            // Func delegate with two input parameters and one output parameter

            Func<int, int, int> add = Sum;
            /* Func<int, int, int> add = new Func<int, int, int>(Sum);*/ // Alternative Syntax

            int result = add(10, 10); //alternative syntax: add.Invoke(10, 10);
            Console.WriteLine("Sum: " + result);

            // Declare Func Delegate with No input parameters, returns System.Int32
            Func<int> rollDice;

            // Assing anonymous method to Func Delegate using delegate keyword
            rollDice = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 7);
            };
       
            // Using lambda expression to assingn Delegate
            CustomDelegate<int> diceRoll2 = () =>
            {
                Random random = new Random();
                return random.Next(1, 7);
            };

            // Invoke Func Delegate
            var firstRoll = rollDice();

            // Invoke Custom Delegate
            var secondRoll = diceRoll2.Invoke();

            Console.WriteLine("First roll: {0}\nSecond roll: {1}", firstRoll, secondRoll);


            /* Notice how we had to create a Delegate property with a matching signature when we used
               our custom delegate but not when we used the System.Func delegate */

            // Action Delegate
            Action<int,int> multiply = (int operandA, int operandB ) => Console.WriteLine("Product: " + (operandA * operandB));
            multiply(10, 10);


            Action<string> printMessage = (string message) => Console.WriteLine(message);

            printMessage("Hello, world!");

            // Just to demonstrate alternative syntax:
            Action<string> printLastMessage = new Action<string>(printMessage);
            printLastMessage.Invoke("Don't worry if you cant remember the syntax! Just reference the docs when you need it!");
        }
    }
}

/*

    Composition over inheritance (or composite reuse principle) in object-oriented programming 
    (OOP) is the principle that classes should achieve polymorphic behavior and code reuse by 
    their composition (by containing instances of other classes that implement the desired 
    functionality) rather than inheritance from a base or parent class.

    The delegation pattern is an object-oriented design pattern that 
    allows object composition to achieve the same code reuse as inheritance. In delegation, 
    an object handles a request by delegating to a second object (the delegate). 
    The delegate is a helper object, but with the original context.

    */