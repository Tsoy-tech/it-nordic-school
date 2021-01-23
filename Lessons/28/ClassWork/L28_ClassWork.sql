PRINT 'Hello!'
GO

DECLARE @x AS DATETIMEOFFSET(7)
SELECT @x = GETUTCDATE()
PRINT CONVERT(VARCHAR(50), @x, 120)
GO

/*=============================================================*/

CREATE DATABASE	[QueryTest]
GO

USE [QueryTest]
Go

CREATE TABLE [dbo].[Category](
	[Id] [UNIQUEIDENTIFIER] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Category_Name UNIQUE ([Name]));
	GO

CREATE TABLE [dbo].[Goods](
	[Id] [INT] NOT NULL IDENTITY(1,1),
	[CatecagoryId] [UNIQUEIDENTIFIER] NOT NULL,
	[Name] [nvarchar] (100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name]),
	/*Создание связи таблицы "Goods" и "Category"*/
	CONSTRAINT FK_Goods_CatergoryId FOREIGN KEY ([CatecagoryId])
	REFERENCES [dbo].[Category](Id));
	GO

	/*ИЛИ*/
	/*Создание связи таблицы "Goods" и "Category"*/

	ALTER TABLE [dbo].[Goods]
	ADD CONSTRAINT FK_Goods_CatergoryId FOREIGN KEY ([CatecagoryId])
	REFERENCES [dbo].[Category](Id);
	GO

INSERT INTO [dbo].[Category] (Id, Name) VALUES (NEWID(), 'Mobile Phones'), (NEWID(), 'TV')
GO

SELECT [Id] AS 'ID', [Name] AS 'Category' FROM [dbo].[Category]
WHERE [Name] Like 'Mobile Phones'
ORDER BY [Name] DESC
GO

DELETE FROM [dbo].[Category]
WHERE [Name] = 'Mobile Phones'
GO

UPDATE [dbo].[Category] SET [Id] = NEWID(), [Name] = 'Mobile Phone'
WHERE [Name] = 'Mobile Phones'
GO

DECLARE @guidMobile UNIQUEIDENTIFIER
SELECT @guidMobile = Id
FROM dbo.Category
WHERE [Name] Like 'Mobile%'

DECLARE @guidTv UNIQUEIDENTIFIER
SELECT @guidTv = Id
FROM dbo.Category
WHERE [Name] Like 'TV%'

INSERT INTO [dbo].[Goods] ([Name], [CatecagoryId]) 
VALUES ('Xiaomi mi 9', @guidMobile)
GO

SELECT * FROM [dbo].[Goods]
GO

PRINT 'ID of Xiaomi Mi 9 is ' + CONVERT(VARCHAR(10), SCOPE_IDENTITY())
PRINT 'ID of Xiaomi Mi 9 is ' + CONVERT(VARCHAR(10), SCOPE_IDENTITY())
GO

DECLARE @categoryName AS VARCHAR(50)
DECLARE @productName AS NVARCHAR(100)
DECLARE @guid AS UNIQUEIDENTIFIER
SELECT @categoryName = 'Watches', @productName = 'Apple Watch', @guid = NEWID()
INSERT INTO [dbo].[Category]([Id], [Name]) VALUES (@guid, @categoryName)
INSERT INTO [dbo].[Goods] ([Name], [CatecagoryId]) VALUES (@productName, @guid)
GO

/*DELETE FROM [dbo].[Category] WHERE [Name] = 'Watches'*/
SELECT * FROM [dbo].Goods
SELECT * FROM [dbo].Category
GO

USE master
DROP DATABASE [QueryTest]
GO

/*STORED PROCEDURES*/
DROP PROCEDURE IF EXISTS dbo.CreateCategory
GO
CREATE PROCEDURE dbo.CreateCategory (
	@categoryName AS VARCHAR(50), 
	@guid AS UNIQUEIDENTIFIER OUTPUT)
AS BEGIN
	/*SET NONCOUNT ON*/

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SET @tempGuid = NEWID()

	INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (@tempGuid, @categoryName)

	SET @guid = @tempGuid
END
GO
/*Вызов функции*/
DECLARE @guid AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @categoryName = 'TEST', @guid = @guid OUTPUT
/**/
SELECT * FROM dbo.Category
DELETE FROM dbo.Category WHERE [Name] = 'TEST'
GO

--------------------------------------------------
--------------------------------------------------
DROP PROCEDURE IF EXISTS dbo.CreateCategory2
GO
CREATE PROCEDURE dbo.CreateCategory2 (
	@categoryName AS VARCHAR(50))
AS BEGIN
	SET NOCOUNT ON

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SET @tempGuid = NEWID()

	INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (@tempGuid, @categoryName)

	SELECT @tempGuid AS [Id]
END
GO
/*Вызов функции*/
DECLARE @guid AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory2 @categoryName = 'TEST'
GO
----------------------------------------------
/**/
----------------------------------------------
DROP PROCEDURE IF EXISTS dbo.CreateCategoryItem
GO
CREATE PROCEDURE dbo.CreateCategoryItem (@categoryName AS VARCHAR(50), @goodsItemName AS VARCHAR(100))
AS BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER
	SELECT @guid = dbo.[GetCategoryId](@categoryName)

	SET XACT_ABORT ON
	BEGIN TRANSACTION
	BEGIN TRY
		IF(@guid IS NULL)
			EXECUTE dbo.[CreateCategory]@categoryName, @guid OUTPUT

		INSERT INTO dbo.[Goods]([CategoryId], [Name]) VALUES (@guid, @goodsItemName)

		SELECT SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		PRINT 'Rolling back the transaction'
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO

EXECUTE dbo.CreateCategoryItem @categoryName = 'LCD TV', @goodsItemName = 'Samsung TV'
SELECT * FROM dbo.Goods
SELECT * FROM dbo.Category
GO

DELETE FROM dbo.Category WHERE [Name] = 'LCDvbcvb TV'
DELETE FROM dbo.Category WHERE [Name] = 'TEST'
DELETE FROM dbo.Goods WHERE [Name] = 'Samsung TV'
DELETE FROM dbo.Category WHERE [Name] = 'TEST'
GO

SELECT G.[Name], C.[Name]
FROM [dbo].[Goods] AS G WITH(NOLOCK)
JOIN [dbo].[Category] AS C WITH(NOLOCK)
ON C.[Id] = G.[CategoryId]

TRUNCATE TABLE dbo.Goods