-- =============================================
-- Author:		<Wilson Hsu>
-- Create date: <3/18/14>
-- Description:	<EventRating_Update>
-- =============================================
CREATE PROCEDURE [Vend].[sp_EventRating_Update]
				@flag bit output,
				@RatingID int,
				@EventID uniqueidentifier,
				@VolID uniqueidentifier,
				@RatingValue int,
				@ActiveFlg bit
AS
BEGIN

	
		BEGIN TRY
			Update VOL.tblEventRating_Update
			set flag = @flag,
			EventID = @EventID,
			VolID = @VolID,
			RatingValue = @RatingValue,
			ActiveFlg = @ActiveFlg
			Where RatingID = @RatingID

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
