using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppMethods.Models;

namespace ConsoleAppMethods.Extensions
{
    /// <summary>
    /// Stateless Extension Method. Extends functionality to all DateTime Objects
    /// </summary>
    public static class PersonExtension
    {
        // The this keyword refers to the current instance of the class and 
        // is also used as a modifier of the first parameter of an extension method.
        public static void DaysUntilNextBirthday(this Person person)
        {
            var birthday = person.DateOfBirth;
            DateTime today = DateTime.Today;
            
            DateTime next = birthday.AddYears(today.Year - birthday.Year);
            if (next < today) { next = next.AddYears(1); }
            int numDays = (next - today).Days;

            Console.WriteLine($"{person.FirstName}, your next birthday is in {numDays} days.");
        }
    }
}
