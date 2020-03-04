/* Part I – Queries for SoftUni Database */

/* Problem 1. Find Names of All Employees by First Name */

USE SoftUni

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE ('SA%')

/* Problem 2.   Find Names of All employees by Last Name  */

SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('ei', LastName) > 0

/* Problem 3. Find First Names of All Employees */

SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) 
AND DATEPART(YEAR, HireDate) >= 1995
AND DATEPART(YEAR, HireDate) <= 2005

--Problem 4. Find All Employees Except Engineers

SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

--Problem 5. Find Towns with Name Length

SELECT Name
FROM Towns
WHERE LEN(Name) IN (5, 6)
ORDER BY Name

--Problem 6.  Find Towns Starting With

SELECT TownId, Name
FROM Towns
WHERE SUBSTRING(Name, 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

--Problem 7.  Find Towns Not Starting With

SELECT TownId, Name
FROM Towns
WHERE SUBSTRING(Name, 1, 1) NOT IN ('R', 'B', 'D')
ORDER BY Name

--Problem 8. Create View Employees Hired After 2000 Year
GO

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

GO

SELECT * FROM V_EmployeesHiredAfter2000

--Problem 9. Length of Last Name

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--Part II – Queries for Geography Database 

--Problem 10. Countries Holding ‘A’ 3 or More Times

USE Geography

SELECT CountryName, IsoCode AS 'ISO Code'
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(Countryname,'A','')) >= 3
ORDER BY IsoCode

--Problem 11.  Mix of Peak and River Names

SELECT PeakName, RiverName, 
LOWER(CONCAT(PeakName, '', RIGHT(RiverName, LEN(RiverName)-1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

--Part III – Queries for Diablo Database

--Problem 12. Games from 2011 and 2012 year

USE Diablo

SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM Games
WHERE DATEPART(YEAR, Start) BETWEEN 2011 AND 2012
ORDER BY Start, Name

--Problem 13.  User Email Providers

SELECT Username, REPLACE(Email, SUBSTRING(Email, 1, CHARINDEX('@', Email)),'') AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

--Problem 14.  Get Users with IPAdress Like Pattern

SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--Problem 15.  Show All Games with Duration and Part of the Day

SELECT Name AS Game, "Part of the Day" =
	CASE
		WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) >= 18 AND DATEPART(HOUR, Start) < 24 THEN 'Evening'
	END, "Duration" =
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END
FROM Games
ORDER BY Name, Duration

--Part IV – Date Functions Queries

--Problem 16.  Orders Table

USE Orders

SELECT ProductName, OrderDate, 
DATEADD(DAY, 3, OrderDate) AS PayDue,
DATEADD(MONTH, 1, OrderDate) AS "Deliver Due"
FROM ORDERS

--Problem 17.  People Table

CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(10) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT Name, 
DATEDIFF(YEAR, Birthdate, GETDATE()) AS "Age in Years",
DATEDIFF(MONTH, Birthdate, GETDATE()) AS "Age in Months",
DATEDIFF(DAY, Birthdate, GETDATE()) AS "Age in Days",
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS "Age in Minutes"
FROM People



