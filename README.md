# Diversity4TechSkandia

## Team

|team |member|
|-----|-------|
|1| Issa      |
|1  |Kristian |
|1  |Nina      |
|1  |Elida     |
|2 |Viktor     |
|2 |Karin      |
|2 |Elsa       |
|ABC# |Caroline   |
|ABC# |Abel       |
|ABC# |Bobo       |
|4 |Susanna    |
|4 |Oliver T   |
|4 |Oliver U   |


## B2L4 

**Att göra**
- [ ] Arbeta tillsammans i era grupper, stötta och dela kunskap.
- [ ] Komplettera den nya code first databasen med egna klasser (ex Room, Lecture, Teacher) eller bygg vidare på egna idér ni har kring den slutgiltiga produkten 
      (SQL server databas + ASP.NET WebAPI + React GUI).
- [ ] Utforska query och method syntaxen. "Include" (joins) kommer vi dock täcka in först i nästa block.
- [ ] Försök skapa pch migrera en stored proceedure som ni anropar från er kod, för att "seeda" respektive tabell e.g. `spSeedProgrammers`.
**Lärandemål**
- Kunna skapa en connection string för code first migrations där databasen ännu inte existerar
- Kunna använda data annotationer för att definiera relationen mellan tabeller och ange "constraints" 
- Kunna deklarera properties beroende på om de är NULL (optional) , NOT NULL (required), med `<typ>?`, `=null!` eller initialisering.
- Kunna utföra CRUD (Create, Read, Update, Delete) operationer med LINQ
Lycka till! 🙂  

## B2L3 

**Att göra**
- [ ] Arbeta tillsammans i era grupper, stötta och dela kunskap.
- [ ] Utgå från de tabeller ni tidigare skapat och "reverse engineer" er databas. Inkludera `-DataAnnotations` 
```pwsh
# Tips: Använd Get-Help för de olika cmdlets
Get-Help Scaffold-DbContext
```
- [ ] Ta sedan bort den befintliga databasen och återskapa den genom att applicera migrationsfilen `InitialCreate`.
- [ ] Försök sedan att skapa stored procedures som ni anropar från applikationen. Prova gärna både att skapa dem via migration files så väl som genom SSMS.
- [ ] Prova att seeda databasen med `.FromSqlRaw` och anropa även era stored procedures.
- [ ] Till er hjälp har ni era kodanteckningar, ytterligare material i `B2L3` samt länkar i ppt för bra referensmaterial.
Lycka till! 🙂  
  
## B2L2 - Database Design & Normalisation

**Att göra**
- [ ] Dagens övning går ut på att normalisera de tabeller ni skapat till 3NF. Diskutera tillsammans, avnänd gärna "database diagrams" för att snabbt skapa upp och illustrera relationen mellan tabeller. Syftet är att tillsammans förbättra er förståelse och förmåga gällande koncepten som introducerades under dagens föreläsing. 
Lycka till! 🙂  

Till er hjälp finns följande resurser och länkar i PPT
- [Normalisation](https://learn.microsoft.com/en-us/office/troubleshoot/access/database-normalization-description)
- [PK, FK, Relationships](https://learn.microsoft.com/en-us/sql/relational-databases/tables/create-foreign-key-relationships?view=sql-server-ver16)
- [wc3schools: SQL Tutorial](https://www.w3schools.com/sql/default.asp)
- [MS Learn: Create & Query Database](https://learn.microsoft.com/en-us/sql/t-sql/lesson-1-creating-database-objects?view=sql-server-ver16#create-a-database)
- [MS Learn: Getting started with T-SQL](https://learn.microsoft.com/en-us/training/paths/get-started-querying-with-transact-sql/)


## B2L1 - Intro, Queries

**Att göra**
- [ ] Skapa egna tabeller och data i SSMS med syfte att förbättra er förståelse för T-SQL queries. Utgå från det vi lyft under dagens lektion och ta hjälp av refefrensmaterial nedan listat. Ha gärna slutprojektet (fullstack applikationen) i åtanke när ni tillsammans diskuterar vilka tabeller ni vill skapa. Se er nuvarande databas som en "grov skiss". Nästa lektion fördjupar vi oss ännu mer i databas design med bland annat normalisering. Lycka till! 🙂  

Till er hjälp finns följande resurser:
  - [wc3schools: SQL Tutorial](https://www.w3schools.com/sql/default.asp)
  - [MS Learn: Create & Query Database](https://learn.microsoft.com/en-us/sql/t-sql/lesson-1-creating-database-objects?view=sql-server-ver16#create-a-database)
  - [MS Learn: Getting started with T-SQL](https://learn.microsoft.com/en-us/training/paths/get-started-querying-with-transact-sql/)


## B1L5 - Objektorienterad Programmering

**Att göra**
- [ ] Dagens övning går ut på att fördjupa er förståelse om hur ni skriver defensiv kod, samt tillämpar OOP & SOLID principerna. Refaktorera era tidigare projekt utifrån vad ni lärt er under dagens föreläsning. Alternativt refaktorera den kod som ligger B1-5. Förhoppningen är att ni både ska få tillfälle att arbeta fram en djupare förståelse och även upptäcka hur mycket ni redan kan om C# & .NET, jämfört med kursstart! 🙂
- [ ] Om ni har tid över, fortsätt gärna att bekanta er med Microsoft Docs på dagens teman: [exceptions](https://learn.microsoft.com/en-us/dotnet/api/system.exception?view=net-7.0) & [architectural principles](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#single-responsibility)
- [ ] Vi kommer repetera och återbesöka många av dessa koncept under framtida block, Bra kämpat med första blocket! 😃: 

## B1L4 - Objektorienterad Programmering

**Att göra**
- [ ] Genomför mob programmeringsuppgiften (i B1L4 mappen) i era team. Syftet är att bygga en förståelse för de fyra grundläggande principerna för OOP och hur ni kan modellera verkligheten med klasser.  
- [ ] Om ni har tid över, fortsätt att bekanta er med [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop)
- [ ] Vi kommer repetera och återbesöka många av dessa moment under framtida block, förståelsen kommer växa fram över tid :smiley: 

## B1L3 - Metoder

**Att göra**
- [ ] Genomför mob programmeringsuppgiften (i B1L3 mappen) i era nya team (via Live share och/eller tillsammans vid en dator). Syftet är att repetera grunderna & dela med er av era kunskaper i teamen för en jämnare kunskapsnivå inför kommande block. När ni försöker förklara koncept för varandra kommer ni upptäcka om/var kunskapsluckor finns även hos er själva. :-) 
- [ ] Tillämpa DRY & WET principerna för att refaktorera koden, bryt ut i methoder och deklarera Access modifier i striktaste möjliga mån, för övnings skull.  
- [ ] Bekanta er med Microsoft Docs & Learn; lär er navigera dokumentationen och förbättra/fördjupa er förståelse kring de ämnen vi gått igenom och angränsande ämnen i mån av tid. Se tips och länkar i Presentationen från B1L1. Ett bra ställe att börja: [methods](https://learn.microsoft.com/en-us/dotnet/csharp/methods)
- [ ] NEED TO KNOW vs NICE TO KNOW: Kom ihåg! Det är *nice* att veta mycket men the *need* är att veta vad/område vi behöverfärskaupp/lära oss mer om för att hitta en lösning på ett problem. Google är en programmerares bästa vän, ni kommer inte kunna memorisera all syntax (endast de saker ni aktivt arbetar med för studen). Sträva efter att förstå koncepten, principerna och hur ni navigerar dem :-) 
- [ ] Träna på att använda debuggern (F10,F11) för att förstå kotrollflödet och observera Autos & Locals

## B1L2 - Grunder fortsättning

**Att göra**
- [ ] genomför [tutorial ](https://www.w3schools.com/cs/cs_operators_comparison.php) avsnitten operators t.o.m Arrays  
- [ ] genomför övningsmodulerna 5-8 [Take your first steps with c#](https://learn.microsoft.com/en-us/training/paths/csharp-first-steps/)
- [ ] Skapa en enkel C# ConsoleApp: som föreläsare vill jag kunna ange antal kursdeltagare samt antal team att slumpmässigt fördela deltagarna över så att vi kan komma igång med mobprogrammering nästa träff!
- [ ] se även länkar i B1L2 projekten som hänvisar till officiella dokumentationen.


## B1L1 - Intro & Grunder C#

**Att göra**
- [ ] genomför [Tutorial övningar](https://www.w3schools.com/cs/index.php) till och med "operators"
- [ ] genomför övningsmodulerna 1-4 [Take your first steps with C#](https://learn.microsoft.com/en-us/training/paths/csharp-first-steps/)
- [ ] *Om du hinner*: fortsätt med modulerna 5-8 som vi går igenom under pass B1L2 och se länkar/tips i presentationen.
