--Part I – Queries for SoftUni Database

--Problem 1. Employees with Salary Above 35000

USE SoftUni

GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName AS "First Name", LastName AS "Last Name"
	FROM Employees
	WHERE Salary > 35000
GO
EXEC usp_GetEmployeesSalaryAbove35000

--Problem 2. Employees with Salary Above Number

GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS   
	SELECT FirstName AS "Fist Name", LastName AS "Last Name"   
	FROM Employees   
	WHERE Salary >= @number
GO 
EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Problem 3. Town Names Starting With

GO
CREATE PROC usp_GetTownsStartingWith(@text VARCHAR(15))  
AS   
	SELECT Name   
	FROM Towns   
	WHERE Name LIKE @text + '%'
GO
EXEC usp_GetTownsStartingWith 'b'

--Problem 4. Employees from Town

GO
CREATE PROC usp_GetEmployeesFromTown(@town_name VARCHAR(15))  
AS   
	SELECT FirstName AS "Fist Name", LastName AS "Last Name"   
	FROM Employees AS e   
	JOIN Addresses AS a ON e.AddressID = a.AddressID   
	JOIN Towns AS t ON a.TownID = t.TownID   
	WHERE t.Name = @town_name
GO
EXEC usp_GetEmployeesFromTown 'Sofia'

--Problem 5. Salary Level Function

GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary money)
RETURNS varchar(10)
AS  
BEGIN
  DECLARE @salaryLevel varchar(10) = 'High';
  IF(@salary < 30000)       SET @salaryLevel = 'Low';
  ELSE IF(@salary <= 50000) SET @salaryLevel = 'Average';
  RETURN @salaryLevel;
END
GO

SELECT Salary, 
  dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees
ORDER BY Salary DESC

--Problem 6. Employees by Salary Level

GO
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))  
AS   
	SELECT FirstName AS "First Name", LastName AS "Last Name"   
	FROM Employees   
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO
EXEC usp_EmployeesBySalaryLevel 'High'

--Problem 7. Define Function

GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))  
RETURNS BIT  
AS  
BEGIN   
	DECLARE @currentLetter CHAR;   
	DECLARE @counter INT = 1;   
	WHILE(LEN(@word) >= @counter)   
	BEGIN    
		SET @currentLetter = SUBSTRING(@word, @counter, 1);    
		DECLARE @match INT = CHARINDEX(@currentLetter, @setOfLetters);
		
		IF(@match = 0)   
		BEGIN     
			RETURN 0;    
		END;
		
		SET @counter = @counter + 1;   
	END;   
	RETURN 1;  
END;
GO
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

--Problem 8. * Delete Employees and Departments

GO
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL;

	UPDATE Departments
		SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)

	UPDATE Employees
		SET ManagerID = NULL
	WHERE ManagerID IN (
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId;

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId;

	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
END;
GO
EXEC usp_DeleteEmployeesFromDepartment 1;

--PART II – Queries for Bank Database

--Problem 9. Find Full Name

USE Bank

GO
CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS "Full Name"
	FROM AccountHolders
GO
EXEC usp_GetHoldersFullName

--Problem 10. People with Balance Higher Than

-- 80/100
--GO
--CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number INT)
--AS
--	SELECT FirstName AS "First Name", LastName AS "Last Name"
--	FROM AccountHolders AS ah
--	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
--	GROUP BY FirstName, LastName
--	HAVING SUM(Balance) > @number
--GO

-- 100/100
GO
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@minBalance money)
AS
BEGIN
	WITH CTE_MinBalanceAccountHolders (HolderId) AS (
		SELECT AccountHolderId FROM Accounts
		GROUP BY AccountHolderId
		HAVING SUM(Balance) > @minBalance
	)
	SELECT ah.FirstName AS "First Name", ah.LastName AS "Last Name"
	FROM CTE_MinBalanceAccountHolders AS minBalanceHolders
	JOIN AccountHolders AS ah ON ah.Id = minBalanceHolders.HolderId
	ORDER BY ah.LastName, ah.FirstName
END
GO
EXEC usp_GetHoldersWithBalanceHigherThan 6000000;

--Problem 11. Future Value Function

GO
CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS MONEY
AS
BEGIN
	RETURN @sum *  POWER(1 + @yearlyInterestRate, @numberOfYears)
END
GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--Problem 12. Calculating Interest

GO
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
	SELECT a.Id AS "Account Id", ah.FirstName AS "First Name", ah.LastName AS "Last Name",
	a.Balance AS "Current Balance", "Balance in 5 years" = dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON(a.AccountHolderId = ah.Id)
	WHERE a.Id = @accountId
EXEC usp_CalculateFutureValueForAccount 1, 0.1
 
--PART III – Queries for Diablo Database

--Problem 13. *Scalar Function: Cash in User Games Odd Rows

USE Diablo

GO
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS SumCash FROM (
			SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNum
			FROM UsersGames AS ug
			JOIN Games AS g ON g.Id = ug.GameId
			WHERE g.Name = @gameName ) AS CashList
		WHERE RowNum % 2 = 1;
GO
SELECT * FROM ufn_CashInUsersGames('Lily Stargazer')