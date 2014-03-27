-- =============================================
-- Author:		Weihe Tian Aaron Kesler
-- Create date: 3/17
-- Description:	update
-- =============================================
CREATE PROCEDURE [Vol].[sp_Volunteer_Update] 
	@VolID UNIQUEIDENTIFIER,
	@ActiveFlg bit,
	@VolFirstName nvarchar(20),
	@VolMiddleName nvarchar(20),
	@VolLastName nvarchar(30) 

AS

BEGIN TRY
	BEGIN TRANSACTION
		
			Update Vol.tblVolunteer SET
			VolFirstName = @VolFirstName,
			VolMiddleName = @VolMiddleName,
			VolLastName = @VolLastName
			Where VolID = @VolID;
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

