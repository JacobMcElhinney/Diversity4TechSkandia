-- ===========================================
--	Database First Approach
-- ===========================================

/*
	INSTRUCTIONS
	- Connect to server: (localdb)\MSSQLLocalDB
	- then press F5 to execute all
*/

-- CREATE & CONNECT TO DATABASE

CREATE DATABASE DatabaseFirst
GO

Use DatabaseFirst
GO

/*
	CUSTOMER TABLE NOT IN 3NF

	EXCEPTION: Adhering to the third normal form, while theoretically desirable, is not always practical. 
	If you have a Customers table and you want to eliminate all possible interfield dependencies, 
	you must create separate tables for cities, ZIP codes, sales representatives, customer classes, 
	and any other factor that may be duplicated in multiple records. In theory, normalization is worth pursing. 
	However, many small tables may degrade performance or exceed open file and memory capacities.
	
	Source: https://learn.microsoft.com/en-us/office/troubleshoot/access/database-normalization-description#third-normal-form
*/

-- CREATE TABLES

CREATE TABLE dbo.Customer
(
	CustomerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName varchar(25) NOT NULL,
	LastName varchar(25) NOT NULL,
	StreetAddress varchar(50) NOT NULL,
	City varchar(25) NOT NULL,
	StateOrProvince varchar(25) NOT NULL,
	Country varchar(50) NOT NULL,
	PostalCode int NOT NULL,
	Phone int NULL,
	Email varchar(50) NOT NULL
)
GO

CREATE TABLE dbo.Product
(
	ProductID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL,
	Price money NOT NULL
)
GO

CREATE TABLE dbo.[Order]
(
	OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	OrderPlaced datetime NOT NULL,
	OrderFulfilled datetime NOT NULL,
	CustomerID int NOT NULL,
	FOREIGN KEY (CustomerID) REFERENCES dbo.Customer (CustomerID)
	ON DELETE CASCADE -- row to be deleted in child (this table) when parent is deleted
	ON UPDATE CASCADE -- row to be updated in child when parent is updated
)
GO

-- Junction table to account for the n:n relationship between Product and Order
CREATE TABLE dbo.ProductOrder
(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Quantity int NOT NULL,
	ProductID int NOT NULL,
	OrderID int NOT NULL,
	FOREIGN KEY (ProductID) REFERENCES dbo.[Product] (ProductID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (OrderID) REFERENCES dbo.[Order] (OrderID)
	ON DELETE CASCADE 
	ON UPDATE CASCADE
)
GO

-- SEED DATABASE

INSERT INTO dbo.Customer
	VALUES
		('John', 'Smith','SnowStreet 34', 'Luleå', 'Norrbotten','Sweden', '97231', '0731740275', 'john.smith@company.se' ),
		('Jane', 'Johnsson','NoSnowStreet 113', 'Solna', 'Stockholm','Sweden', '16956', '0762973447', 'jane.johnsson@gmail.com')
GO

INSERT INTO dbo.Product
	VALUES 
		('Towel', '350'),
		('Pillow', '525'),
		('Rug', '534'),
		('Umbrella', '250')
GO

INSERT INTO dbo.[Order]
	VALUES 
		('2023-01-01', '2023-01-09', 1),
		('2023-01-02', '2023-01-12', 2),
		('2023-01-03', '2023-01-13', 1),
		('2023-01-09', '2023-01-17', 1)
GO

INSERT INTO dbo.ProductOrder
	VALUES
		(1, 1, 1),
		(1, 2, 2),
		(4, 3, 2),
		(2, 4, 2),
		(1, 1, 2),
		(2, 2, 2),
		(1, 3, 1),
		(1, 3, 1)
GO


/*
	GENERATE SQL QUERIES AND STORE CUSTOM VIEWS

	You can generate custom views that you can store

	DatabaseFirst > "right-click" Views > New View > Add desired tables > check columns to include in query
*/

-- CUSTOM QUERY
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Customer, COUNT(o.OrderID) AS TotalOrders
FROM dbo.Customer AS c 
	INNER JOIN dbo.[Order] AS o ON c.CustomerID = o.CustomerID
GROUP BY c.FirstName, c.LastName
GO

-- MODIFIED VIEW QUERY
SELECT        dbo.Customer.FirstName, dbo.Customer.LastName, dbo.Product.Name AS ProductName, dbo.ProductOrder.Quantity
FROM            dbo.Customer INNER JOIN
                         dbo.[Order] ON dbo.Customer.CustomerID = dbo.[Order].CustomerID INNER JOIN
                         dbo.ProductOrder ON dbo.[Order].OrderID = dbo.ProductOrder.OrderID INNER JOIN
                         dbo.Product ON dbo.ProductOrder.ProductID = dbo.Product.ProductID
ORDER BY LastName ASC;
GO

-- VIEW QUERY RETURNING ALL DATA
SELECT        dbo.Customer.*, dbo.[Order].*, dbo.Product.*, dbo.ProductOrder.*
FROM            dbo.Customer INNER JOIN
                         dbo.[Order] ON dbo.Customer.CustomerID = dbo.[Order].CustomerID INNER JOIN
                         dbo.ProductOrder ON dbo.[Order].OrderID = dbo.ProductOrder.OrderID INNER JOIN
                         dbo.Product ON dbo.ProductOrder.ProductID = dbo.Product.ProductID
ORDER BY dbo.Customer.CustomerID ASC;
GO

-- VIEWS: Try creating your own views and save them to DB.
-- DATABASE DIAGRAMS: Try creating a database diagram to better understand the relationships between tables