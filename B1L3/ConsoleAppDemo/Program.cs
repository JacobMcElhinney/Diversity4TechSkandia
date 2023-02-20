namespace ConsoleAppDemo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /*PrivateGreeter.PrintMessage(); */// Same Assembly - private Method
            PrivateGreeter.PrintSafeMessge(); // 
            InternalGreeter.PrintMessage("hello"); // Same Assembly - internal Method
            Logger.LogMessage(); // same Assembly - public Class public Method
            PublicGreeter.PrintMessage();
        }
    }
}