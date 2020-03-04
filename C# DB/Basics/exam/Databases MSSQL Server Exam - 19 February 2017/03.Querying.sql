--Section 3. Querying (40 pts)

USE Bakery

--5. Products by Price

SELECT [Name], Price, [Description] 
FROM Products
ORDER BY Price DESC, [Name]

--6. Ingredients

SELECT [Name], [Description], OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id

--7. Ingredients from Bulgaria and Greece

SELECT TOP 15 i.[Name], i.[Description], c.[Name] AS CountryName
FROM Ingredients AS i
JOIN Countries AS c ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY  [Name], CountryName

--8. Best Rated Products

SELECT TOP 10 p.[Name], p.[Description], 
AVG(f.Rate) AS AverageRate, COUNT(f.Id) AS FeedbacksAmount
FROM Products AS p
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY p.[Name], p.[Description]
ORDER BY AverageRate DESC, FeedbacksAmount DESC

--9. Negative Feedback

SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON(f.CustomerId = c.Id)
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate

--10. Customers without Feedback ***

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, c.PhoneNumber, c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id

--11. Honorable Mentions

SELECT f.ProductId, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
f.[Description] AS FeedbackDescription
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE c.Id IN (
	SELECT CustomerId
	FROM Feedbacks AS f
	GROUP BY CustomerId
	HAVING COUNT(f.Id) >= 3
)
ORDER BY f.ProductId, CustomerName, f.Id

--12. Customers by Criteria

SELECT FirstName, Age, PhoneNumber
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR
(PhoneNumber LIKE '%38' AND co.Name != 'Greece')
ORDER BY FirstName, Age DESC

--13. Middle Range Distributors

SELECT d.[Name] AS DistributorName, i.[Name] AS IngredientName,
p.[Name] AS ProductName, AVG(f.Rate) AS AverageRate
FROM Distributors AS d
JOIN Ingredients AS i ON d.Id = i.DistributorId
JOIN ProductsIngredients AS [pi] ON i.Id = [pi].IngredientId
JOIN Products AS p ON [pi].ProductId = p.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.[Name], IngredientName, ProductName

--14. The Most Positive Country

SELECT TOP (1) WITH TIES
c.[Name] AS CountryName, AVG(f.Rate) AS FeedbackRate
FROM Countries AS c
JOIN Customers AS cu ON c.Id = cu.CountryId
JOIN Feedbacks AS f ON cu.Id = f.CustomerId
GROUP BY c.[Name]
ORDER BY FeedbackRate DESC

--15. Country Representative

SELECT c.[Name] AS CountryName, d.[Name] As DistributorName
FROM Countries AS c
JOIN Distributors AS d ON c.Id = d.CountryId
WHERE d.Id IN (SELECT DistributorId FROM
(	
	SELECT DistributorId, 
		DENSE_RANK() OVER(PARTITION BY CountryId ORDER BY IngredientCount DESC) AS [Rank]
	FROM (
		SELECT c.Id AS CountryId, d.Id AS DistributorId, COUNT(i.Id) AS IngredientCount
		FROM Distributors AS d
		JOIN Ingredients AS i ON d.Id = i.DistributorId
		JOIN Countries AS c ON d.CountryId = c.Id
		GROUP  BY d.Id, c.Id
	) AS DistIngrCount
) AS RankedDistributors
WHERE [Rank] = 1)
ORDER BY CountryName, DistributorName



