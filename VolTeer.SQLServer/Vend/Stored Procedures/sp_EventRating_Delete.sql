-- =============================================
-- Author:			Stephen Herbein
-- Create date:		03/19/2014
-- Description:		Delete an EventRating based on a RatingID
-- =============================================
CREATE PROCEDURE [Vend].[sp_EventRating_Delete]
				@RatingID int
AS
BEGIN 
	BEGIN TRY

		UPDATE Vend.tblEventRating
		SET ActiveFlg = 0
		Where RatingID=@RatingID; 

	END TRY
	BEGIN CATCH
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