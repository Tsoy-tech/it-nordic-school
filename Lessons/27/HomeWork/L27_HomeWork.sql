CREATE DATABASE [Reminder]
GO

USE [Reminder]
GO

CREATE TABLE [dbo].[Chat](
	[Id] [INT] NOT NULL,
	[Name] [VARCHAR](50) NOT NULL,
	CONSTRAINT PK_Chat PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Chat_Name UNIQUE ([Name]));
	GO

CREATE TABLE [dbo].[Account](
	[Id] [INT] NOT NULL,
	[Name] [VARCHAR](9) NOT NULL, --TelegramUserId
	CONSTRAINT PK_Account PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Account_Name UNIQUE ([Name]));
	GO

CREATE TABLE [dbo].[Status](
	[Id] [INT] NOT NULL,
	[Name] [VARCHAR](50) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Status_Name UNIQUE ([Name]));
	GO

CREATE TABLE [dbo].[ReminderItems](
	[Id] [UNIQUEIDENTIFIER] NOT NULL,
	[ChatId] [INT] NOT NULL,
	[AccountId] [INT] NOT NULL,
	[Date] [DATETIMEOFFSET] NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[StatusId] [INT] NOT NULL,
	CONSTRAINT PK_ReminderItems PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK_ReminderItems_ChatId FOREIGN KEY ([ChatId])
	REFERENCES [dbo].[Chat](Id),
	CONSTRAINT FK_ReminderItems_AccountId FOREIGN KEY ([AccountId])
	REFERENCES [dbo].[Account](Id),
	CONSTRAINT FK_ReminderItems_StatusId FOREIGN KEY ([StatusId])
	REFERENCES [dbo].[Status](Id));
	GO

--USE [master]
--DROP DATABASE [Reminder]
GO
