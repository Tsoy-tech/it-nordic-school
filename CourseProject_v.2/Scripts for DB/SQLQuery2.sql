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
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemById]
GO
CREATE PROCEDURE [dbo].[GetReminderItemById] (
	@reminderId AS UNIQUEIDENTIFIER)
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
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE [dbo].[ReminderItem]
		SET [StatusId] = @statusId,
			[AccountId] = @contactId,
			[TargetDate] = @targetDate,
			[Message] = @message,
			[UpdatedDate] = SYSDATETIMEOFFSET()
	WHERE [Id] = @reminderId
END
GO
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemsByStatuses]
GO
CREATE PROCEDURE [dbo].[GetReminderItemsByStatuses]
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		R.[Id],
		R.[AccountId],
		R.[TargetDate],
		R.[Message],
		R.[StatusId]
	FROM [dbo].[ReminderItem] AS R
	INNER JOIN #tempReminderItemStatus AS T
		ON T.StatusId = R.StatusId
END
GO