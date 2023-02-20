using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppDemo;

namespace ConsoleApp
{
    /*
       Since "PrivateNestedClass" is declared as a nested class in Program.cs (a member of Program.cs) 
       we cannot directly inherit from/derive from PrivateNested class, instead our class is derived from Program
    */
    internal class DerivedClass : Program
    {
        public void HelloFromDerivedClass()
        {
           
            var privateNestedClassDefinedInProgram = new PrivateNestedClass();
            /*privateNestedClassDefinedInProgram.ProtectedMessage();*/ // CS0122, inaccessible due to protection level - this class is not derived from PrivateNestedClass

            privateNestedClassDefinedInProgram.PublicMessage();
        }
    }
}
