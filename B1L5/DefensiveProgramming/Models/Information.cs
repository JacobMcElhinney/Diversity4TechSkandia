using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveProgramming.Models
{
    internal abstract class Information
    {
        // Imagine we wanted to break Name into two properties: FirstName and LastName... that's right tight coupling...
        public abstract string Name { get; set; }
        public abstract string Address { get; set; }
        public  abstract string City { get; set; }
        public abstract string Region { get; set; }
        public  abstract string PostalCode { get; set; }
        public abstract string Country { get; set; }
        public abstract string Phone { get; set; }

    }
}
