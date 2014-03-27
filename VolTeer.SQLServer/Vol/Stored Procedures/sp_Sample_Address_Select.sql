
-- =============================================
-- Author:		Bert Gibbons
-- Create date: 3/15/2014
-- Description: List the states
-- =============================================
Create PROCEDURE [Vol].[sp_Sample_Address_Select]
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN
			SELECT
			   AddrID,
			   ActiveFlg,
			   AddrLine1,
			   AddrLine2,
			   AddrLine3,
			   City,
			   St,
			   Zip,
			   Zip4
		   From Vol.tblSampleAddress
		END
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


