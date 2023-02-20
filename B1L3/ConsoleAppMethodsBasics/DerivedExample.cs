using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethodsBasics
{
    internal class DerivedExample : BaseExample
    {

        public override decimal NumberOfFingersOnMyHand()
        {
            int fingersOnMyHand = (int)base.NumberOfFingersOnMyHand();
            return fingersOnMyHand;
        }
    }
}
