-- =============================================
-- Author:		Hogyeong Jeong
-- Create date: 3/17/14
-- Description:	insert a new address
-- =============================================
CREATE PROCEDURE [Vol].[sp_Vol_Address_Insert] 
	@AddrLine1 nvarchar(50),
	@AddrLine2 nvarchar(50),
	@AddrLine3 nvarchar(50),
	@City nvarchar(30),
	@St char(2),
	@Zip int,
	@Zip4 int,
	@ActiveFlg bit
AS

Declare @outTable table(
AddrId_OUT	INT)

BEGIN TRY
	
	BEGIN TRANSACTION 
		INSERT Vol.tblVolAddress 
		(AddrLine1, 
		 AddrLine2, 
		 AddrLine3, 
		 City, 
		 St, 
		 Zip, 
		 Zip4, 
		 ActiveFlg)
		OUTPUT INSERTED.AddrId
		INTO @outTable
			VALUES (@AddrLine1, 
			@AddrLine2,
			@AddrLine3,
			@City,
			@St,
			@Zip,
			@Zip4,
			@ActiveFlg);
			
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
