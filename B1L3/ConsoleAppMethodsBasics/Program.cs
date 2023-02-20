namespace ConsoleAppMethodsBasics
{
    internal class Program
    {
  
    
        static void Main(string[] args)
        {

            // Abstrac classes cannot be instantiated (can not be used to create a new object)
            //Motorcycle motorcycle = new Motorcycle();

            // Instead we use them to create derived classes that inherit from them
            Ducati ducati = new Ducati();
            ducati.StartEngine(); // 

            // If the method is declared static, we would be able to call it like this however.
            // But then it is no longer an instance method and ducati won't be able to call it.
            //Motorcycle.StartEngine();

            ducati.StartEngine();
            /*ducati.AddGas(15);*/ // CS0122 cant call protected method from here...
           
            ducati.FuelUpBike(gallons: 15); // Instead we call the protected method from within the derived class
            
            // Invoking Drive using two named arguments
            ducati.Drive(miles: 5,speed: 20);
            double speed = ducati.GetTopSpeed();
            Console.WriteLine("My top speed is {0}", speed);

            // Invoking drive using one positional argument followed by one named arguments (order matters if all are not named)
            var travelTime = ducati.Drive(60, speed: 170);
            Console.WriteLine("Travel time: approx. {0} hours", travelTime);

        }
    }
}

/*
 --------------------------------ABSTRACT, VIRTUAL, OVERRIDE-------------------------------------------------------------------
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override

 */