using ClassLibrary.Extensions;
using ClassLibrary.Models;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare an instance of enity and assign it with 
            Entity chicken = new Child(); // Normally we would not want to expose the Entity Class... just for illustration purposes (language feature)
            chicken.IsHuman = false;

            Console.WriteLine($"Notice how we can declare an Entity (base class) but use a derived class to instantiate it: ");
            chicken.PrintProperties(); // Extension method from ClassLibrary (notice using directive and project reference/dependency )

            // Delare and populate List of type Person (Generic List<T> contains elements of <Type>. It grows automatically to accomodate any additional elements)
            List<Adult> persons = new List<Adult>
            { 
                new Adult("Bob", "Johnsson"), // Since we use a generic list we can reference each instance by its index (no other identifier declared)
                new("Jane", "Johnsson"), // Since "List<Person> persons" is declared we don't have to specify "Person" explicitly
                new() // since we use constructor chaining with default values, we don't even have to pass any arguments.
            };

            Child child = new Child(firstName: "Junior", lastName: "Johnsson", mumName: "Jane", dadName: "Blob");
            persons.Add(child);

            Console.WriteLine("\nperson number 4: " + persons[3].FirstName +
                "\nJunior made the list, but was implicitly casted into an Adult" +
                "\nNotice how we can only access the members of the base class, not the derived class\n");

            /* The people in this room could be represented as different classes e.g (Employee Consultant)  but if we wanted to make a 
               list of people attending the meeting we still could because we are all people "derived from the same base class" */


            // Output the value of the class bound static property "ObjectCreated" (not an instance property)
            Console.WriteLine("\nPerson class was instantiated {0} times.", Adult.ObjectsCreated); // Notice how it says 4 times, the derived class 

            persons.ForEach(person => Console.WriteLine($"{person.FirstName} {person.LastName}"));
            // alternative syntax: persons.ForEach((person) => { Console.WriteLine(person.FullName); });
            // alternative solution: foreach (var person in persons) Console.WriteLine(person.FullName);

            // The returntype of Where(predicate) is IEnumerable<T>. That is why we call ToList()
            var parents = persons.Where(predicate: person => person.LastName == "Johnsson" &&
            (person.FirstName == child.Mum || person.FirstName == child.Dad)).ToList();

            parents.ForEach(person => Console.WriteLine(person.FirstName));

            Console.WriteLine("\nPerson: Perhpas you meant Bob and not Blob?" +
                "\nChild: That's what i said!? Blob...");

            var dad = persons.FirstOrDefault(person => person.FirstName == "Bob");

            child.Dad = dad.FirstName;
            Console.WriteLine("\n" + child.Dad);

            // Partial Classes
            Employee employee = new("Bob", "Johnsson");
            employee.WakeUp();
            employee.GetDressed();
            employee.GoToWork();
            employee.DoWork();
            employee.GoToLunch();
            employee.DoWork();
            employee.GoHome();

            Console.WriteLine("When classes get too big it can be convenient to break them out into partial classes");
            employee.PrintProperties();
            employee.PrintMethods();
        }
    }
}


/*
Introduction to classes: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes
Introduction to OOP: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop

Object/Entity - an abstraction of an entity/thing in the real world that you want to store and process data about.
Class - template/blueprint used to create objects
instance - an object created from the template (class)
Members - Properties, backing fields, constructors and methods, delegates etc are all members of the instance or class
state - values stored in the fields are stored on the heap. These values make up the objects "state"


The four basic principles of object-oriented programming are:

1. Abstraction     Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.
2. Encapsulation   Hiding the internal state and functionality of an object and only allowing access through a public set of functions.
3. Inheritance     Ability to create new abstractions based on existing abstractions. (generally favour composition over inheritance)
4. Polymorphism    Ability to implement inherited properties or methods in different ways across multiple abstractions.
 
*/