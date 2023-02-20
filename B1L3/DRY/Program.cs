namespace DRY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* DRY code is a software principle that stands for Don't Repeat Yourself (DRY), where the goal is to reduce the repetition of code.
               The DRY principle is balanced out by the "Rule of Three" or WET (Write Everything Twice) that keeps you from writing overly complicated
               code as a result of overzealous adherence to the DRY principle 
                
               Think about what we've learned so far about declaration, iteration statements and methods and see how you can refactor this code
            */


            string line1 = "Happy birthday to you";
            string line2 = "Happy birthday to you";
            string line3 = "Happy birthday, Dear Jacob";
            string line4 = "Happy birthday to you";
            string repeat = "encore! encore!";

            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.WriteLine(line4);

            Console.WriteLine(repeat);

            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.WriteLine(line4);

        }
    }
}