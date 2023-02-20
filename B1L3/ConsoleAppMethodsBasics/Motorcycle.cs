using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethodsBasics
{
 
    /// <summary>
    /// Abstract classes can't be instantiated but can serve as a base for other classes that inherit from it.
    /// </summary>
    internal abstract class Motorcycle
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = 1; }
        }


        // since abstract classes cant be instantiated you cant call this method, but any class that inherits the method can.
        public void StartEngine()  
        {
            Console.WriteLine("Wroom! Wroom! Engine was started...");
        }

        // Since this method is protected it can only be called inside the derived class (same file).
        protected void AddGas(int gallons) 
        {
            Console.WriteLine("Fuled up and good to go!");
        }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes can override the base class implementation.
        public virtual int Drive(TimeSpan time, int speed) { /* Method statements here */ return 0; }

        // Derived classes must implement this. (abstract keyword, similar to interfaces, can be thought of as a contract)
        // Abstract classes cannot have a body. Implementation is provided in the derived class
        public abstract double GetTopSpeed();
    
    }
}

