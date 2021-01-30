CREATE PROCEDURE dbo.AddProduct(
	@name AS VARCHAR(300),
	@price AS SMALLMONEY)
AS
BEGIN
	INSERT INTO dbo.Product ([Name], [Price])
	VALUES (@name, @price)

	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE dbo.AddOrder(
	@customerId AS INT, 
	@orderDate AS DATETIMEOFFSET,
	@discount AS FLOAT = NULL)
AS
BEGIN
	INSERT INTO dbo.[Order] (CustomerId, OrderDate, Discount)
	VALUES (@customerId, @orderDate, @discount)

	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE dbo.AddOrderItem(
	@orderId AS INT, 
	@productId AS INT, 
	@numberOfItems AS INT)
AS
BEGIN
	INSERT INTO dbo.[OrderItem] (OrderId, ProductId, NumberOfItems)
	VALUES (@orderId, @productId, @numberOfItems)
END
GO

DROP PROCEDURE dbo.AddOrder
DROP PROCEDURE dbo.AddOrderItem