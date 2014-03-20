-- =============================================
-- Author:		Stephen Herbein
-- Create date: 3/17/14
-- Description:	Mass update with posted xml
-- =============================================
CREATE PROCEDURE [Vend].[sp_Address_MassUpdate] 
	-- Add the parameters for the stored procedure here
	@XML_IN                     XML
AS

DECLARE @stUpdate TABLE 
    ( 
	    [ActiveFlg]         BIT
        ,[AddrID]           INT
        ,[AddrLine1]        NVARCHAR(50)
		,[AddrLine2]        NVARCHAR(50)
		,[AddrLine3]        NVARCHAR(50)
		,[City]			    nvarchar(30)
		,[St]               char(2)
		,[Zip]              int
		,[Zip4]             int
   ) 

BEGIN TRY
	
	INSERT INTO @stUpdate 
    SELECT
	    ActiveFlg        =  XTbl.value('(ActiveFlg)[1]', 'bit')
	   ,AddrID           =  XTbl.value('(AddrID)[1]', 'int')
	   ,AddrLine1        =  XTbl.value('(AddrLine1)[1]', 'nvarchar(50)')
	   ,AddrLine2        =  XTbl.value('(AddrLine2)[1]', 'nvarchar(50)')
	   ,AddrLine3        =  XTbl.value('(AddrLine3)[1]', 'nvarchar(50)')
	   ,City             =  XTbl.value('(City)[1]', 'nvarchar(30)')
	   ,ST               =  XTbl.value('(ST)[1]', 'char(2)')
	   ,ZIP              =  XTbl.value('(ZIP)[1]', 'int')
	   ,ZIP4             =  XTbl.value('(ZIP4)[1]', 'int')
    FROM 
        @XML_IN.nodes('/ArrayOfAddresses/Address') AS XD(XTbl)

	BEGIN TRANSACTION;

		With Stage as (Select * from @stUpdate)

		Update Vend.tblAddress 
		set AddrLine1 = Stage.AddrLine1,
			AddrLine2 = Stage.AddrLine2,
			AddrLine3 = Stage.AddrLine3,
			City = Stage.City,
			St = Stage.St,
			Zip = Stage.Zip,
			Zip4 = Stage.Zip4,
			ActiveFlg = Stage.ActiveFlg
		from Vend.tblAddress
		inner join Stage on (vend.tblAddress.AddrID = Stage.AddrID)
		
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
