

-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description:	Handle Updates to Vol.tblEmail
-- =============================================
CREATE PROCEDURE [Vol].[sp_Email_Update] 
	@EmailID int,
	@EmailAddr nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION UpdateEmail;
	BEGIN TRY
		UPDATE Vol.tblEmail SET 
			EmailAddr = @EmailAddr
		WHERE EmailID = @EmailID;
	END TRY
	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
	COMMIT TRANSACTION UpdateEmail;
END


