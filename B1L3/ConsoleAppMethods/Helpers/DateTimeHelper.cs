using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMethods.Helpers
{
    /// <summary>
    /// Stateful Helper Method for working with dates
    /// </summary>
    public class DateTimeHelper
    {
        private readonly DateTime _date;

        /// <summary>
        /// Constructor: initialises class member variables
        /// </summary>
        public DateTimeHelper()
        {
            // The constructor initialises the private member field (variable stored on heap)
            _date = DateTime.Now;
        }

        /// <summary>
        /// Converts the value of a DateTime object into a short date string representation
        /// </summary>
        /// <returns>string reprentation of short date</returns>
        public string GetCurrentDateString()
        {
            // method chaining: as long as the previous method returns a value, we can chain calls/invocation
            return _date.ToShortDateString().ToString();
        }
    }
}
