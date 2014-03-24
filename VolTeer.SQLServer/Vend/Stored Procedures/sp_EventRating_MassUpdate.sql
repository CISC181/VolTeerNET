-- =============================================
-- Author:		Stephen Herbein
-- Create date: 3/19/14
-- =============================================
CREATE PROCEDURE [Vend].[sp_EventRating_MassUpdate] 
	-- Add the parameters for the stored procedure here
		@XML_IN                     XML
AS
DECLARE @stUpdate TABLE 
    ( 
	    [ActiveFlg]				BIT
        ,[RatingID]				int
		,[EventID]				uniqueidentifier	
        ,[VolID]				uniqueidentifier
		,[RatingValue]			int
   ) 

BEGIN TRY
	
	INSERT INTO @stUpdate 
    SELECT
	    ActiveFlg			=  XTbl.value('(ActiveFlg)[1]', 'bit')
	   ,RatingID			=  XTbl.value('(RatingID)[1]', 'int')
	   ,EventID				=  XTbl.value('(EventID)[1]', 'uniqueidentifier')
	   ,VolID				=  XTbl.value('(VolID)[1]', 'uniqueidentifier')
	   ,RatingValue			=  XTbl.value('(RatingValue)[1]', 'int')
    FROM 
        @XML_IN.nodes('/ArrayOfEventRatings/EventRating') AS XD(XTbl)

	BEGIN TRANSACTION;

		With Stage as (Select * from @stUpdate)

		Update Vend.tblEventRating
		set EventID = Stage.EventID,
			VolID = Stage.VolID,
			RatingValue = Stage.RatingValue,
			ActiveFlg = Stage.ActiveFlg
		from Vend.tblEventRating
		inner join Stage on (Vend.tblEventRating.RatingID = Stage.RatingID)
		
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
