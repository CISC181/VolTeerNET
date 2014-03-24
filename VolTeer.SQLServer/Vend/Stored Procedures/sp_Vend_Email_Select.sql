-- =============================================
-- Author:		Michael Matheny
-- Create date: 3/18/2014
-- Last update: 3/24/2014 (Stephen Herbein)
-- Description: List the states
-- =============================================
CREATE PROCEDURE [Vend].[sp_Vend_Email_Select]
	@EmailID INT = NULL
As
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN
			SELECT
			   EmailID,
			   EmailAddr,
			   ActiveFlg
			FROM Vend.tblVendEmail
			WHERE @EmailID IS NULL OR LEN(@EmailID) = 0 OR (EmailID = @EmailID)
			ORDER BY EmailID;
		END
	END TRY
	BEGIN CATCH
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
