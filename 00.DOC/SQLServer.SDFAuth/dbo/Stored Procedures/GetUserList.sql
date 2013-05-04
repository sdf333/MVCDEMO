-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetUserList 
	@UserId INT
AS
BEGIN
	SELECT * FROM dbo.[user]
END
