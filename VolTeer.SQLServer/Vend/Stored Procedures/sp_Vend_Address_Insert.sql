


-- =============================================
-- Author:		Anthony Rizzo
-- Create date: 03/18/2014
-- Description:	Inserts a record into Address table, via transaction
-- =============================================
CREATE PROCEDURE [Vend].[sp_Vend_Address_Insert]
	-- Add the parameters for the stored procedure here
		@AddrLine1 nvarchar(50),
		@AddrLine2 nvarchar(50),
		@AddrLine3 nvarchar(50),
		@City nvarchar(30),
		@St char(2),
		@Zip int,
		@Zip4 int
AS


Declare @outTable table(
AddrID_OUT	INT)

BEGIN TRY
	
	BEGIN TRANSACTION 
	
	INSERT Vend.tblVendAddress 
		(AddrLine1, 
		 AddrLine2, 
		 AddrLine3, 
		 City, 
		 St, 
		 Zip, 
		 Zip4)
		OUTPUT INSERTED.AddrId
		INTO @outTable
			VALUES (@AddrLine1, 
			@AddrLine2,
			@AddrLine3,
			@City,
			@St,
			@Zip,
			@Zip4)

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

Select AddrID_OUT from @outTable;



