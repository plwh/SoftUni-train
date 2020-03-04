--5. Clients by Name

USE WMS

SELECT FirstName, LastName, Phone
FROM Clients
ORDER BY LastName, ClientId

--6. Job Status

SELECT [Status], IssueDate
FROM Jobs
WHERE [Status] = 'In Progress'
ORDER BY IssueDate, JobId

--7. Mechanic Assignments

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.[Status], j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--8. Current Clients

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going], j.[Status]
FROM Clients AS c
JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.Status != 'Finished'

--9. Mechanic Performance

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), j.MechanicId
ORDER BY j.MechanicId

--10. Hard Earners

SELECT TOP 3 CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
COUNT(j.JobId) AS Jobs
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] != 'Finished'
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), j.MechanicId
HAVING COUNT(j.JobId) > 1
ORDER BY Jobs DESC, j.MechanicId

--11. Available Mechanics

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished' OR j.MechanicId IS NULL
ORDER BY j.MechanicId

--12. Parts Cost

SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
FROM Parts AS p
JOIN OrderParts AS op ON p.PartId = op.PartId
JOIN Orders AS o ON op.OrderId = o.OrderId
WHERE o.IssueDate > (DATEADD(WEEK, -3 , '2017/04/24'))

--13. Past Expenses

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs AS j
FULL JOIN Orders AS o ON j.JobId = o.JobId
FULL JOIN OrderParts AS op ON o.OrderId = op.OrderId
FULL JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--14. Model Repair Time

SELECT m.ModelId, m.[Name],
CONCAT(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)), ' ', 'days') AS [Average Service Time]
FROM Models AS m
JOIN Jobs AS J on m.ModelId = j.ModelId
GROUP BY m.ModelId, m.[Name]
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))

--15. Faultiest Model

SELECT TOP 1 WITH TIES m.[Name], COUNT(*) AS [Times Serviced],
(
	SELECT ISNULL(SUM(p.Price * op.Quantity), 0) FROM Jobs AS j
	JOIN Orders AS o ON j.JobId = o.OrderId
	JOIN OrderParts AS OP on o.OrderId = op.OrderId
	JOIN Parts AS p ON op.PartId = p.PartId
	WHERE j.ModelId = m.ModelId
) AS [Parts Total]
FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.[Name]
ORDER BY [Times Serviced] DESC

--16. Missing Parts

SELECT p.PartId, p.[Description], SUM(pn.Quantity) AS 'Required',
AVG(p.StockQty) AS [In Stock], ISNULL(SUM(op.Quantity),0) AS [Ordered]
FROM Parts AS p
JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.[Status] != 'Finished'
GROUP BY p.PartId, p.[Description], p.StockQty
HAVING SUM(pn.Quantity) > AVG(p.StockQty) + ISNULL(SUM(op.Quantity),0)
ORDER BY p.PartId
