# B2L4ConsoleApp

>**Note**
> This guide deviates from the referenced tutorials as it is tailored for a ConsoleApp.

## References
- [Code First to a New Database](https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database)
- [Relationships](https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)
- [Data Annotations](https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations)
- [Querying Data](https://learn.microsoft.com/en-us/ef/core/querying/)

## prerequisites
- MS SQL SERVER
- Server name: (localdb)\MSSQLLocalDB

### ConsoleApp
**Create a New Console Application**
- name it `CodeFirst`
- Use `.Net7 (LTS)`
- Do **not** place Solution and project in the same directory
- Do **not** use Top-level-statements

### Install packages
```pwsh
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

## Database First comparison & Recap

Open SSMS, Connect to server `(localdb)\MSSQLLocalDB`
>**Note**
>`(localdb)\MSSQLLocalDB` is a lightweight version of the SQL Server Database Engine and is intended for app development, not production use.

```sql
-- ===============================================================================
-- Database First Reference for B2L4 Code First approach with EF Core Console App
-- ===============================================================================

/*
	Note!
	- use server: (localdb)\MSSQLLocalDB
	  LocalDB is a lightweight version of the SQL Server Database Engine that uses less resources than a production version would.
	- Connect to server: Object Explorer > Connect > Database Engine.. > server name: (localdb)\MSSQLLocalDB > Connect
	- Press F5 to execute all queries. Or highlight specific query, then press F5. 
	- Highlight keyword + F1 to reference documentation
*/

CREATE DATABASE CodeFirst
GO

USE CodeFirst
GO

-- 1:n One Team can have many students belong to it 
CREATE TABLE dbo.Team
(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] varchar(25) NOT NULL
)
GO

-- 1:1 One student can belong to one Team. 

CREATE TABLE dbo.Programmer
(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] varchar(25) NOT NULL,
	TeamId int NULL	-- The teams may not be formed by the time the student is registered on the course
	FOREIGN KEY (TeamId) REFERENCES dbo.Team(Id)
		ON DELETE SET NULL -- If Team (parent table) is deleted, Student is left without a team and the TeamId foreign key (in child table) is set to NULL.
		ON UPDATE CASCADE -- If the TeamId changes in the parent table, that change will be reflected in the child table
)
GO
```

In Visual Studio Open the *SQL Server Object Explorer* > copy *connection string* form databse properties and replace the string provided to the `-Connection` parameter in the example below. Then execute the PowerShell command in your Visual Studio Packacke Manager Console.
```pwsh
Scaffold-DbContext -Connection 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context CodeFirstContext -DataAnnotations
```

Next up, we are going to create the database using a Code first approach. Delete the databse in SSMS but leave the scaffolded folders and files to save us some time. We will review those files and discuss *Data Annotations*, *Scalar-and Navigation Properties* and *DbContext* in the next chapter.

## Code First with LINQ Queries

### Create directives for DbContext and Entity Models
-  In solution Explorer > right-click on Project > Add > New Folder... 
-  Add folder `Data` and `Models`

### Add Entity classes (Data Model/Domain/POCO classes)
Create two new files in the `Models` directory: `Team.cs` and `Programmer.cs`  

**Team Entity**
```C#  
namespace CodeFirst.Models;

[Table("Team")]
public partial class Team
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<Programmer> Programmers { get; } = new List<Programmer>();
}
```  

**Programmer Entity**
```C#
namespace CodeFirst.Models;

[Table("Programmer")]
public partial class Programmer
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int? TeamId { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("Programmers")]
    public virtual Team? Team { get; set; }
}
```

#### Property Types
- **Scalar Properties:** holds a single value and maps to a single field in the corresponding row in the database table.  
*Example from Team.cs*:
```c# 
    [Key]  // Denotes property as Primary Key in corresponding database table
    public int Id { get; set; }	 // Scalar Property

    [StringLength(25)]	// varchar(25)
    [Unicode(false)] // varchar as opposed to nvarchar
    public string Name { get; set; } = null!; // Scalary Property
```
*Example from Programmer.cs*:
```C#
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int? TeamId { get; set; } // Foreign Key, referenced by Navigation Property data annotation

```

- **Navigation Properties:** Defines the relationships between *entity classes* used to navigate table relationships (1:1, 1:n, n:n) A Team has many Programmers (n:1) and a Programmer belongs to a Team (1:1) if any.
  - use `virtual` keyword to enable EF Core to automatically query and populate properties (lazy loading), when we access or iterate over them
*Example from Team.cs*:
```C#
   [InverseProperty("Team")]
    public virtual ICollection<Programmer> Programmers { get; } = new List<Programmer>();
```

*Example from Programmer.cs*:
```C#
    [ForeignKey("TeamId")] // references class member by same name and denotes scalar property as Foreign Key
    [InverseProperty("Programmers")] // Denotes the name of the property in the related entity 
    public virtual Team? Team { get; set; } // virtual, nullable (optional) Type, Navigation Property name identical to related entity 
```

### Create Derived Context Class

Create derived `DbContext` class. I've added some aditional comments for clarification
```C#
namespace CodeFirst.Data;

/// <summary>
/// The derived context class represents a sessionn with the database, allowing for querying data and saving any data manipulation action we perform.
/// The class name is convetionally made up of the datbase (Db) name combined with `Context`: `<DataBaseName>Context.cs`
/// </summary>
public partial class CodeFirstContext : DbContext
{
    // DbSetters Allow us to query and save instances of corresponding type
    // represents a table in the database. Create one DbSet<TEntity> for each Entiy representing a table
    public virtual DbSet<Programmer> Programmers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }
}
```

Notice that we can not create a migration file unless we provide our CodeFirstContext instance with some additional configuration
```pwsh
PM> Add-Migration InitialCreate
Build started...
Build succeeded.
System.InvalidOperationException: No database provider has been configured for this DbContext. A provider can be configured by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider. If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.Initialize(IServiceProvider scopedProvider, DbContextOptions contextOptions, DbContext context)
   at Microsoft.EntityFrameworkCore.DbContext.get_ContextServices()
   at Microsoft.EntityFrameworkCore.DbContext.get_InternalServiceProvider()
   at Microsoft.EntityFrameworkCore.DbContext.Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<System.IServiceProvider>.get_Instance()
   at Microsoft.EntityFrameworkCore.Infrastructure.Internal.InfrastructureExtensions.GetService[TService](IInfrastructure`1 accessor)
   at Microsoft.EntityFrameworkCore.Infrastructure.AccessorExtensions.GetService[TService](IInfrastructure`1 accessor)
   at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.CreateContext(Func`1 factory)
   at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.CreateContext(String contextType)
   at Microsoft.EntityFrameworkCore.Design.Internal.MigrationsOperations.AddMigration(String name, String outputDir, String contextType, String namespace)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigrationImpl(String name, String outputDir, String contextType, String namespace)
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.AddMigration.<>c__DisplayClass0_0.<.ctor>b__0()
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.<>c__DisplayClass3_0`1.<Execute>b__0()
   at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.Execute(Action action)
No database provider has been configured for this DbContext. A provider can be configured by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider. If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
PM> 
```
We are presented with some options for solving this issue...
```pwsh
System.InvalidOperationException: No database provider has been configured for this DbContext. A provider can be configured by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider. If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
```
**overriding the 'DbContext.OnConfiguring' method**  
We could override the base class method `OnConfgiguring` which exposes (provides an API surface) the DbContextOptionsBuilder, allowing us  to configure the database provider and connection string to be used with each instance of our derived DbContext class. 
- **Copy connection string to server (no database exists yet)**: Visual Studio > SQL Server Object Explorer > (localdb)\MSSQLLocalDB > Properties > copy connection string *e.g:* 
```c#
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
```
- Edit `CodeFirstContext.cs` accordingly:
```C#
namespace CodeFirst.Data;

public partial class CodeFirstContext : DbContext
{
    // allows us to configure our database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace the Initial Catalog=<Value> with your intended DB Name (Intial Catalog=MyDatabaseName)
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
	
	// to enable logging (see EF Core generated SQL queries), uncomment the following line:
	//optionsBuilder.LogTo(Console.WriteLine);
    }

    public virtual DbSet<Programmer> Programmers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }
}
```
Now add the migration and apply it to the database
```pwsh
# Scaffold migration files into .\Migrations directory
Add-Migration InitialCreate

# Apply migration to create database and tables
Update-Database

# Verify that the migration was applied
Get-Migration
```

## CRUD operations with LINQ

```C#
 static void Main(string[] args)
        {

            // Create Team
            using (var context = new CodeFirstContext())
            {
                context.Teams.Add(new Team { Name = "Team 1" });
                context.SaveChanges();
                Console.WriteLine("adding team...");
                Console.ReadLine();
            }

            // Create Programmer
            using (var context = new CodeFirstContext())
            {
                context.Programmers.Add(new Programmer { Name = "Elida" });
                context.SaveChanges();
                Console.WriteLine("Adding programmer..");
                Console.ReadLine();
            }

            // Update Programmer
            using (var context = new CodeFirstContext())
            {
               var returnedProgrammer = context.Programmers.FirstOrDefault(p => p.Name == "Elida");
                if (returnedProgrammer != null)
                {
                    returnedProgrammer.TeamId = 1;
                    context.Programmers.Update(returnedProgrammer);
                    context.SaveChanges();
                    Console.WriteLine("Updating programmer...");
                    Console.ReadLine();
                }

            }

   

            // Get Programmers
            using (var context = new CodeFirstContext())
            {
                var allProgrammers = context.Programmers.ToList();
                Console.WriteLine("Listing programmers...");
                Console.ReadLine();
                allProgrammers.ForEach(p => Console.WriteLine(p.Name));
            }


            Programmer programmer;

            // Get Programmer By Id
            using (var context = new CodeFirstContext())
            {
                programmer = context.Programmers.FirstOrDefault(p => p.Id >= 1);
            }

            // Delete Programmer
            using (var context = new CodeFirstContext())
            {
                if (programmer is not null)
                {
                    context.Programmers.Remove(programmer);
                    context.SaveChanges();
                }
                var programmers = context.Programmers.ToList();

                if (programmers.Count > 3)
                {
                    context.Programmers.RemoveRange(programmers);
                    context.SaveChanges();
                }
            
            }
```



## Exploring LINQ
```C#
 static void Main(string[] args)
        {
            Stopwatch stopwatch = new();
            var intervals = new[] { new { Operation = "OPERATION", Time = "\t\tTIME" } }.ToList();

            // Scoping the lifetime of our DbContext instance with a using statement 
            // means we don't have  to explicitly dispose of the instance by calling 
            // context.Dispose() 
            using (var context = new CodeFirstContext())
            {
                Console.WriteLine("Register Programmer NickName:");
                var nickName = Console.ReadLine();

                if (nickName is not null && nickName.Length > 0)
                {
                    var Programmer = new Programmer { Name = nickName };
                    context.Programmers.Add(Programmer);

                    // Notify ChangeTracker to make sure entity changes are persisted on database
                    context.SaveChanges();
                }
            }

            Console.Clear();
            using (var context = new CodeFirstContext())
            {
                // Query Database using LINQ QUERY SYNTAX - note the execution order like we talked about in B2L1 (remember Yoda) :-)
                var querySyntax = from p in context.Programmers
                                  orderby p.Name
                                  select p;

                // same query using LINQ METHOD SYNTAX 
                var methodSyntax = context.Programmers
                    .ToList()
                    .OrderBy(p => p.Name); //you can call ThenBy() subsequent ordering. Note that the return type will not be List (see return type of OrderBy)

                // Sql query as a string argument (safe when no user provided input - for user input use composite formatting, allows for converstion of parameter to safe DbParameter type)
                var fromSQLRaw = context.Programmers
                    .FromSqlRaw("SELECT Id FROM dbo.Programmer WHERE Id = 1");

                // same result using query syntax
                IEnumerable<int> enumerableInt =
                    from p in context.Programmers
                    where p.Id == 1
                    select p.Id;

                // same result using method query
                var firstOrDefault = context.Programmers.FirstOrDefault(p => p.Id == 1);

                // Sql query as FormattableString (parameters will be converted to DbParameter)
                var usingFromSql = context.Programmers
                    .FromSql($"SELECT * FROM dbo.Programmer") // SELECT Id will throw an exception: 'Invalid column name 'Name'. Invalid column name 'TeamId'.' 
                    .Where(p => p.Id == 1) // Instead we can
                    .ToList(); // Here return type will be ToList

                // If we are only interested in scalar values (single column field/aggregate of values) we do not have to use the Programmers collection
                // Query scalar (non-entity) types using context.DataBase 
                var onDatabase = context.Database
                    .SqlQuery<int>($"SELECT Id FROM dbo.Programmer WHERE Id = 1");
                string format = "{0}\t{1}";


                // Compare output:
                Console.WriteLine("\nQUERY: \tSELECT Id FROM dbo.Programmer WHERE Id = 1\n");
                Console.WriteLine(format, nameof(fromSQLRaw),fromSQLRaw.Count());
                Console.WriteLine(format, nameof(fromSQLRaw), fromSQLRaw.Count());
                Console.WriteLine(format, nameof(enumerableInt), enumerableInt.Count());
                Console.WriteLine(format, nameof(firstOrDefault), firstOrDefault.Id);
                Console.WriteLine(format, nameof(onDatabase), onDatabase.Count());
          

                /*
                    NOTE

                    When returning non entity types you have to add the alias "Value"
                    for the output column name. This is to enable EF Core

                    Microsoft.Data.SqlClient.SqlException: 'Invalid column name 'Value'.
                    Invalid column name 'Value'.
                    Invalid column name 'Value'.' 

                    Read for information: https://learn.microsoft.com/en-us/ef/core/querying/sql-queries#querying-scalar-non-entity-types
                */

                // This will work without AS [Value] declaration (no subquery)
                var SqlQueryIdCount = context.Database
                    .SqlQuery<int>($"SELECT Id FROM dbo.Programmer")
                    .ToList().Count();
   
                // This will only work with output column alias AS [Value]
                var SqlQueryMaxId = context.Database
                    .SqlQuery<int>($"SELECT Id as [Value] FROM dbo.Programmer")
                    .Where(id => id == context.Programmers.Max(p => p.Id)); // results in subquery 

                /*
                    If you configure you DbContext to use: optionsBuilder.LogTo(Console.WriteLine); 
                    You can see that EF core generates the following query with subqueries

                    SELECT COUNT(*)
                    FROM (
                    SELECT Id as [Value] FROM dbo.Programmer) as [t]
                    WHERE [t].Value = (
                    SELECT Max([p].[Id])
                    FROM Programmer AS p)

                 */

                var aggregateCount = context.Database
                    .SqlQuery<int>($"SELECT COUNT(Id) AS [Value] FROM dbo.Programmer");

                Console.WriteLine(format,nameof(aggregateCount), aggregateCount.Count());
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                Console.Clear();


                /*
                    LIMITATIONS WHEN RETURNING ENTITY TYPES FROM QUERIES   

                    There are a few limitations to be aware of when returning entity types from SQL queries:

                    - The SQL query must return data for all properties of the entity type.
                    - The column names in the result set must match the column names that properties are mapped to. 
                    Note that this behavior is different from EF6; EF6 ignored property-to-column mapping for SQL queries, 
                    and result set column names had to match those property names.
                    - The SQL query can't contain related data. However, in many cases you can compose on top of the query 
                    using the Include operator to return related data (see Including related data). 
                    
                    https://learn.microsoft.com/en-us/ef/core/querying/sql-queries#limitations
                 
                */

                //TABLE COLUMNS
                format = "{0}\t{1}";
                Console.WriteLine(format, "ID", "NAME");
                

                // Lets look at different ways to handle the data returned
                stopwatch.Start();
                var programmers = from p in context.Programmers
                                  orderby p.Name
                                  select p;
                stopwatch.Stop();
                intervals.Add(new { Operation = "db call: IOrderedQueryable", Time = stopwatch.ElapsedMilliseconds.ToString() });

                stopwatch.Restart();
                using (var pEnumerator = programmers.GetEnumerator())
                {
                    // While there was a "next element" in the collection
                    while (pEnumerator.MoveNext())
                    {
                        // now empEnumerator.Current is the Employee instance without casting
                        Programmer currentElement = pEnumerator.Current;
                        Console.WriteLine(format, currentElement.Id, currentElement.Name);

                    }
                }
                stopwatch.Stop();
                intervals.Add(new { Operation = "IEnumerator while loop     ", Time = stopwatch.ElapsedMilliseconds.ToString() });
                Thread.Sleep(500);
                Console.Clear();

                stopwatch.Restart();
                using (var pEnumerator = programmers.GetEnumerator())
                {
                    foreach (var p in programmers)
                    {
                        Console.WriteLine(format, p.Id, p.Name);
                    }
                }
                stopwatch.Stop();
                intervals.Add(new { Operation = "IEnumerator foreach loop", Time = stopwatch.ElapsedMilliseconds.ToString() });
                Thread.Sleep(500);
                Console.Clear();


                stopwatch.Restart();
                programmers.ToList().ForEach(p => Console.WriteLine(format, p.Id, p.Name));
                stopwatch.Stop();
                intervals.Add(new { Operation = "List<Programmers>.ForEach", Time = stopwatch.ElapsedMilliseconds.ToString() });
                Thread.Sleep(500);
                Console.Clear();
            }

            using (var context = new CodeFirstContext())
            {
                stopwatch.Restart();
                // Create a list from query result
                var listOfProgrammers = (from p in context.Programmers
                                            orderby p.Name
                                            select p).ToList();
                stopwatch.Stop();
                intervals.Add(new { Operation = "List<Programmers>.ForEach", Time = stopwatch.ElapsedMilliseconds.ToString() });
                Thread.Sleep(500);
                Console.Clear();

                stopwatch.Restart();
                listOfProgrammers.ForEach(p => Console.WriteLine("{0}\t{1}", p.Id, p.Name));
                stopwatch.Stop();
                intervals.Add(new { Operation = "ToList().ForEach()\t", Time = stopwatch.ElapsedMilliseconds.ToString()});
                Thread.Sleep(500);
                Console.Clear();


            }

            // Note that for each time we run the application, SQL Server will learn and optimise query caching
            intervals.ForEach(i => Console.WriteLine("\n{0}\t\t{1}", i.Operation, i.Time));
            // In conclusion, .Net 7 has brought about some welcome changes: LINQ is much more efficient and performant. Using List<T> is now tied or even faster than options.

        }
```
>**Note**
> Don't fortget to try using `optionsBuilder.LogTo(Console.WriteLine);` in the  `OnConfiguring` method in your context class, to see EF Core SQL query generation 

```sql
 -- =============================
 -- Scalar values and subqueries
 -- =============================
 
 /*
	NOTE

	When returning non entity types you have to add the alias "Value"
	for the output column name. This is to enable EF Core

	Microsoft.Data.SqlClient.SqlException: 'Invalid column name 'Value'.
	Invalid column name 'Value'.
	Invalid column name 'Value'.' 

	Read for information: https://learn.microsoft.com/en-us/ef/core/querying/sql-queries#querying-scalar-non-entity-types
           

	// This will work without AS [Value] declaration (no subquery)
	var SqlQueryIdCount = context.Database
	.SqlQuery<int>($"SELECT Id FROM dbo.Programmer")
	.ToList().Count();

	// This will only work with output column alias AS [Value]
	var SqlQueryMaxId = context.Database
	.SqlQuery<int>($"SELECT Id as [Value] FROM dbo.Programmer")
	.Where(id => id == context.Programmers.Max(p => p.Id)); // results in subquery

*/

-- QUERY GENERATED BY EF Core
SELECT COUNT(*)
FROM (
	SELECT Id as [Value] FROM dbo.Programmer) as [t]
WHERE [t].Value = (
	SELECT Max([p].[Id])
	FROM Programmer AS p)

-- Configure DbContext to log to console: optionsBuilder.LogTo(Console.WriteLine);

-- subuey example
SELECT * FROM dbo.Team
WHERE Id = (SELECT Id FROM dbo.Programmer WHERE Id = 1)
```
