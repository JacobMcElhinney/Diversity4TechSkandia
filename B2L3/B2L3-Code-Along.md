# B2L3 Code along

>**Note**
> Detta material bygger på följande microsoft learn resurser, men har anpassats för vår kontext och en mer realistisk tillämpning. Vi använder exempelvis en annan database provider (SQL Server) och ska dessutom "reverse engineer" en existerande SQL databas.  
>- [Your first EF Core console app](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio)
> - [Reverse engineerg](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=vs)

## Lärandemål 
- se powerpoint

## Reverse Engineer existing database
Vi kommer nu att skapa en databas i SSMS, skapa en console app i Visual Studio och "reverse engineer" databasen med Entity Framework Core.

### STEG 1: skapa SQL Databas
- starta SSMS
- Hämta följande fil och följ instruktionerna för att skapa databasen [B2L3 - Database First.sql]() // TODO: insert link
- verifiera att du lyckats skapa databasen med seed data i Customer och Product tabellerna.

### STEG 2: Skapa en Console App
- Visual Studio: skapa en ny Console application som du döper till: 
- Project & Solution Name: `DatabaseFirstConsoleApp`
- Leave Unchecked: "Place solution and project in the same directory" 
- Framework: `.NET 7.0 (Standard Term Support)`
- Keep checked: `Do not use top-level statements`

### STEG 3: Installera EF Core Database Provider (SQL Server) 
**NOTE**
> Notera att vi **INTE** använder SQLlite som i MS Learn Guiden.

- öppna PM Console under: Tools > NuGet Package Manager > Package Manager Console
- Installera sedan Entity Framework Core för SQL server (database provider):

```pwsh
# Du kan dubbelklicka på din "project file" vid namn DatabaseFirstConsoleApp för att verifiera installationen
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

I din project file (`DatabaseFirstConsoleApp.csproj`) borde du nu se följande:
```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.4" />
  </ItemGroup>
```

### STEG 4: Installera EF Core Tools


Läs mer om paketet [här](https://learn.microsoft.com/en-us/ef/core/cli/)


lokal installation i projektet `Install-Package Microsoft.EntityFrameworkCore.Tools`
```pwsh
Install-Package Microsoft.EntityFrameworkCore.Tools
```

>**NOTE**
>Du kan också installera ef core tools globalt...
>```pwsh
># Här är entry point .NET CLI, vi använder .NET CLI för att installera EF Core tools globalt
>dotnet tool install --global dotnet-ef
>
># Såhär kan du uppdatera den globala installationen
>dotnet tool update --global dotnet-ef
>
># Verify installation
>dotnet ef
>```


### STEG 5: Installera EF Core Design tools 
Låter oss generera ("scaffold") våra "entity models" och DbContext klass utifrån databas schemat.
*Mer om [tools](https://learn.microsoft.com/en-us/ef/core/what-is-new/nuget-packages#tools)*
```pwsh
# Installera Design paketet
Install-Package Microsoft.EntityFrameworkCore.Design
```

### STEG 6: Visual studio SQL Server Object Explorer

Med Visual studio SQL Server Object Explorer kan vi enkelt bilda oss en översikt av databasens innehåll.
I visual studio under **View** > **SQL Server Object Explorer**.

- Om du inte redan ser din server och databas:  
  Tryck på knappen **Add SQL Server** > **browse** > **Local** och klicka på **MSSQLocalDB** > **Connect**  
- Expandera sedan trädet och högerklicka på **DatabaseFirst** > **properties**
- under listan av properties finner du din **Connection string** Kopiera den och fortsätt med nästa steg..

### STEG 7: Reverse engineer database // TODO: skriv om och visa optioons

Vi kommer åter igen använda PowerShell i Package Manager consollen tillsammans med [Scaffold-DbContext](https://learn.microsoft.com/en-us/ef/core/cli/powershell#scaffold-dbcontext).  
Låt oss bryta ned syntaxen:

```pwsh
#Skriv Get-Help Scaffold-DbContext för att få information om "the cmdlet"
Get-Help Scaffold-DbContext
```
- Den `cmdlet` vi använder är `Scaffold-DbContext` vilket låter oss generera kod utifrån databasschemat.  
- nästa parameter är vår *connection string* som vi kopierat omgiven av \`single quotes\`.
- därefter anger vi vår databas provider dvs: `Microsoft.EntityFrameworkCore.SqlServer`
- nästa parameter (OutputDir, ContextDir) är vart vi vill att filerna ska skapas i relation till vår `.csproj` fil. Konventionen är att spara "entity models" i en `Models` mapp och `DbContext` filen i en `Data` mapp.
- Därefter specificerar vi namnet på vår DbContext fil genom att kombinera databasens namn `DatabaseFirst`+`Context`

>**NOTE**
>om vi endast vill inkludera tabeller med ett visst schema e.g. `Sales.Employee` kan vi läggga till `-Schemas` flaggen eller `-Tables Employee, Manager` för att endast inkludera vissa tabeller.

```pwsh
# Klistra in din connection string istället för <place_holder> nedan. I övrigt stämmer allt.
Scaffold-DbContext <'ConnectionString'> Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context DatabaseFirstContext 
```
- Notera varningen, det är något vi kommer tillbaka till senare under programmet.
- Gå in i `.\Data\DatabaseFirstContext.cs` notera `public virtual DbSet<Customer> Customers {get;set;}`. Trots att våra tabeller är döpta i singular pluraliserar EF Core våra tabellers namn i koden automatiskt. Koden fungerar utmärkt tillsammans med databasen och namnen där är oförändrade. Vi kan prova att använda `-NoPluralize` tillsammans med `Scaffold-DbContext`, men det fungerar oavset.
- Notera nu hur vi fått data attribut/data annotationer, exempelvis `[Table("Customer")]` som anger tabellens faktiska namn i databasen.
- Notera också i `.\Models\Customer.cs` hur entity framework core gjort några properties nullable, 

Om du vill få tillbaka det senaste kommandot du utförde i konsollen kan du tryckapå "pil upp"/arrow key up.
```pwsh
# Med -NoPluralize -Force
Scaffold-DbContext <'ConnectionString'> Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context DatabaseFirstContext -NoPluralize -Force
```
- Notera hur namnen ändrats i samtliga filer, även DbSetters.

```pwsh
# Utforska fler av alternativen
Get-Help Scaffold-DbContext
```
Låt oss nu prova att använda följande [parameter options](https://learn.microsoft.com/en-us/ef/core/cli/powershell#scaffold-dbcontext):
- `[-Connection]` din connection string (View > SQL Server Object Explorer)
- `[-Priovider]` din database provicer (Microsoft.EntityFrameworkCore.SQLServer) se i .csproj
- `[-Outdir]` skapa directory/mapp för dina entity models (i relation till .csproj)
- `[-ContextDir]` skapa directory/mapp (i relation till .csproj)
- `[-Context]` vad vi vill döpa dbcontext filen till `<DatabaseName>Context`
- `[-DataAnnotations]` (boolean, inkuderar vi den är den true)
- `[-Force]` när vi vill "override" tidigare scaffoldade Entity och DbContext klasser

Nu gör vi en sista repetition av `Scaffold-DbContext`, denna gång med `-DataAnnotations` och `-Force`
```pwsh
# kom ihåg att byta ut connection string placeholder mot din faktiska connection string
Scaffold-DbContext '<ConnectionString>' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context DatabaseFirstContext -DataAnnotations -Force
```

>**Warning**
> Om du får `build failed` försäkra dig om att du inte har några kompileringsfel, se `error list` för din solution.

Vi kan skriva SQL queries med hjälp av metoden FromSqlRaw. Har du några förslag på vad vi ska testa?
```c#
static void Main(Strinf[] args)
{
  // skapa context för unit-of-work
  using var context = new DatabaseFirstContext();

  context.Customers.FromSqlRaw("SELECT * FROM dbo.Customer").ToList().ForEach((c)=> Console.WriteLine(c.FirstName));

  // dispose of context unit-of-work är över. vi ska se på alternativa sätt snart.
  context.Dispose();
}
```

## STEG 8: Add-Migration spSelectCustomerById
Vi ska nu skapa en ny migration. Närmare bestämt en stored proceedure som vi vill lagra i databasen, men som annu inte finns där. Kika gärna i SSMS: **<DatabaseName>** > **Programmability** > **Stored Procedures**. Där finner du de existerande system stored procedures och snart kommer du även ha skapat en egen custom "user stored procedure".

**Note**
> Vi har tidigare kikat på `sp_rename` när vi ville döpa om tabeller eller kolumner. När vi skapar egna stored procedures får vi inte använda det reserverade systemprefixet `sp_` utan kan då använda `sp`, `usp_` eller liknande beroende på vad som är konventionen i kontexten/databas på din arbetsplats.

```pwsh
#Läs på om cmdlet
Get-Help Add-Migration

#Skapa först en migration som du döper till InitialCreate
Add-Migration InitialCreate

#Skapa sedan en ytterligare migration som du döper enligt föjande, notera att denna fil är tom.
Add-Migration AddspSelectCustomerById
````

en ny mapp `Migrations` skapas och i den finner du din *migration file* 
```pwsh
# Kör kommandot nedan för att se dina migration files och huruvida de applicerats på databasen eller inte
Get-Migration
```

`InitialCreate` filen kan användas för att skapa en identisk databas (code first). Låt oss inspektera den...
`AddspSelectCustomerById` innehåller en up/down method utan implementation. 

klistra in följande implementationer i respektive metod:
```C#
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string createProcedure = @"CREATE PROCEDURE spSelectCustomerById
                                      @Id int
                                      AS
                                      BEGIN
                                          SELECT * FROM dbo.Customer
                                          WHERE CustomerID = @Id
                                      END";
            migrationBuilder.Sql(createProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string dropProcedure = @"DROP PROCEDURE spSelectCustomerById";
            migrationBuilder.Sql(dropProcedure);
        }
```

```pwsh
# Om vi försöker applicera InitialCreate på en redan existerande databas får vi följande error: there is already an object named...in the database
Update-Database
```
Ta bort `InitialCreate.cs` och kör sedan `Update-Database` igen. Kika i SSMS och se att din stored proceedure nu finns där. Det är i regel smidigare att skapa stored procedure koden i SSMS eftersom vi får intellisense support. låt oss skapa några till där innan vi kommer tillbaka hit.

>**NOTE
>Om du vill ha tillbaka IinitialCreate kan du döpa om (för att spara anda filer) eller ta bort `Migrations` mappen och skapa den igen.

## Steg 9: Skapa Stored proceedures

- I SSMS expandera DatabaseFirst > Programmability > Stored Procedures > högerklicka > Stored Procedure...  
- Man kan också skapa stored proceedures genom > New Query.
- Notera att den vi skapat redan finns där.

```sql
-- =====================================
-- Example stored proceedures
-- =====================================

-- Create Customer
CREATE PROCEDURE spCreateCustomer
@FirstName varchar(25), 
@LastName varchar(25), 
@StreetAddress varchar(50),
@city varchar (25),
@StateOrProvince varchar(25),
@Country varchar(50),
@PostalCode int,
@Phone int,
@Email varchar(50)
AS
BEGIN
	INSERT INTO dbo.Customer
		VALUES 
		(@FirstName, @LastName, @StreetAddress, @city, @StateOrProvince, @Country, @PostalCode, @Phone, @Email )	
END
GO

-- Select All Customers
CREATE PROCEDURE spSelectAllCustomers
AS
BEGIN
	SELECT * FROM dbo.Customer
END
GO

-- Select Customer by Id
CREATE PROCEDURE spSelectCustomerById
@Id int
AS
BEGIN
	SELECT * FROM dbo.Customer
	WHERE CustomerID = @Id
END
GO

-- Update Customer
CREATE PROCEDURE spUpdateCustomer
@Id int,
@FirstName varchar(25), 
@LastName varchar(25), 
@StreetAddress varchar(50),
@city varchar (25),
@StateOrProvince varchar(25),
@Country varchar(50),
@PostalCode int,
@Phone int,
@Email varchar(50)
AS
BEGIN
	UPDATE dbo.Customer
		SET 
		FirstName = @FirstName,
		LastName = @LastName,
		StreetAddress = @StreetAddress,
		city = @city,
		StateOrProvince = @StateOrProvince,
		Country = @Country,
		PostalCode = @PostalCode,
		Phone = @Phone,
		Email = @Email
	WHERE CustomerID = @Id
END
GO

-- Delete Customer
CREATE PROCEDURE spDeleteCustomer
@Id int
AS
BEGIN
	DELETE FROM dbo.Customer
	WHERE CustomerID = @Id
END
GO

-- Execute Stored Procedures 
EXEC dbo.spCreateCustomer 'Uncle', 'Bob', 'ShortStreet 1', 'Täby', 'Stockholm', 'Sweden', 18236, 0762837462, 'uncle.bob@1137programmer.com';
GO
EXEC dbo.spSelectAllCustomers;
GO
EXEC dbo.spSelectCustomerById 1;
GO
EXEC dbo.spUpdateCustomer 1, 'Sam', 'Smith', 'ShortStreet 2', 'Stockhom', 'Täby', 'Sweden', 18236, 731740275, 'john.smith@company.se';
GO
EXEC dbo.spDeleteCustomer 3;
GO
```

## Steg 10: Anropa stored procedures från Program.cs
```C#
 static void Main(string[] args)
{
    /*
        Each context instance has a ChangeTracker that is responsible for keeping track of changes that need to be 
        written to the database. As you make changes to instances of your entity classes, these changes are recorded 
        in the ChangeTracker and then written to the database when you call SaveChanges. The database provider is responsible 
        for translating the changes into database-specific operations (for example, INSERT, UPDATE, and DELETE commands for a 
        relational database).
        https://learn.microsoft.com/en-us/ef/core/saving/
    */

    using DatabaseFirstContext context = new();

    // spSelectCustomerById
    var customerById = context.Customers.FromSqlRaw("spSelectCustomerById {0}", 1).ToList().FirstOrDefault();

    if (customerById != null)
    {
        Customer c = customerById;

        Console.WriteLine("spSelectCustomerById...\n\nId\tName\n------------------");
        Console.WriteLine("{0}\t{1} {2}", c.CustomerId, c.FirstName, c.LastName);
        Thread.Sleep(1000);
    }

    // spSelectAllCustomers
    var customers = context.Customers.FromSqlRaw("EXEC spSelectCustomerById @Id={0}", 1).ToList();
    var customers2 = context.Customers.FromSqlRaw("SELECT * FROM dbo.Customer").ToList();
    Console.WriteLine(customers2.Count);

    if (customers != null)
    {
        Console.WriteLine("\nspSelectAllCustomers...\n\nId\tName\n------------------");
        context.Customers.ToList().ForEach((c) => Console.WriteLine($"{c.CustomerId}:\t{c.FirstName} {c.LastName}"));
        Thread.Sleep(1000);
    }

    context.Dispose();

    // Update Unit-of-work
    using (var spUpdateCustomerContext = new DatabaseFirstContext())
    {
        var updated = spUpdateCustomerContext.Customers.FromSqlRaw("spSelectCustomerById {0}", 1).ToList().FirstOrDefault();

        if (updated != null)
        {
            updated.FirstName = "John";
            updated.LastName = "Smith";
            spUpdateCustomerContext.Customers.FromSqlRaw("spUpdateCustomer {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}",
                updated.CustomerId,
                updated.FirstName,
                updated.LastName,
                updated.StreetAddress,
                updated.City,
                updated.StateOrProvince,
                updated.Country,
                updated.PostalCode,
                updated.Phone,
                updated.Email);

            var updatedCustomer = spUpdateCustomerContext.Customers.FromSqlRaw("spSelectCustomerById {0}",
                updated.CustomerId).ToList().FirstOrDefault();

            Console.WriteLine("\nspUpdateCustomer...\n\nId\tName\n------------------");
            Console.WriteLine("{0}\t{1} {2}", updatedCustomer.CustomerId, updatedCustomer.FirstName, updatedCustomer.LastName);
            Thread.Sleep(1000);
            Console.WriteLine("above name shoud be unique");
        }

        spUpdateCustomerContext.SaveChanges();
    }

    // Delete Unit-of-work
    using (var spDeleteCustomerContext = new DatabaseFirstContext())
    {
        var lastAdded = spDeleteCustomerContext.Customers
            .FromSqlRaw("spSelectAllCustomers").ToList().OrderByDescending(c => c.CustomerId).FirstOrDefault();

        if (lastAdded is not null)
        {
            Console.WriteLine("\nspDeleteCustomers...\n\nId\tName\n------------------");
            spDeleteCustomerContext.Customers.FromSqlRaw("EXEC spDeleteCustomer {0}", 4);
            Console.WriteLine("\nspSelectAllCustomers...\n\nId\tName\n------------------");
            var customersAfterDelete = spDeleteCustomerContext.Customers.FromSqlRaw("EXEC spSelectCustomerById {0}", 1).ToList();
            spDeleteCustomerContext.Customers.ToList().ForEach((c) => Console.WriteLine($"{c.CustomerId}:\t{c.FirstName} {c.LastName}"));
            Thread.Sleep(1000);

            spDeleteCustomerContext.SaveChanges();
        }

    }

    // Exiting application
    Console.WriteLine("\nAll proceedures executed...");
}
```