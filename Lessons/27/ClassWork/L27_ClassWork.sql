USE [PostOffice1]
GO

CREATE TABLE [dbo].[Position](
	[Id] [INT] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	CONSTRAINT PK_Position PRIMARY KEY CLUSTERED(Id)); 
	GO

CREATE TABLE [dbo].[Contractor](
	[Id] [INT] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[PositionId] [INT] NOT NULL,
	CONSTRAINT PK_Contractor PRIMARY KEY CLUSTERED(Id), /*CLUSTERED - поля будут отсортированы по ключу*/
	CONSTRAINT FK_Contractor_CityId FOREIGN KEY ([PositionId])
	REFERENCES dbo.Position(Id));
	GO

CREATE NONCLUSTERED INDEX IX_Contractor_Name 
	ON dbo.Contractor ([FirstName] ASC)


CREATE TABLE [dbo].[City](
	[Id] [INT] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	CONSTRAINT PK_City PRIMARY KEY CLUSTERED(id)); 
	GO

CREATE TABLE [dbo].[Office](
	[Id] [INT] NOT NULL,
	[CityId] [INT] NOT NULL,
	[Address] [INT] NOT NULL,
	CONSTRAINT PK_Office PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK_Address_CityId FOREIGN KEY (CityId)
	REFERENCES dbo.City(Id));
	GO

CREATE TABLE [dbo].[Status](
	[Id] [INT] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED(Id));
	GO

CREATE TABLE [dbo].[Flow](
	[SendingId] [INT] NOT NULL,
	[StatusId] [INT] NOT NULL,
	[UpdateStatusDateTime] [DateTimeOffSet] NOT NULL,
	CONSTRAINT PK_Flow PRIMARY KEY CLUSTERED(SendingId),
	CONSTRAINT FK_Flow FOREIGN KEY (StatusId)
	REFERENCES dbo.Status(Id));
	GO

CREATE TABLE [dbo].[PostalItem](
	[Id] [INT] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[NumberOfPages] [INT] NOT NULL,
	CONSTRAINT PK_PostalItem PRIMARY KEY CLUSTERED(Id));
	GO

/*Транзакции T-SQL*/

SELECT *
FROM dbo.PostalSending
GO

SELECT *
FROM dbo.Position
GO

ALTER TABLE [dbo].[Position]
DROP CONSTRAINT PK_Position
GO