-- =============================================
-- Author:		B. Gibbons
-- Create date: 03/16/2014
-- Description:	Delete a sample addr
-- =============================================
Create PROCEDURE [Vol].[sp_Sample_Address_Delete]
                @AddrID int
AS
BEGIN	
		BEGIN TRY
	    
			Delete From VOL.tblSampleAddress
			Where AddrID = @AddrID

		END TRY
	
		BEGIN CATCH
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
END

