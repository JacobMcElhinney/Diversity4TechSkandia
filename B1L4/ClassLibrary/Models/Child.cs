namespace ClassLibrary.Models
{
    public class Child : Adult
    {
        // nullable properties allow for calling the constructor without passing any arguments
        public string? Mum { get; set; }
        public string? Dad { get; set; }

        // Will pass on firstName and lastName parameter to base constructor (constructor chaining)
        public Child(string mumName, string dadName, string firstName, string lastName) : base(firstName, lastName)
        {
            Mum = mumName;
            Dad = dadName;
        }

        // won't throw error since internal members are optional and derived members will be initialised by calling base constructor
        public Child() { }





    }
}
