using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethods.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public DateTime DateOfBirth { get; set; } 

        public Person(string firstName, int year, int month, int day)
        {
            FirstName = firstName;
            DateOfBirth = new DateTime(year, month, day);
        }

        public Person() : this(firstName: "Jacob", year: 1989, month: 10,day: 12) { } 
    }
}

/* 
 the second constructor is called by the instance as it matches the signature of the method
 that is invoced in Program.cs. The ":" (colon) lets us use a constructor/implementation which mathes the parameter list.
 The "this" keyword referes to the instance invoking the method. The Person instance will call Person() which in turn will
 invoke Person(firstname,year,month,day) and use the values supplied in Person(). If we pass different literals/constants 
 as arguments when calling the constructor, e.g: Person bob = new Person("Bob", 1961, 02, 13) there would be no reference to
 Person() as the call/invocation no longer matches the signature of Person().
 
 The most common form of method invocation used positional arguments; 
 it supplies arguments in the same order as method parameters.

 Note the use of "named arguments" for increased readability, making the connection to the other constructor more obvious.
 
 */