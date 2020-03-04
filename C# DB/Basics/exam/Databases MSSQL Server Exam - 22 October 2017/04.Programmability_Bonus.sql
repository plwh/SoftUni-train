--17. Employee’s Load

USE ReportService

GO
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @result INT = (
		SELECT COUNT(*)
		FROM Reports
		WHERE EmployeeId = @employeeId AND StatusId = @statusId
	)
	RETURN @result
END
GO

SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id

--18. Assign Employee

GO
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	DECLARE @employeeDepartmentId INT = (
		SELECT DepartmentId
		FROM Employees
		WHERE Id = @employeeId
	)
	
	DECLARE @reportsDepartmentId INT = (
		SELECT c.DepartmentId
		FROM Reports AS r
		JOIN Categories AS c ON r.CategoryId = c.Id
		WHERE r.Id = @reportId
	)

	IF(@employeeDepartmentId = @reportsDepartmentId)
		UPDATE Reports
		SET EmployeeId = @employeeId
		WHERE Id = @reportId
	ELSE
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
END
GO

EXEC usp_AssignEmployeeToReport 17, 2;

SELECT EmployeeId FROM Reports WHERE id = 2

--19. Close Reports
GO
CREATE TRIGGER tr_CloseReports ON Reports AFTER UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId = (SELECT Id FROM Status WHERE Label = 'completed')
	WHERE Id IN (
				 SELECT Id FROM inserted
			     WHERE Id IN (
							  SELECT Id FROM deleted
						      WHERE CloseDate IS NULL)
				 AND CloseDate IS NOT NULL
				)   
END
GO

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;

--20. Categories Revision - BONUS

SELECT c.Name, COUNT(r.Id) AS ReportsNumber,
	   CASE 
		   WHEN InProgressCount > WaitingCount THEN 'in progress'
		   WHEN InProgressCount < WaitingCount THEN 'waiting'
		   ELSE 'equal'
	   END AS MainStatus
FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	JOIN Status AS s ON s.Id = r.StatusId
	JOIN (
			SELECT r.CategoryId,  
				   SUM(CASE WHEN s.Label = 'in progress' THEN 1 ELSE 0 END) as InProgressCount,
				   SUM(CASE WHEN s.Label = 'waiting' THEN 1 ELSE 0 END) as WaitingCount
			FROM Reports AS r
			JOIN Status AS s ON s.Id = r.StatusId
			WHERE s.Label IN ('waiting', 'in progress')
			GROUP BY r.CategoryId
		  ) AS rs ON rs.CategoryId = c.Id
WHERE s.Label IN ('waiting', 'in progress')
GROUP BY c.Name,
		 CASE 
			 WHEN InProgressCount > WaitingCount THEN 'in progress'
		     WHEN InProgressCount < WaitingCount THEN 'waiting'
		     ELSE 'equal'
	     END
ORDER BY c.Name,
		 ReportsNumber,
		 MainStatus
		
