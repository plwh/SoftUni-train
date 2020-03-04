--Problem 1. Records’ Count

USE Gringotts

SELECT COUNT(*) AS Count
FROM WizzardDeposits

--Problem 2. Longest Magic Wand

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--Problem 3. Longest Magic Wand per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY(DepositGroup)

--Problem 4. * Smallest Deposit Group per Magic Wand Size

SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--Problem 5. Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7. Deposits Filter

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--Problem 8.  Deposit Charge

SELECT DepositGroup, MagicWandCreator, 
	   MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9. Age Groups

SELECT AgeGroup =
	CASE
		WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
		WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
		WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
		WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
		WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
		WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END, COUNT(Age) AS WizardCount
FROM WizzardDeposits
GROUP BY 
	CASE
		WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
		WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
		WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
		WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
		WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
		WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END

--Problem 10. First Letter

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

--Problem 11. Average Interest

SELECT DepositGroup, IsDepositExpired,
	   AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--Problem 12. * Rich Wizard, Poor Wizard

SELECT SUM([Difference]) as SumDifference
FROM
(
	SELECT Depositamount - LEAD(Depositamount) OVER(ORDER BY Id ASC) AS Difference
	FROM WizzardDeposits
) AS Diffs;

--Problem 13. Departments Total Salaries

USE SoftUni

SELECT DepartmentID, SUM(Salary) as TotalSalary
FROM Employees
GROUP BY DepartmentID

--Problem 14. Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary) as MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
GROUP BY DepartmentID

--Problem 15. Employees Average Salaries

SELECT *
INTO EmployeesNew
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesNew
WHERE ManagerID = 42

UPDATE EmployeesNew
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesNew
GROUP BY DepartmentID

--Problem 16. Employees Maximum Salaries

SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17. Employees Count Salaries

SELECT COUNT(Salary) AS Count
FROM Employees
WHERE ManagerID IS NULL

--Problem 18. *3rd Highest Salary

SELECT 
  DepartmentID,
  (SELECT DISTINCT Salary FROM Employees
   WHERE DepartmentID = e.DepartmentID
   ORDER BY Salary DESC 
   OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) AS ThirdHighestSalary
FROM Employees e
WHERE 
  (SELECT DISTINCT Salary FROM Employees
   WHERE DepartmentID = e.DepartmentID
   ORDER BY Salary DESC 
   OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) IS NOT NULL
GROUP BY DepartmentID


--Problem 19. **Salary Challenge

SELECT TOP 10 
FirstName, LastName, DepartmentID
FROM Employees as e1
WHERE Salary >
	(SELECT AVG(Salary)
	FROM Employees as e2
	WHERE e1.DepartmentID = e2.DepartmentID
	GROUP BY DepartmentID)
ORDER BY DepartmentID




