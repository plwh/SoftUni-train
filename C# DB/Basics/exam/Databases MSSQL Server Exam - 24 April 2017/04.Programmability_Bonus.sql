--17. Cost of Order

USE WMS

GO
CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(4, 2)
AS
BEGIN
	DECLARE @orderCount INT = (
		SELECT COUNT(OrderId)
		FROM Orders
		WHERE JobId = @jobId
	)
	
	IF(@orderCount = 0)
		RETURN 0

	DECLARE @result DECIMAL(4, 2) = (
		SELECT SUM(p.Price * op.Quantity)
		FROM Parts AS p
		JOIN OrderParts AS op ON p.PartId = op.PartId
		JOIN Orders AS o ON op.OrderId = o.OrderId
		WHERE o.JobId = @jobId
	)

	RETURN @result
END
GO

SELECT dbo.udf_GetCost(1)

--18. Place Order

--19. Detect Delivery

GO
CREATE TRIGGER tr_DetectDelivery ON Orders FOR UPDATE
AS
BEGIN
	DECLARE @isDelivered BIT = (
		SELECT Delivered
		FROM inserted
	)

	IF(@isDelivered = 1)
	BEGIN
		DECLARE @orderId INT = (
			SELECT OrderId
			FROM inserted
		)

		UPDATE Parts
		SET StockQty += op.Quantity
		FROM Parts AS p
		JOIN OrderParts AS op ON p.PartId = op.PartId
		WHERE op.OrderId = @orderId
	END
END
GO

UPDATE Orders
SET Delivered = 1
WHERE OrderId = 21

--20. Vendor Preference - BONUS

WITH CTE_Parts
AS
(
	SELECT m.MechanicId, v.VendorId, SUM(op.Quantity) AS VendorItems
	FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	JOIN Orders AS o ON j.JobId = o.JobId
	JOIN OrderParts AS op ON o.OrderId = op.OrderId
	JOIN Parts AS p ON op.PartId = p.PartId
	JOIN Vendors AS v ON p.VendorId = v.VendorId
	GROUP BY m.MechanicId, v.VendorId
)
SELECT CONCAT(m.Firstname, ' ', m.LastName) AS Mechanic, v.Name AS Vendor,
c.VendorItems AS Parts,
CAST(CAST(CAST(VendorItems AS DECIMAL(6,2)) / (SELECT SUM(VendorItems) FROM CTE_Parts WHERE MechanicId = c.MechanicId) * 100 AS INT) AS VARCHAR(MAX)) + '%' AS Preference
FROM CTE_Parts AS c
JOIN Mechanics AS m ON m.MechanicId = c.MechanicId
JOIN Vendors AS v ON v.VendorId = c.VendorId
ORDER BY Mechanic, Parts DESC, Vendor



