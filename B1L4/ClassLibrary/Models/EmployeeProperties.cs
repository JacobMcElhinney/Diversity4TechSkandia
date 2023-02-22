using System.Runtime.InteropServices;

namespace ClassLibrary.Models
{
    // Note how there are references to EmployeeMethods.cs
    public partial class Employee : Adult
    {
        /*
            Imagine that you had loads of properties with validation logic etc...
            partial classes can help your code more readable and easier to maintain.
         */

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (!value.Equals(0) && value < 15)
                {
                    // Validate property value to ensure data integrity
                    throw new ArgumentOutOfRangeException("Must be of working age");
                }
                age = value;
            }
        }

        public Employee(string fistName, string lastName, [Optional] int age) : base(fistName, lastName)
        {
            Age = age;
        }
    }
}
