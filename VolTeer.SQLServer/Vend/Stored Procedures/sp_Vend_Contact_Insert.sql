CREATE PROCEDURE [Vend].[sp_Vend_Contact_Insert]
	@vendorid uniqueidentifier,
	@contactid uniqueidentifier,
	@primarycontact bit
AS

begin try
	begin transaction
		insert Vend.tblVendContact
		(
		VendorID,
		ContactiD,
		PrimaryContact
		)
		values
		(
		@vendorid,
		@contactid,
		@primarycontact
		)
	commit transaction

end try

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