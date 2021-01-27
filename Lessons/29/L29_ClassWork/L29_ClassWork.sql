
/*1*/
SELECT COUNT(OrderId)
FROM [dbo].[OrderItem]
GO
/*2*/
SELECT COUNT(DISTINCT OrderId)
FROM [dbo].[OrderItem]
GO
/*3*/
SELECT MAX(OrderId) 
FROM [dbo].[OrderItem]
GO
/*4*/
SELECT AVG([Discount]) AS 'Средний размер скидки'
FROM [dbo].[Order]
GO
/*5*/
SELECT MAX([OrderDate]) AS 'Дата последней продажи', MIN(OrderDate) AS '.Дата первой продажи'
FROM [dbo].[Order]
GO
/*6*/
SELECT MAX([OrderDate]) AS 'Дата последней продажи в 2018 году'
FROM [dbo].[Order]
WHERE (YEAR(OrderDate) = 2018)
GO
/*7*/
SELECT MAX(LEN([NAME])) AS 'Максимальная длина наименования товара'
FROM [dbo].[Product]
GO

SELECT LEN('abcd  ef') /*LEN - Подсчет символов*/

SELECT Id AS 'Идентификатор', [Name] AS 'Имя', LEN([Name]) AS 'Длина имени'
FROM [dbo].[Customer]
GO

SELECT O.[Id], C.[Name], O.[OrderDate], O.[Discount]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[Customer] AS C
ON (O.CustomerId = C.Id)
GO

SELECT CONVERT (VARCHAR(4), YEAR(GETUTCDATE())) + ' ' 
+ CONVERT (varchar(2), MONTH(GETUTCDATE()))
GO

/*Вложенные запросы в условии*/
SELECT DISTINCT O.CustomerId
FROM [dbo].[Order] AS O
WHERE YEAR(O.OrderDate)=2019
GO

SELECT C.[Id], C.[Name]
FROM [dbo].[Customer] AS C
WHERE C.[Id] IN (
	SELECT DISTINCT O.CustomerId
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate)=2018
)
GO

SELECT Id, [Name]
FROM [dbo].Product AS P
WHERE LEN(P.[Name]) = (
SELECT MAX(LEN(P.[Name]))
FROM [dbo].Product AS P)
-------------------------------
/*Самостоятельная работа #2*/
-------------------------------

/*Номер заказа с максимальной скидкой в 2016 году*/
SELECT *
FROM [dbo].[Order] AS O
WHERE O.Discount = (
	SELECT MAX(O.Discount)
	FROM [dbo].[Order] AS O
	WHERE YEAR(OrderDate) = 2016
)
GO
/*Номер первого заказа в 2019 году*/
SELECT *
FROM [dbo].[Order] AS O
WHERE O.OrderDate = (
	SELECT MIN(O.OrderDate)
	FROM [dbo].[Order] AS O
	WHERE YEAR(OrderDate) = 2019
)
GO
/*ID и имя клиента, получившего максимальную скидку в 2016 году*/
SELECT *
FROM dbo.Customer AS C
WHERE C.Id = (
	SELECT CustomerId
	FROM [dbo].[Order] AS O
	WHERE O.Discount = (
		SELECT MAX(O.Discount)
		FROM [dbo].[Order] AS O
		WHERE YEAR(OrderDate) = 2016
))
GO
/*ID и имя клиента, сделавшего первый заказ в 2019 году*/
SELECT *
FROM dbo.Customer AS C
WHERE C.Id = (
	SELECT CustomerId
	FROM [dbo].[Order] AS O
	WHERE O.OrderDate = (
		SELECT MIN(O.OrderDate)
		FROM [dbo].[Order] AS O
		WHERE YEAR(OrderDate) = 2019
))
GO


--DECLARE @ClientName

SELECT 
	P.Id AS 'ProductId', 
	P.[Name] AS ProductName,
	OI.NumberOfItems,
	P.Price * OI.NumberOfItems AS ItemsCost
FROM dbo.[OrderItem] AS OI
INNER JOIN [dbo].[Product] AS P
	ON (P.Id = OI.ProductId)
WHERE OI.OrderId = 22
GO

SELECT MIN(C.Name) AS [Name], SUM(P.Price * OI.NumberOfItems) AS TotalCost, 
	MIN(O.Discount) AS Discount, 
	SUM(P.Price * OI.NumberOfItems * O.Discount) AS TotalDiscount,
	SUM(P.Price * OI.NumberOfItems) - 
	SUM(P.Price * OI.NumberOfItems * O.Discount) AS TotalCostWDiscount
FROM dbo.[OrderItem] AS OI
INNER JOIN dbo.Product AS P
	ON P.Id = OI.ProductId
INNER JOIN dbo.[Order] AS O
	ON O.Id = OI.OrderId
INNER JOIN dbo.[Customer] AS C
	ON C.Id = O.CustomerId
WHERE C.[Name] = 'Мария'
GO

SELECT COUNT(*)
FROM dbo.[Order]
GO

SELECT YEAR(O.OrderDate) AS [Year], COUNT(*) AS Quantity
FROM dbo.[Order] AS O
GROUP BY YEAR(O.OrderDate)
ORDER BY 1 DESC

SELECT 
	O.Id, O.OrderDate/*, C.[Name]*/,
	SUM(P.Price * OI.NumberOfItems - 
		CASE WHEN O.Discount IS NULL THEN 0
		ELSE O.Discount
		END 
	* P.Price * OI.NumberOfItems) AS TotalSum
FROM dbo.[Order] AS O
INNER JOIN dbo.OrderItem AS OI
	ON (OI.OrderId = O.Id)
INNER JOIN dbo.Product AS P
	ON (P.Id = OI.ProductId)
INNER JOIN dbo.Customer AS C
	On (C.Id = O.CustomerId)
GROUP BY O.Id, O.OrderDate/*, C.[Name]*/
HAVING YEAR(OrderDate) = 2019

SELECT 
	O.Id, O.OrderDate, C.[Name],
	SUM(P.Price * OI.NumberOfItems 
	-	/*CASE WHEN O.Discount IS NULL THEN 0
		ELSE O.Discount
		END*/ 
	ISNULL(O.Discount, 0) * P.Price * OI.NumberOfItems) AS TotalSum
FROM dbo.[Order] AS O
INNER JOIN dbo.OrderItem AS OI
	ON (OI.OrderId = O.Id)
INNER JOIN dbo.Product AS P
	ON (P.Id = OI.ProductId)
INNER JOIN dbo.Customer AS C
	On (C.Id = O.CustomerId)
GROUP BY O.Id, O.OrderDate, C.[Name]
GO


SELECT 
	SUM(P.Price * OI.NumberOfItems -
	ISNULL(O.Discount, 0) * P.Price * OI.NumberOfItems) AS TotalSum
FROM dbo.[Order] AS O
INNER JOIN dbo.OrderItem AS OI
	ON (OI.OrderId = O.Id)
INNER JOIN dbo.Product AS P
	ON (P.Id = OI.ProductId)
INNER JOIN dbo.Customer AS C
	On (C.Id = O.CustomerId)
--GROUP BY O.Id, O.OrderDate, C.[Name]
WHERE C.[Name] = 'Мария'
GO

------------------------------------------------------
DECLARE @total AS MONEY

SELECT @total = SUM(P.Price * OI.NumberOfItems -
	ISNULL(O.Discount, 0) * P.Price * OI.NumberOfItems)
FROM dbo.[Order] AS O
INNER JOIN dbo.OrderItem AS OI
	ON (OI.OrderId = O.Id)
INNER JOIN dbo.Product AS P
	ON (P.Id = OI.ProductId)
INNER JOIN dbo.Customer AS C
	On (C.Id = O.CustomerId)

SELECT 
	C.Id, C.[Name], YEAR(O.OrderDate) AS [Year],
	SUM(P.Price * OI.NumberOfItems -
	ISNULL(O.Discount, 0) * P.Price * OI.NumberOfItems) AS Total,
	SUM(P.Price * OI.NumberOfItems -
	ISNULL(O.Discount, 0) * P.Price * OI.NumberOfItems) / @total AS Percents
FROM dbo.[Order] AS O
INNER JOIN dbo.OrderItem AS OI
	ON (OI.OrderId = O.Id)
INNER JOIN dbo.Product AS P
	ON (P.Id = OI.ProductId)
INNER JOIN dbo.Customer AS C
	On (C.Id = O.CustomerId)
GROUP BY C.Id, C.[Name], YEAR(O.OrderDate)
ORDER BY 2, 3 ASC
GO

