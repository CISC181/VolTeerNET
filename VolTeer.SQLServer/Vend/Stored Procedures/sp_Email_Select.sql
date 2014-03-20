-- =============================================
-- Author:		Michael Matheny
-- Create date: 3/18/2014
-- Description: List the states
-- =============================================
CREATE PROCEDURE [Vend].[sp_Email_Select]
As
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN
			SELECT
			   EmailID,
			   EmailAddr,
			   ActiveFlg
		   From Vend.tblEmail
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