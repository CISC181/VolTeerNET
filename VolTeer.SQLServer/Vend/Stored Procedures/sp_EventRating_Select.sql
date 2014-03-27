-- =============================================
-- Author:		Wilson Hsu
-- Create date: 3/18/2014
-- Last Update: 3/24/2014 (Stephen Herbein)
-- Description: List the states eventrating_select
-- =============================================
CREATE PROCEDURE [Vend].[sp_EventRating_Select]
	@RatingID INT = NULL
As
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		
		BEGIN TRANSACTION
		BEGIN
			SELECT
				RatingID,
				EventID,
				VolID,
				RatingValue,
				ActiveFlg
			FROM Vend.tblEventRating
			WHERE @RatingID IS NULL OR LEN(@RatingID) = 0 OR (RatingID = @RatingID)
			ORDER BY RatingID;
		END
	COMMIT TRANSACTION
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

