namespace PassingByValueVsByReference
{
    /* When we declare a value type variable, the variable stores a value. 
       A reference type stores the address of the location where the actual 
       value is stored instead of the value itself.
    */
    internal class Program
    {
        /// <summary>
        /// When you pass a value-type variable from one method to another, 
        /// the system creates a separate copy of a variable in another method. 
        /// If value got changed in the one method, it wouldn't affect the variable in another method.
        /// </summary>
        /// <param name="argument"></param>
        static void ChangeValue(int argument)
        {
            argument = 1000;
        }

        static void ChangeValueUsingRef(ref int argument)
        {
            argument = argument + 10;
        }

        static void ChangeValueUsingOut(out int argument)
        {
            //Here we have to assign a value to argument because the value copied from initialValue is discarded,
            //only the reference remains, which lets us reassign the initialValue by reference (pointer)
            //that is why we have to assing argument before its use or we will CS0269 Use of unassigned out parameter 'argument'.
            argument = 0; 
            argument = argument + 10;
        }

        static void Main(string[] args)
        {
            /*
                Use the Debugger to step over (F10) or step into (F1) the method being invoked
                A red value in the Locals (variables defined in the local scope) or 
                Autos (variables used around the current breakpoint) window means the value 
                has changed since the last evaluation.
                
                Notice how the value is copied when we call ChangeValue(Int32)
                And the "ByRef" notation in both ChangeValueUsingRef(int32 ByRef) ChangeValueUsingOut(int32 ByRef)

                Unlike value types, a reference type doesn't store its value directly. 
                Instead, it stores the address where the value is being stored. 
                In other words, a reference type contains a pointer to another memory location that holds the data.
            */

            int initialValue = 100;
                Console.WriteLine("After declaration and assignment: " + initialValue);

                ChangeValue(initialValue); // value type: a copy is passed
                Console.WriteLine("After ChangeValue was invoked: " + initialValue);
                
                ChangeValueUsingRef(ref initialValue); // a reference to the object is passed by value, along with a copy. 
                Console.WriteLine("After ChangeValueUsingRef: " + initialValue);

                ChangeValueUsingOut(out initialValue); // copy is discarded but reference is passed
                Console.WriteLine("After ChangeValueUsingOut: " + initialValue);


        }
    }
}