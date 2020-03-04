--Problem 1. Employee Address

USE SoftUni

SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON (e.AddressID = a.AddressID)
ORDER BY e.AddressID

--Problem 2. Addresses with Towns

SELECT TOP 50 e.FirstName, e.LastName, t.Name AS Town, a.AddressText
FROM Employees as e
JOIN Addresses as a ON (e.AddressID = a.AddressID)
JOIN Towns as t ON(a.TownID = t.TownID)
ORDER BY e.FirstName, e.LastName

--Problem 3. Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
FROM Employees as e
JOIN Departments AS d ON (e.DepartmentID = d.DepartmentID)
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 4. Employee Departments

SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName
FROM Employees as e
JOIN Departments as d ON (e.DepartmentID = d.DepartmentID)
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--Problem 5. Employees Without Project

SELECT TOP 3 emp.EmployeeID, emp.FirstName
FROM Employees AS emp
LEFT JOIN EmployeesProjects AS ep ON (emp.EmployeeID = ep.EmployeeID)
WHERE ep.EmployeeID IS NULL
ORDER BY emp.EmployeeID

--Problem 6. Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
FROM Employees as e
JOIN Departments as d ON (e.DepartmentID = d.DepartmentID)
WHERE e.HireDate > '01.01.1999' AND
d.Name IN ('Sales', 'Finance')

--Problem 7. Employees with Project

SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep ON (e.EmployeeID = ep.EmployeeID)
JOIN Projects AS p ON (ep.ProjectID = p.ProjectID)
WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8. Employee 24

SELECT e.EmployeeID, e.FirstName, ProjectName =
CASE
	WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
	ELSE p.Name
END
FROM Employees AS e
JOIN EmployeesProjects AS ep ON (e.EmployeeID = ep.EmployeeID)
JOIN Projects AS p ON (ep.ProjectID = p.ProjectID)
WHERE e.EmployeeID = 24

--Problem 9. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
FROM Employees AS e
LEFT JOIN Employees AS m ON (m.EmployeeID = e.ManagerID)
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

--Problem 10. Employee Summary

SELECT TOP 50 e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
m.FirstName + ' ' + m.LastName AS ManagerName, d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON(e.ManagerID = m.EmployeeID)
JOIN Departments AS d ON(e.DepartmentID = d.DepartmentID)
ORDER BY e.EmployeeID

--Problem 11. Min Average Salary

SELECT TOP 1
AVG(e.Salary) AS Salary
FROM Employees AS e
JOIN Departments AS d ON (e.DepartmentID = d.DepartmentID)
GROUP BY d.DepartmentID
ORDER BY Salary

--Problem 12. Highest Peaks in Bulgaria

USE Geography

SELECT
mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m ON(mc.MountainId = m.Id)
JOIN Peaks AS p ON(m.Id = p.MountainId)
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13. Count Mountain Ranges

SELECT 
mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Mountains AS m ON(mc.MountainId = m.Id)
JOIN Countries AS c ON(mc.CountryCode = c.CountryCode)
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY mc.CountryCode

--Problem 14. Countries with Rivers

SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries AS c
JOIN Continents as co ON(c.ContinentCode = co.ContinentCode)
LEFT JOIN CountriesRivers AS cr ON(c.CountryCode = cr.CountryCode)
LEFT JOIN Rivers AS r ON (cr.RiverId = r.Id)
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName

--Problem 15. *Continents and Currencies

SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM (
	SELECT ContinentCode, CurrencyCode, CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY(ContinentCode)
	ORDER BY CurrencyUsage DESC) AS [RANK]
		FROM (
		SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS
			CurrencyUsage
		FROM Countries
		GROUP BY CurrencyCode, ContinentCode) AS currencies)
			AS rankedCurrencies
WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

--Problem 16. Countries without any Mountains

SELECT COUNT(c.CountryName) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON(c.CountryCode = mc.CountryCode)
LEFT JOIN Mountains AS m ON(mc.MountainId = m.Id)
WHERE mc.MountainId IS NULL

--Problem 17. Highest Peak and Longest River by Country

SELECT TOP 5 c.CountryName, MAX(p.Elevation) AS HighestPeakElevation,
MAX(r.Length) AS LongestRiverLength
FROM Countries as c
JOIN MountainsCountries as mc ON(c.CountryCode = mc.CountryCode)
JOIN Mountains AS m ON(mc.MountainId = m.Id)
JOIN Peaks AS p ON(p.MountainId = m.Id)
JOIN CountriesRivers as cr ON(c.CountryCode = cr.CountryCode)
JOIN Rivers as r ON(cr.RiverId = r.Id)
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

--Problem 18. * Highest Peak Name and Elevation by Country

SELECT TOP 5 c.CountryName AS Country,  
"Highest Peak Name" =
CASE
	WHEN p.PeakName IS NULL THEN '(no highest peak)'
	ELSE p.PeakName
END,
"Highest Peak Elevation" =
CASE
	WHEN MAX(p.Elevation) IS NULL THEN 0
	ELSE MAX(P.Elevation)
END,
Mountain =
CASE
	WHEN m.MountainRange IS NULL THEN '(no mountain)'
	ELSE m.MountainRange
END
FROM Countries as c
LEFT JOIN MountainsCountries as mc ON(c.CountryCode = mc.CountryCode)
LEFT JOIN Mountains AS m ON(mc.MountainId = m.Id)
LEFT JOIN Peaks AS p ON(p.MountainId = m.Id)
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, "Highest Peak Name"




