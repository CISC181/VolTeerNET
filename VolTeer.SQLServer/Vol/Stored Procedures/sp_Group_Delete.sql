

-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description:	Handle Updates to Vol.tblGroup
-- =============================================
Create PROCEDURE [Vol].[sp_Group_Delete] 
	@GroupID int,
	@ActiveFlg bit
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION UpdateGroup;
	BEGIN TRY
		UPDATE Vol.tblGroup 
		SET ActiveFlg = 1
		WHERE GroupID = @GroupID;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			   @ErrorSeverity = ERROR_SEVERITY(),
			   @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
	END CATCH
	COMMIT TRANSACTION UpdateGroup;
END


