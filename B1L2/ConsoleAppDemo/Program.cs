namespace ConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}


/*
--------------------------------------------SELECTION STATEMENTS & Operators-----------------------------------------------------------
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
- if, else, else if
- switch

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
logical operators
== equals
> greather than
< less than
<= less than or equal to
>= greater than or equal to
!= inequality operator


Unary operators: operates on one operand.   e.g. ! (logical negation)
Binary operators: operates on two operands. e.g. &&
Ternary operators: operates on three operands. e.g. ?:

// Ternary conditional operator
string myString = "";
Console.WriteLine($"{(myString.Length > 0 ? myString : "Empty string")}");

---

string permission = "Admin|Manager";
int level = 57;

if (permission.Contains("Admin"))
{
    if (level > 55)
    {
        Console.WriteLine("Welcome, Super Admin user.");
    }
    else
    {
        Console.WriteLine("Welcome, Admin user.");
    }
}
else if (permission.Contains("Manager"))
{
    if (level >= 20)
    {
        Console.WriteLine("Contact an Admin for access.");
    }
    else
    {
        Console.WriteLine("You do not have sufficient privileges.");
    }
}
else
{
    Console.WriteLine("You do not have sufficient privileges.");
}

 
// Instead of using a nested if statement we can use the binary logical AND operator
if (permission.Contains("Admin") && level > 55) { Console.WriteLine("Welcome, Super Admin user.");}; //  (both expressions must evaluate to true)
if (!permission.Contains("Manager") || level < 20) { Console.WriteLine("You do not have sufficient privileges.");}; // (first OR second must be true) note the use of logical negation

---


Console.WriteLine("press any key");
var key = Console.ReadKey();

if (char.IsUpper(key.KeyChar))
{
    Console.WriteLine($"\nAn uppercase letter: {key.KeyChar}");
}
else if (char.IsLower(key.KeyChar)) 
{
    Console.WriteLine($"\nA lowercase letter: {key.KeyChar}");
}
else if (char.IsDigit(key.KeyChar))
{
    Console.WriteLine($"\nA digit: {key.KeyChar}");
}
else
{
    Console.WriteLine($"\nNot alphanumeric character: {key.KeyChar}");
}

var a = (int)char.GetNumericValue(key.KeyChar);

int numericValue = (int)key.KeyChar;

switch (numericValue % 2)
{
    case 0:
        Console.WriteLine($"{numericValue} is an even value");
        break; // The break statement terminates the closest enclosing iteration statement
    case 1:
        Console.WriteLine($"{numericValue} is an odd Value");
        break;
}


------------------------------------------ITERATION STATEMENTS-----------------------------------------------------------------------
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements

- for 
- foreach
- do and while

// for (initialiser serction; condition; iterator section) {body}


for (int i = 1; i <= 20; i++) // declare and initialise and integer counter variable, set condition, and increment counter
{
    if (i == 10) // 10 will not be written to the console. Breaks out of for loop
    {
        break; // The break statement terminates the closest enclosing iteration statement
    }
    Console.WriteLine("using break statement: " + i);
}

for (int i = 1; i <= 20; i++)
{
    if (i == 10) // 10 will not be written to the console, continues to iterate until condition is met
    {
        continue; // The continue statement starts a new iteration of the closest enclosing iteration statement
    }
    Console.WriteLine("using continue statement: " + i);
}



---
// Foreach statement - iterate over collections see ArrayHelper class example

---

// While loop

int counter = 0;
while (true)
{
    counter++;
    Console.WriteLine("count: " + (counter) + "\t infinite loop..."); 
}


// Do-While


int i = 1000; 

do
{
    Console.WriteLine($"i is: {i}. Do-while loop still ran...");
		
} while (i < 10); // run condition



do
{

    double num1 = 0;
    double num2 = 0;
    double result = 0;

    Console.WriteLine("------------------");
    Console.WriteLine(" Simple Calculator");
    Console.WriteLine("------------------");

    Console.Write("Enter number 1: ");
    num1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter number 2: ");
    num2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Enter an option: ");
    Console.WriteLine("\t+ : Add");
    Console.WriteLine("\t- : Subtract");
    Console.WriteLine("\t* : Multiply");
    Console.WriteLine("\t/ : Divide");
    Console.Write("Enter an option: ");


    switch (Console.ReadLine())
    {
        case "+":
            result = num1 + num2;
            Console.WriteLine($"Your result: {num1} + {num2} = " + result);
            break;
        case "-":
            result = num1 - num2;
            Console.WriteLine($"Your result: {num1} - {num2} = " + result);
            break;
        case "*":
            result = num1 * num2;
            Console.WriteLine($"Your result: {num1} * {num2} = " + result);
            break;
        case "/":
            result = num1 / num2;
            Console.WriteLine($"Your result: {num1} / {num2} = " + result);
            break;
        default:
            Console.WriteLine("That was not a valid option");
            break;
    }
    Console.Write("Would you like to continue? (Y = yes, N = No): ");

} while (Console.ReadLine().ToUpper() == "Y");

Console.WriteLine("Bye!");
Console.ReadKey();



*/

// F10 Step through Debugging, 
// View > Task List: 
// TODO, LiveShare

// Exercise: Write a console app that randomly assigns all students to teams of 4
