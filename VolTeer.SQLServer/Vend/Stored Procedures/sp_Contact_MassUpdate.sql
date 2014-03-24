-- =============================================
-- Author:		Michael Matheny
-- Create date: 3/18/14
-- =============================================
CREATE PROCEDURE [Vend].[sp_Contact_MassUpdate] 
	-- Add the parameters for the stored procedure here
		@XML_IN                     XML
AS
DECLARE @stUpdate TABLE 
    ( 
	    [ActiveFlg]            BIT
        ,[ContactID]           uniqueidentifier
		,[ContactFirstName]    NVARCHAR(50)	
        ,[ContactMiddleName]   NVARCHAR(50)
		,[ContactLastName]     NVARCHAR(50)
   ) 

BEGIN TRY
	
	INSERT INTO @stUpdate 
    SELECT
	    ActiveFlg               =  XTbl.value('(ActiveFlg)[1]', 'bit')
	   ,ContactID               =  XTbl.value('(ContactID)[1]', 'uniqueidentifier')
	   ,ContactFirstName        =  XTbl.value('(ContactFirstName)[1]', 'nvarchar(50)')
	   ,ContactMiddleName       =  XTbl.value('(ContactMiddleName)[1]', 'nvarchar(50)')
	   ,ContactLastName         =  XTbl.value('(ContactLastName)[1]', 'nvarchar(50)')
    FROM 
        @XML_IN.nodes('/ArrayOfContacts/Contact') AS XD(XTbl)

	BEGIN TRANSACTION;

		With Stage as (Select * from @stUpdate)

		Update Vend.tblContact 
		set ContactFirstName = Stage.ContactFirstName,
			ContactMiddleName = Stage.ContactMiddleName,
			ContactLastName = Stage.ContactLastName,
			ActiveFlg = Stage.ActiveFlg
		from Vend.tblContact
		inner join Stage on (Vend.tblContact.ContactID = Stage.ContactID)
		
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
