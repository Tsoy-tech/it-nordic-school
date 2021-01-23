---------------------------------------------------------
--Functions----------------------------------------------
---------------------------------------------------------
DROP FUNCTION IF EXISTS [dbo].[GetCategoryId]
GO
CREATE FUNCTION [dbo].[GetCategoryId](@categoryName AS VARCHAR(50))
RETURNS UNIQUEIDENTIFIER
AS BEGIN

	DECLARE @guid AS UNIQUEIDENTIFIER
		SELECT @guid = Id
		FROM dbo.Category
		WHERE [Name] = @categoryName

	IF @guid is NULL
	BEGIN
		SELECT TOP 1 @guid = Id
		FROM dbo.Category
		WHERE [Name] LIKE @categoryName + '%'
	END

RETURN(@guid)
END
GO

SELECT dbo.GetCategoryId('TV')
GO

