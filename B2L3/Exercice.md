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
- [ ] Till er hjälp har ni era kodanteckningar samt länkar i ppt för bra referensmaterial.
Lycka till! 🙂  
