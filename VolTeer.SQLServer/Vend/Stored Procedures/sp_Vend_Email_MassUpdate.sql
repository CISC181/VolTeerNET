
-- =============================================
-- Author:		Ryan O'Dowd
-- Create date: 3/18/14
-- Description:	Mass update with posted xml
-- =============================================
CREATE PROCEDURE [Vend].[sp_Vend_Email_MassUpdate] 
	-- Add the parameters for the stored procedure here
	@XML_IN                     XML
AS

DECLARE @stUpdate TABLE 
    ( 
	    [ActiveFlg]         BIT
        ,[EmailID]          INT
        ,[EmailAddr]        NVARCHAR(100)
   ) 

BEGIN TRY
	
	INSERT INTO @stUpdate 
    SELECT
	    ActiveFlg        =  XTbl.value('(ActiveFlg)[1]', 'bit')
	   ,EmailID          =  XTbl.value('(EmailID)[1]', 'int')
	   ,EmailAddr        =  XTbl.value('(EmailAddr)[1]', 'nvarchar(100)')
    FROM 
        @XML_IN.nodes('/ArrayOfEmails/Email') AS XD(XTbl)

	BEGIN TRANSACTION;

		With Stage as (Select * from @stUpdate)

		Update Vend.tblVendEmail
		set EmailAddr = Stage.EmailAddr,
			ActiveFlg = Stage.ActiveFlg
		from Vend.tblVendEmail
		inner join Stage on (Vend.tblVendEmail.EmailID = Stage.EmailID)
		
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


