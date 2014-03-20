-- =============================================
-- Author:		Stephen Herbein
-- Create date: 3/19/14
-- Description:	AddrID is the parameter.  
--- If AddrID is null, then return the entire list 
--- if AddrID is not null, return only that AddrID's record.
-- =============================================

CREATE PROCEDURE [Vend].[sp_Address_Select] 
	-- Add the parameters for the stored procedure here
	@AddrID int 
AS
BEGIN TRY
	
	BEGIN TRANSACTION 
	
		IF @AddrID = NULL
		BEGIN
			SELECT
				ActiveFlg,
				AddrID,
				AddrLine1,
				AddrLine2,
				AddrLine3,
				City,
				St,
				Zip,
				Zip4
			FROM Vend.tblAddress
			ORDER BY AddrID;
		END
		ELSE
		BEGIN
			SELECT 
				ActiveFlg,
				AddrID,
				AddrLine1,
				AddrLine2,
				AddrLine3,
				City,
				St,
				Zip,
				Zip4
			FROM Vend.tblAddress
			WHERE AddrID = @AddrID;
		END
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
