
// single line comment

/* Multi-
   line Comment */

/// <summary> XML Comment </summary>

// Preprocessor directives e.g. for disabling and enabling warnings
#pragma warning disable CS1591 // compiler warns if XML comments are missing for public member
#pragma warning restore CS1591

/*  C# has a unified type system - all types inherit from the root type: Object
    - ref vs value type
*/




-----------------------------STATEMENTS------------------------------------------ -

// Declaration statement.
int counter;

// Assignment statement.
counter = 1;

// Error! This is an expression, not an expression statement.
// counter + 1;

// Declaration statements with initializers are functionally
// equivalent to  declaration statement followed by assignment statement:
int[] radii = { 15, 32, 108, 74, 9 }; // Declare and initialize an array.
const double pi = 3.14159; // Declare and initialize  constant.

// foreach statement block that contains multiple statements.
foreach (int radius in radii)
{
    // Declaration statement with initializer.
    double circumference = pi * (2 * radius);

    // Expression statement (method invocation). A single-line
    // statement can span multiple text lines because line breaks
    // are treated as white space, which is ignored by the compiler.
    System.Console.WriteLine("Radius of circle #{0} is {1}. Circumference = {2:N2}",
                            counter, radius, circumference);

    // Expression statement (postfix increment).
    counter++;
} // End of foreach statement block





------------------Basic Syntax and naming conventions----------------------------------

// Naming Conventions - camelCase vs PascalCase


// variables use camelCase, can contain numbers but must always start with character or _
// prefer longer descriptive names or code maintainability

string name = "bob"; //firstName
int messageCount = 3; //messages
float degreesCelsius = 34.02f; //temperature, float enough? do we need more precision?

// No string 
Console.Write("Hello, ");
Console.Write(name);
Console.Write("! You have ");
Console.Write(messageCount);
Console.Write(" messages in your inbox. The temperature is ");
Console.Write(degreesCelsius);
Console.Write(" celsius.");

// string concatenation (appending strings)
Console.WriteLine("hello " + name + "! " + "You have " + messageCount + " messages in your inbox. The temperature is " + degreesCelsius + " celsius.")

// string interpolation - template string (combining values into a string template)
Console.WriteLine($"Hello, {name}! You have {messageCount} messages in your inbox. The temperature is {degreesCelsius} celsius.");

// Composite string - allows for formatting
var indexZero = "first variable"; // Zero based counting
var indexOne = "second variable";
var indexTwo = "third variable";
Console.WriteLine("{0}, {1}, {2}", indexZero, indexOne, indexTwo);

// Composite string:
// The fixed text is Name =  and , hours = . The format items are {0}, whose index of 0 corresponds to the object name, and {1:hh}, whose index of 1 corresponds to the object DateTime.Now.
string name = "Fred";
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now);

// We can also use methods to format strings
var swedishDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
var australianDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
Console.WriteLine(swedishDateTime);
Console.WriteLine(australianDateTime);

// Escape character sequence: line feeds, tabs, escaping characters: instructions to the runtime affecting the output of your string
Console.Write("\n\n\n a couple of new lines \t\t\t a couple of tabs. Escaping new line: \\n \t Esaping \"double quotes\"");
Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!"); // use case example: output unicode characters

// Verbatim string
Console.WriteLine(@"\n\t new line and tab ignored/escaped"); // use case example: $@"C:\Users\{userName}\Documents\theResource.txt"


// Combine the differerent techniques e.g. to create a dynamic path to a resource (examples from tutorial you will spend the afternoon with)
string projectName = "ACME";
string englishLocation = $@"c:\Exercise\{projectName}\data.txt";
Console.WriteLine($"View English output:\n\t\t{englishLocation}\n");

string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
string russianLocation = $@"c:\Exercise\{projectName}\ru-RU\data.txt";
Console.WriteLine($"{russianMessage}:\n\t\t{russianLocation}\n");

Console.WriteLine("Generating invoices for customer \"ABC Corp\" ...\n");
Console.WriteLine("Invoice: 1021\t\tComplete!");
Console.WriteLine("Invoice: 1022\t\tComplete!");
Console.WriteLine("\nOutput Directory:\t");
Console.Write(@"c:\invoices");

// To generate Japanese invoices:
// Nihon no seikyū-sho o seisei suru ni wa:
Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
Console.WriteLine(@"c:\invoices\app.exe -j");





------------Perform basic operations on numbers in C#-----------------------------------

/* The following operators perform arithmetic operations with operands of numeric types:
	Unary: ++(increment), --(decrement), +(plus), and - (minus)operators
	Binary: * (multiplication), / (division), % (remainder), +(addition), and - (subtraction)operators 
	compound assignment operators: like +=, -=, *=, ++, and -- are used to perform a mathematical operation like increment or decrement,then assign the result into the original variable
 */

// The compiler parses your code and sees that the + (the operator) is surrounded by two numeric values (the operands).
// Given the data types of the variables (both are ints), the compiler figures out that you intended to add those two values.
int firstNumber = 12;
int secondNumber = 7;
Console.WriteLine(firstNumber + secondNumber);

int sum = 7 + 5;
int difference = 7 - 5;
int product = 7 * 5;
int quotient = 7 / 5; // decimal quotient = 7.0m / 5.0m;  output: 1.4
                      // decimal quotient = 7 / 5;	output: 1 (because each operand is interpreted as an integer literal and so information is lost (truncation - limiting number of decimal digits))

Console.WriteLine("Sum: " + sum);
Console.WriteLine("Difference: " + difference);
Console.WriteLine("Product: " + product);
Console.WriteLine("Quotient: " + quotient + " ..note that we lost some information due to truncation");

// same operation using explicit casting
int firstOperand = 7;
int secondOperand = 5;
decimal quotient = (decimal)firstOperand / (decimal)secondOperand;
Console.WriteLine(quotient); // output: 1.4

Console.WriteLine("Modulus of 200 / 5 : " + (200 % 5)); // reads like: "twohundered mod five"
Console.WriteLine("Modulus of 7 / 5 : " + (7 % 5)); // output 2, because thats the remainder




----------------------------VALUE TYPES------------------------------------------

/* VALUE TYPES:
Simple types
- signed integral: sbyte, short, int, long
- unsigned integral: byte, ushort, uint, ulong
- unicode characters: char (UTF-16 Code unit)
- binary floating-point: float, double
- high-precision decimal floating-point: decimal
- boolean: true/false values
Enum types
Struct types
Nullable value types (e.g. nullable int - assigned at runtime)
Tuple value types (lightweight data structure for grouping multiple data elements) */


// EXAMPLES: SIMPLE TYPES

// Declate variable type, create an identifyer, use assignment operator (=) to assing a literal to the variable.
int simpleType1 = 1; // we declare simple types using keywords which are aliases for the predefined struct types in the System namespace

sbyte simpleType2 = 2; // 8 bit
short simpleType3 = 3; // 16-bit
ushort simpleType4 = 4; // 16-bit, only non-negative numbers
uint simpleType5 = 5; // 32-bit, only non-negative numbers

char character = 'a';
float aFloat = 10.1234567f; // 4 bytes, precision: 6-9 
double aDouble = 10.00d; // 8 bytes, precision: 15-17
decimal aDecimal = 10.00m; // 16 bytes, precision: 28-29

bool on = true;
bool off = false;

Console.WriteLine(1); // int literal
Console.WriteLine(simpleType1); // referencing a value (instance of a value type) stored in a variable using its identifier

Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");


-------------------VALUE TYPES: ENUM----------------------------------
enum Size
{
    // Assign integer literal to enum identifyer
    XS = 0,
    S = 1,
    M = 2,
    L = 3,
    XL = 4,
}

// referencing enum declared above
Console.WriteLine("my t-shirt size is " + Size.M);

//casting to enum from int
Size size = (Size)2;
Console.WriteLine("my t-shirt size is still " + size);

//casting to int from enum
int sizeIsNowAnInteger = (int)Size.M;
Console.WriteLine("result after explicit casting " + sizeIsNowAnInteger + " ");

-----------------------VALUE TYPES: STRUCT, Nullable Types, Tuples---------------------------------------

/// <summary>Pass two integers <paramref name="x"/> and <paramref name="y"/> and see what happens.</summary>
/// <param name="x">the X coordinate.</param>
/// <param name="y">the Y coordinate.</param>
struct Coordinate
{
    public int X;
    public int Y;

    // Struct Constructor Method
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}

Coordinate point = new Coordinate();
Console.WriteLine("first coordinate: " + point.X);
Console.WriteLine("second coordinate: " + point.Y);

// Nullable types
Nullable<int> myInt = null; // shorthand:  int? myInt = null; 
Console.WriteLine("Has no value, returns nothing: " + myInt + "\tnull is less than 0, the absence of a value");
if (myInt == null) { Console.WriteLine("null"); }

// Using tuple to represent a cube
(int Length, int Height, int Breadth) cube = (3, 3, 3);
Console.WriteLine($"3D Cube length x height x breadth {cube}");

// a carton of milk is 19,90 SEK. How much is in total if I buy 3?
(decimal Price, int Count) milkInBag = (19.90m, 3);
Console.WriteLine($"Number of milk catorns in the bag: {milkInBag.Count}, total sum payed: {milkInBag.Price * milkInBag.Count} SEK.");



--------------------Implicit ans Explicit Type Casting (performed by compiler)--------------------------

// No type cast of numeric literal
Console.WriteLine(1.GetType()); // output: System.Int32 

// implicit type cast
string firstName = "Bob";
int widgetsSold = 7;
var output = firstName + " sold " + (widgetsSold + 7) + " widgets.";
Console.WriteLine(output.GetType()); // output: Syste.String

// explicit type cast
Console.WriteLine((int)'a'); // output: 97
Console.WriteLine(((int)'a').GetType()); // Add parentheses to make our intention clear to the compiler

var message = "Hello World!";
// message = (string)10.0m; // When casting is not an option use methods: error CS0030: Cannot convert type 'decimal' to 'string'

Console.WriteLine(message);
message = 50.0m.ToString();
Console.WriteLine(message);

decimal exampleValue;

// explicitCastingExample = (decimal)("10.0m"); // output: cannot implicitly convert type string to decimal

// explicitCastingExample = Convert.ToDecimal("5.05m"); // Output: input string was not in correct format

exampleValue = Convert.ToDecimal("5.05");

Console.WriteLine(exampleValue.GetType());

var exampleValue2 = (decimal)13.00;
Console.WriteLine(exampleValue2.GetType());

// exampleValue2 = (float)13.00; // output: cannot implicitly convert...
exampleValue2 = (int)13.00;

Console.WriteLine(exampleValue2.GetType());

// part of the explanation:
int i = int.MaxValue; // = 2147483647
float f = (float)i;   // = 2147484000 --> lost last three digits!


-----------------------NON STATIC CLASS EXAMPLE---------------------------------
internal class NonStaticClass
{
    // Private backing field
    private string myVar;

    // Public property
    public string MyProperty
    {
        get { return myVar; }
        set { myVar = value; }
    }

    // Class Constructor
    public NonStaticClass()
    {
        myVar = "I am a private member made accessible through public property";
    }

    // Member Method
    public void OutputStringLiteral(string literal)
    {
        Console.WriteLine(literal);
    }
}

----------------------------------STATIC CLASS EXAMPLES-------------------------------------------------
/// <summary>
/// A Static class that illustrates different ways of declaring and initialising arrays of type string.
/// </summary>
internal static class StringHelper
{
    // Declare and initialise string array using alternate syntax


    public static void PrintElementsInArray(string[] array)
    {
        Console.WriteLine();
        // Iterate over the array and write the value of each elements to the console
        foreach (var i in array) { Console.Write(i + ", "); }
    }

    public static void ShowAlternativeSyntax()
    {
        Console.WriteLine(
        "\n\n" +
        "// Declare and initialise string array using alternate syntax\n" +
        "string[] array1 = new string[2]; // creates array of length 2, default values (\"\")\n" +
        "string[] array2 = new string[] { \"A\", \"B\" }; // creates populated array of length 2\n" +
        "string[] array3 = { \"A\", \"B\" }; // creates populated array of length 2\n" +
        "string[] array4 = new[] { \"A\", \"B\" }; // created populated array of length 2"
        );

        Console.ReadKey();
    }
}

internal static class StringManipulation
{
    public static void DemonstrateStringManipulation()
    {
        string pangram = "The quick brown fox jumps over the lazy dog";

        string[] message = pangram.Split(' ');
        string[] newMessage = new string[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char[] letters = message[i].ToCharArray();
            Array.Reverse(letters);
            newMessage[i] = new string(letters);
        }

        string result = String.Join(" ", newMessage);
        Console.WriteLine(result + "\n");
    }
}

----------------------------------------------------------------------------