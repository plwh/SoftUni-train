--5. Users by Age

USE ReportService

SELECT Username, Age
FROM Users
ORDER BY Age, Username DESC

--6. Unassigned Reports

SELECT r.[Description], r.OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate, r.[Description]

--7. Employees & Reports

SELECT e.FirstName, e.LastName, r.[Description], FORMAT(R.OpenDate, 'yyyy-MM-dd') AS OpenDate
FROM Employees AS e
JOIN Reports AS r ON e.Id = r.EmployeeId
WHERE r.EmployeeId IS NOT NULL
ORDER BY r.EmployeeId, r.OpenDate, r.Id

--8. Most reported Category

SELECT c.[Name] AS CategoryName, COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

--9. Employees in Category

SELECT c.[Name] AS CategoryName, COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
JOIN Departments AS d ON(c.DepartmentId = d.Id)
JOIN Employees AS e ON(d.Id = e.DepartmentId)
GROUP BY c.[Name]
ORDER BY CategoryName

--10. Users per Employee

SELECT CONCAT(e.FirstName, ' ',  e.LastName) AS [Name], COUNT(DISTINCT r.UserId) AS [Users Number]
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY CONCAT(e.FirstName, ' ',  e.LastName)
ORDER BY [Users Number] DESC, [Name]

--11. Emergency Patrol

SELECT r.OpenDate, r.[Description], u.Email
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
JOIN Departments AS d ON c.DepartmentId = d.Id
WHERE r.CloseDate IS NULL 
AND LEN(r.[Description]) > 20
AND r.[Description] LIKE '%str%'
AND d.[Name] IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate, u.Email, r.Id

--12. Birthday Report

SELECT DISTINCT c.[Name]
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
JOIN Users AS u ON r.UserId = u.Id
WHERE DAY(r.Opendate) = DAY(u.Birthdate)
	 AND MONTH(r.Opendate) = MONTH(u.Birthdate)
ORDER BY c.[Name]

--13. Numbers Coincidence

SELECT DISTINCT u.Username
FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE (Username LIKE '[0-9]_%' AND CAST(c.id as varchar) = LEFT(username, 1)) OR
      (Username LIKE '%_[0-9]' AND CAST(c.id as varchar) = RIGHT(username, 1))
ORDER BY u.Username

--14. Open/Closed Statistics

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
ISNULL(CONVERT(varchar, CC.ReportSum), '0') + '/' +
ISNULL(CONVERT(varchar, OC.ReportSum), '0') AS [Closed Open Reports]
FROM Employees AS e
JOIN (SELECT EmployeeId, COUNT(1) AS ReportSum
	  FROM Reports R
	  WHERE YEAR(OpenDate) = 2016
	  GROUP BY EmployeeId) AS OC ON OC.EmployeeId = e.Id
LEFT JOIN (SELECT EmployeeId, COUNT(1) AS ReportSum
		   FROM Reports R
		   WHERE YEAR(CloseDate) = 2016
		   GROUP BY EmployeeId) AS CC ON CC.EmployeeId = e.Id
ORDER BY [Name]

--15. Average Closing Time

SELECT
d.[Name] AS [Department Name], 
ISNULL(CONVERT(VARCHAR, AVG(DATEDIFF(DAY, R.Opendate, R.Closedate))), 'no info'
	  ) AS AverageTime
FROM Departments AS d
JOIN Categories AS c ON d.Id = c.DepartmentId
LEFT JOIN Reports AS r ON c.Id  = r.CategoryId
GROUP BY d.[Name]
ORDER BY d.[Name]

--16. Favorite Categories

SELECT
d.[Name] AS [Department Name], c.[Name] AS [Category Name],
COUNT(r.Id) AS [Percentage]
FROM Departments AS d
JOIN Categories AS c ON d.Id = c.DepartmentId
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY d.[Name], c.[Name]
ORDER BY [Department Name], [Category Name], [Percentage]






