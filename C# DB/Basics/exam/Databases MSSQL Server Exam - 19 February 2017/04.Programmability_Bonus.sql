--Section 4. Programmability (20 pts)
USE Bakery

--16. Customers with Countries
GO
CREATE VIEW v_UserWithCountries
AS
SELECT 
CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, c.Age,
c.Gender, co.[Name] AS CountryName
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id
GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--17. Feedback by Product Name
GO
CREATE FUNCTION udf_GetRating(@productName VARCHAR(15))
RETURNS VARCHAR(15)
AS
BEGIN
	DECLARE @result VARCHAR(15)
	SET @result =
	(
		SELECT
			CASE
				WHEN AVG(f.Rate) < 5 THEN 'Bad'
				WHEN AVG(f.Rate) BETWEEN 5 AND 8 THEN 'Average'
				WHEN AVG(f.Rate) > 8 THEN 'Good'
				ELSE 'No rating'
			END
		FROM Feedbacks AS f
		JOIN Products AS p ON f.ProductId = p.Id
		WHERE p.[Name] = @productName
	)
	RETURN @result
END
GO

SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

--18. Send Feedback -- CHECK
GO
CREATE PROC usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL(4,2), @description NVARCHAR(255))
AS
BEGIN
	BEGIN TRANSACTION
		INSERT INTO Feedbacks (CustomerId, ProductId, Rate, [Description])
		VALUES(@customerId, @productId, @rate, @description)
		DECLARE @feedbackCount INT = (
			SELECT COUNT(f.Id)
			FROM Feedbacks AS f
			WHERE ProductId = @productId AND CustomerId = @customerId)
		IF @feedbackCount > 3
		BEGIN
			ROLLBACK
			RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		END
		ELSE
			COMMIT
END
GO

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

--19. Delete Products

GO
CREATE TRIGGER tr_DeleteProduct ON Products INSTEAD OF DELETE
AS
	DECLARE @productId INT = 
	(
		SELECT Id
		FROM deleted
	)

	DELETE FROM Feedbacks
	WHERE ProductId = @productId

	DELETE FROM ProductsIngredients
	WHERE ProductId = @productId

	DELETE FROM Products
	WHERE Id = @productId
GO
DELETE FROM Products WHERE Id = 7

--20. Products by One Distributor - BONUS

WITH CTE AS (
	SELECT p.Id AS ProductId,
	p.[Name] AS ProductName, AVG(f.Rate) AS ProductAverageRate,
	d.[Name] AS DistributorName, c.[Name] AS DistributorCountry
	FROM Products AS p
	JOIN Feedbacks AS f ON p.Id = f.ProductId
	JOIN ProductsIngredients AS [pi] ON p.Id = pi.ProductId
	JOIN Ingredients AS i ON [pi].IngredientId = i.Id
	JOIN Distributors AS d ON i.DistributorId = d.Id
	JOIN Countries AS c ON d.CountryId = c.Id
	GROUP BY p.[Name], d.[Name], c.[Name], p.Id)
SELECT CTE.ProductName, ProductAverageRate, DistributorName, DistributorCountry
FROM CTE
JOIN (
	SELECT ProductName, COUNT(DistributorName) AS DistributorCount
	FROM CTE
	GROUP BY ProductName
) AS DistributorCount ON CTE.ProductName = DistributorCount.ProductName
WHERE DistributorCount = 1
ORDER BY ProductId




