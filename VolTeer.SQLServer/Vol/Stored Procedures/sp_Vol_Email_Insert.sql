
-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Last Update: 3/24/2014 (Stephen Herbein)
-- Description:	Handles Inserts into Vol.tblEmail
-- =============================================
CREATE PROCEDURE [Vol].[sp_Vol_Email_Insert] 
	@EmailAddr nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @EmailIdTable table
		( NewEmailID int );
	
	BEGIN TRY
		INSERT Vol.tblVolEmail( EmailAddr )
			OUTPUT INSERTED.EmailID
				INTO @EmailIdTable
		VALUES ( @EmailAddr );
	END TRY
	BEGIN CATCH
		-- Test XACT_STATE:
			-- If 1, the transaction is committable.
			-- If -1, the transaction is uncommittable and should 
			--     be rolled back.
			-- XACT_STATE = 0 means that there is no transaction and
			--     a commit or rollback operation would generate an error.

		-- Test whether the transaction is uncommittable.
		IF (XACT_STATE()) = -1
		BEGIN
			PRINT
				N'The transaction is in an uncommittable state.' +
				'Rolling back transaction.'
			ROLLBACK TRANSACTION;
		END;

		-- Test whether the transaction is committable.
		IF (XACT_STATE()) = 1
		BEGIN
			PRINT
				N'The transaction is in committable state.' +
				'Rolling back transaction.'
			ROLLBACK TRANSACTION;   
		END;
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			   @ErrorSeverity = ERROR_SEVERITY(),
			   @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, -- Message text.
                   @ErrorSeverity, -- Severity.
                   @ErrorState -- State.
                   );
	END CATCH

	--Return the ID from the inserted row
	SELECT NewEmailID FROM @EmailIdTable;

END


