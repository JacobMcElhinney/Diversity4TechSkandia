namespace ClassLibrary.Models
{
    public class Adult : Entity
    {
        // private backing field
        private string lastName = null!; // TODO: comment out to illustrate difference between string? and = null!;

        // Property getter and setter implementation
        public string LastName // LastName is an optional property which allows us to 
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Property
        public string FirstName { get; set; }

        // Static Property Part of Class, not instance of class.
        public static int ObjectsCreated { get; private set; } = 0;
        public override bool IsHuman { get; set; }

        // Constructor
        public Adult(string firstName, string lastName) : base(human: true)

        {
            FirstName = firstName;
            LastName = lastName;
            ObjectsCreated++;
        }

        public Adult(string firstName) : this(firstName, lastName: "Unknown")
        {
            FirstName = firstName;
        }

        /* Constructor Chaining: Allows for single implementation for initializing an object 
           if called: will call constructor with matching signature. */
        public Adult() : this(firstName: "Unknown", lastName: "Unknown") { } // using default values

    }
}
