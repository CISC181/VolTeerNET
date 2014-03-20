-- =============================================
-- Author:		Kyle Tucker
-- Create date: 3/19/2014
-- Description:	Updates the table attributes excluding the key
-- =============================================
CREATE PROCEDURE [Vend].[sp_Contact_Update]
				@ContactID uniqueidentifier,
                @ContactFirstName nvarchar(50),
				@ContactMiddleName nvarchar(50),
				@ContactLastName nvarchar(50),
				@ActiveFlg bit
AS
BEGIN

	BEGIN TRY

		BEGIN TRANSACTION
			UPDATE tblContact SET
				ContactFirstName = @ContactFirstName,
				ContactMiddleName = @ContactMiddleName,
				ContactLastName = @ContactLastName,
				ActiveFlg = @ActiveFlg
				WHERE ContactID = @ContactID
		COMMIT TRANSACTION
	
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
END
