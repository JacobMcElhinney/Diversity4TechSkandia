using DefensiveProgramming.Helpers;

namespace DefensiveProgramming.Models
{
    internal partial class Customer
    {
        public Customer(string name)
        {
            this.Id = new Guid();
            this.Name = name;
        }
        public static Customer GetCustomerByName(string customerName)
        {

            //validate so no garbage is getting through
            if (String.IsNullOrEmpty(customerName))
                throw new ArgumentException(nameof(GetCustomerByName) + ": invalid argument");
            try
            {
                //Get customer name from data source
                var name = NameRegistry.GetRegisteredName(customerName);

                //Make sure the customer is not null before the use of its members in the compare method.  
                Customer customer = new Customer(name);

                if (customer != null && String.Compare(customer.Name, customerName) == 0)
                    return customer;
                else
                    throw new ArgumentException(nameof(GetCustomerByName));
            }
            catch(Exception error)
            {
                ConsoleHelper.PrintInColor(error.Message, ConsoleHelper.Color.Red);
                throw new Exception(message: "Failed to get customer");
            }


        }
    }
}
