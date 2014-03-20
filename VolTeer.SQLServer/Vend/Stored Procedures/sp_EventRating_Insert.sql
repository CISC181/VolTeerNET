-- =============================================
-- Author:		Wilson Hsu
-- Create date: 3/18/14
-- Description:	EventRating_Insert
-- =============================================
CREATE PROCEDURE [Vend].[sp_EventRating_Insert]
	-- Add the parameters for the stored procedure here
	@EventID uniqueidentifier,
	@VolID uniqueidentifier,
	@RatingValue int
	--@rateid int OUTPUT
AS

Declare @outTable table(
rateID_OUT  int)

BEGIN TRY

		BEGIN TRANSACTION

			INSERT Vend.tblEventRating
			(EventID,
			 VolID,
			 RatingValue)
			OUTPUT INSERTED.RatingID
			INTO @outTable
			VALUES
			 (@EventID,
			  @VolID,
			  @RatingValue)

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

Select rateID_OUT from @outTable;


