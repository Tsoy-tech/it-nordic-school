DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemsCount]
GO
CREATE PROCEDURE [dbo].[GetReminderItemsCount]
AS BEGIN
	SELECT COUNT(*) AS [Count]
	FROM [dbo].[ReminderItem]
END
GO
DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE
		@now AS DATETIMEOFFSET,
		@reminderId AS UNIQUEIDENTIFIER
	
	SELECT 
		@now = SYSDATETIMEOFFSET(),
		@reminderId = NEWID(); 

	INSERT INTO [dbo].[ReminderItem](
		[Id],
		[AccountId],
		[TargetDate],
		[Message],
		[StatusId],
		[CreatedDate],
		[UpdatedDate])
	VALUES (
		@reminderId,
		@contactId,
		@targetDate,
		@message,
		@statusId,
		@now,
		@now)
	
	SELECT @reminderId
END
GO
---
DROP PROCEDURE IF EXISTS [dbo].[RemoveReminderItem]
GO
CREATE PROCEDURE [dbo].[RemoveReminderItem] (
	@reminderId AS UNIQUEIDENTIFIER, @deleted AS BIT
)
AS BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT * FROM [dbo].[ReminderItem] WHERE Id = @reminderId)
	BEGIN
		DELETE FROM [dbo].[ReminderItem]
		WHERE Id = @reminderId
		SELECT @deleted = 1
	END
	ELSE
		SELECT @deleted = 0	
END
GO
---
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemById]
GO
CREATE PROCEDURE [dbo].[GetReminderItemById] (
	@reminderId AS UNIQUEIDENTIFIER
)
AS BEGIN
	SET NOCOUNT ON

	SELECT
		[Id],
		[AccountId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM [dbo].[ReminderItem]
	WHERE [Id] = @reminderId
END
GO
DROP PROCEDURE IF EXISTS [dbo].[UpdateReminderItem]
GO
CREATE PROCEDURE [dbo].[UpdateReminderItem] (
	@reminderId AS UNIQUEIDENTIFIER,
	@statusId AS TINYINT
)
AS BEGIN
	SET NOCOUNT ON

	UPDATE [dbo].[ReminderItem]
		SET [StatusId] = @statusId,
		[UpdatedDate] = SYSDATETIMEOFFSET()
	WHERE [Id] = @reminderId
END
GO
--
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemsWithPaging]
GO
CREATE PROCEDURE [dbo].[GetReminderItemsWithPaging] (
	@count AS INT = NULL,
	@startPosition AS INT = NULL
)
AS BEGIN
	SET NOCOUNT ON

	IF @count IS NULL OR @count < 1
		SELECT @count = COUNT(*)
		FROM [dbo].[ReminderItem]

	IF @startPosition IS NULL OR @startPosition < 0
		SET @startPosition = 0;

	SELECT
		[Id],
		[AccountId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM [dbo].[ReminderItem]
	ORDER BY [TargetDate] ASC
		OFFSET @startPosition ROWS
		FETCH NEXT @count ROWS ONLY
END
---
GO
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemsByStatusWithPaging]
GO
CREATE PROCEDURE [dbo].[GetReminderItemsByStatusWithPaging] (
	@statusId AS TINYINT,
	@count AS INT = NULL,
	@startPosition AS INT = NULL
)
AS BEGIN
	SET NOCOUNT ON

		IF @count IS NULL OR @count < 1
		SELECT @count = COUNT(*)
		FROM [dbo].[ReminderItem]
		WHERE [StatusId] = @statusId

	IF @startPosition IS NULL OR @startPosition < 0
		SET @startPosition = 0;

	SELECT
		[Id],
		[AccountId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM [dbo].[ReminderItem]
	WHERE [StatusId] = @statusId
	ORDER BY [TargetDate] ASC
		OFFSET @startPosition ROWS
		FETCH NEXT @count ROWS ONLY
END
GO
--
DROP PROCEDURE IF EXISTS [dbo].[RemoveAllReminderItems]
GO
CREATE PROCEDURE [dbo].[RemoveAllReminderItems]
AS BEGIN
	SET NOCOUNT ON
	TRUNCATE TABLE [dbo].[ReminderItem]
END
GO