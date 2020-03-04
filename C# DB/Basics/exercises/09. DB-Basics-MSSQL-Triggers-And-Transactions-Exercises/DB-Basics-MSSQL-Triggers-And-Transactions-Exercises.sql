--PART I – Queries for Bank Database

--Problem 1. Create Table Logs

USE Bank

CREATE TABLE Logs
(
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(5,2) NOT NULL,
	NewSum DECIMAL(8,2) NOT NULL
)

GO
CREATE TRIGGER tr_LogsUpdate ON Logs FOR UPDATE
AS
	BEGIN
	INSERT INTO Logs
	SELECT AccountId, OldSum, NewSum FROM inserted
	END
GO

INSERT INTO Logs
VALUES(1, 123.12, 113.12)

UPDATE Logs
SET OldSum = 2;

--Problem 3. Deposit Money

GO
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4 ))
AS
IF (@MoneyAmount >= 0)
BEGIN
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
END
GO

SELECT * FROM Accounts WHERE Id = 5
EXEC usp_DepositMoney 5, 1000

--Problem 4. Withdraw Money

GO
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4 ))
AS
IF (@MoneyAmount >= 0)
BEGIN
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
END
GO

SELECT * FROM Accounts WHERE Id = 5
EXEC dbo.usp_WithdrawMoney 5, 7000

--Problem 5. Money Transfer
GO
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
	DECLARE @senderBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts
		WHERE Id = @SenderId)
	IF @senderBalance < 0
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT TRANSACTION
GO

--PART II – Queries for Diablo Database

USE Diablo

--Problem 6. Trigger

--1
GO
CREATE TRIGGER tr_RestrictPurchase ON UserGameItems FOR INSERT
AS
BEGIN
	DECLARE @userGameLevel INT = (
		SELECT ug.Level
		FROM inserted AS ugi
		JOIN UsersGames AS ug ON ugi.UserGameId = ug.Id
		)
	DECLARE @itemMinLevel INT = (
		SELECT i.MinLevel
		FROM inserted AS ugi
		JOIN Items AS i ON ugi.ItemId = i.Id
		)
	IF(@itemMinLevel > @userGameLevel)
	BEGIN
		ROLLBACK;
		RAISERROR('User game level is not enough to purchase item' , 16, 1)
		RETURN
	END	
END
GO
INSERT INTO UserGameItems VALUES (1, 11) --itemMinLevel 24 --userGameLevel 20 - FAIL
INSERT INTO UserGameItems VALUES (11, 11) --itemMinLevel 18 --userGameLevel 20 - PASS

--2
UPDATE UsersGames
SET Cash += 50000
WHERE UserID IN
(
	SELECT ug.UserId
	FROM UsersGames AS ug
	JOIN Users AS u ON(ug.UserId = u.Id)
	JOIN Games AS g ON(ug.GameId = g.Id)
	WHERE u.Username IN ('baleremuda','loosenoise', 'inguinalself',
	'buildingdeltoid', 'monoxidecos') AND g.[Name] = 'Bali'
)

--3

--4
SELECT u.Username, g.[Name], ug.Cash, i.[Name] AS [Item Name]
FROM UsersGames AS ug
JOIN Users AS u ON(ug.UserId = u.Id)
JOIN Games AS g ON(ug.GameId = g.Id)
JOIN UserGameItems AS ugi ON(ug.Id = ugi.UserGameId)
JOIN Items AS i ON (ugi.ItemId = i.Id)
WHERE u.Username IN ('baleremuda','loosenoise', 'inguinalself',
'buildingdeltoid', 'monoxidecos') AND g.[Name] = 'Bali'
ORDER BY u.Username, [Item Name]

--Problem 7. *Massive Shopping

DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Stamat')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower')
DECLARE @userGameId INT = (SELECT Id From UsersGames WHERE UserId = @userId AND GameId = @gameId)

BEGIN TRY
BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel IN (11, 12))
	WHERE Id = @userGameId
	DECLARE @userBalance DECIMAL(15, 4) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
	IF @userBalance < 0
	BEGIN
		ROLLBACK
		RETURN
	END
	INSERT INTO UserGameItems
	SELECT Id, @userGameId FROM Items WHERE MinLevel IN (11, 12)
COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

BEGIN TRY
BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
	WHERE Id = @userGameId
	SET @userBalance  = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
	IF @userBalance < 0
	BEGIN
		ROLLBACK
		RETURN
	END
	INSERT INTO UserGameItems
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

SELECT i.[Name] AS [Item Name]
FROM Items AS i
JOIN UserGameItems AS u ON i.Id = u.ItemId
WHERE u.UserGameId = @usersGameId
ORDER BY [Item Name]

--Part III – Queries for SoftUni Database

--Problem 8. Employees with Three Projects

USE SoftUni

GO
CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT)
AS
BEGIN
	BEGIN TRANSACTION t1
		INSERT INTO EmployeesProjects
		VALUES (@employeeId, @projectId)
		IF((
			SELECT COUNT(ep.EmployeeId)
			FROM EmployeesProjects AS ep
			WHERE ep.EmployeeID = @employeeId
			) > 3)
		BEGIN
			ROLLBACK TRAN t1
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
	COMMIT TRANSACTION t1
END
GO
EXEC usp_AssignProject 1,5

--Problem 9. Delete Employees

CREATE TABLE Deleted_Employees
(
	EmployeeId INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	Salary MONEY NOT NULL
)

GO
CREATE TRIGGER tr_AddDeletedEmployees ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName,
			JobTitle, DepartmentID, Salary 
	FROM deleted
GO

DELETE FROM EmployeesProjects 
WHERE EmployeeID IN (
	SELECT ep.EmployeeID
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON (ep.EmployeeID = e.EmployeeID)
	WHERE FirstName = 'Guy'
)

DELETE FROM Employees
WHERE FirstName = 'Guy'