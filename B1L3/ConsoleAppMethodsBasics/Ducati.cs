using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethodsBasics
{
    internal class Ducati : Motorcycle // Derived/inherits from MotorCycle (base class)
    {

        // Notice the reference to the Motorcycle class!
        public override double GetTopSpeed()
        {
            return 108.4;
        }
        // Access to FuelUpBike outside context of class declaration, but no access to AddGas.
        internal void FuelUpBike(int gallons)
        {
            // AddGas is protected, meaning only derived classes like Ducati can call it internally
            AddGas(gallons); // Member of Motorcycle class
        }

        public override int Drive(int miles, int speed)
        {
            return (int)Math.Round(((double)miles) / speed, 0);
        }



    }
}
