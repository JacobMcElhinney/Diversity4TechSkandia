namespace ClassLibrary.Models
{
    // Note the reference:
    public partial class Employee
    {
        /*
            learn more about partial classes here: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods 
        */

        public void WakeUp()
        {
            Console.WriteLine("A new day full of possibilities!");
        }
        public void GetDressed()
        {
            Console.WriteLine("Warm and comfy!");
        }

        public void GoToWork()
        {
            Console.WriteLine("Right on time!");
        }

        public void DoWork()
        {
            Console.WriteLine("Feels good to get stuff done!");
        }

        public void GoToLunch()
        {
            Console.WriteLine("That was yummy!");
        }

        public void GoHome()
        {
            Console.WriteLine("Bye everyone, thanks for today!");
        }

    }
}
