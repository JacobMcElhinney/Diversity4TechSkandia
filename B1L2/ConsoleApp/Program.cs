namespace ConsoleApp
{
    internal class Program
    {
        // stateless returns nothing MethodName(method signature) 
        static void Main(string[] args) // Method declaration
        {

            // instantiate a class (creating an object - an instance of a class)
            Random dice = new Random();
            var diceB = new Random();
            Random diceC = new();

            int roll = 0;
            Console.WriteLine(roll);  // static method (stateless)

            roll = dice.Next(); // instance method (stateful) +3 overloads

            roll = dice.Next(maxValue: 10); // second overload with named arguments <argument/inputParameterName:>
            Console.WriteLine(value: roll);

            roll = dice.Next(minValue: 1, maxValue: 7); // third overload
            Console.WriteLine(value: roll); // named argument + local variable

            ArrayHelper.ShowAlternativeSyntax();
            ArrayHelper.PrintElementsInArray();

            // TODO: Show Task List feature & F10 Debugging + BP

        }
    }
}
