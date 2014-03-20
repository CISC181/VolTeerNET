
-- =============================================
-- Author:		Ryan O'Dowd
-- Create date: 3/18/14
-- Description:	update each of the table's attributes, except the key
-- =============================================
CREATE PROCEDURE [Vend].[sp_Email_Update] 
	-- Add the parameters for the stored procedure here
	@EmailID int,
	@EmailAddr nvarchar(100),
	@ActiveFlg bit

AS
BEGIN TRY
	
	BEGIN TRANSACTION 
		Update Vend.tblEmail set
			EmailAddr = @EmailAddr,
			ActiveFlg = @ActiveFlg
			Where EmailID = @EmailID;
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

