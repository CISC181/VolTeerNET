

-- =============================================
-- Author:		Group Project
-- Create date: <13th March 2014>
-- Description:	<The stored procedure is used to update the Email update table>
-- =============================================
CREATE PROCEDURE [Vol].[sp_tblEmail_Update]
				@flag bit output,
				@EmailID int,
				@EmailAddr nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE tblEmail SET
			EmailAddr = @EmailAddr
			WHERE EmailID = @EmailID
			SET @flag = 1;
			IF @@TRANCOUNT > 0
				BEGIN commit TRANSACTION;
				END
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				BEGIN rollback TRANSACTION;
				END
			SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage;
		END CATCH
END


