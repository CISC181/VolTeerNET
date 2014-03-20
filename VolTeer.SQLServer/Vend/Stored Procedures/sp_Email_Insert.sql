-- =============================================
-- Author:		Michael Matheny
-- Create date: 3/18/14
-- =============================================
CREATE PROCEDURE [Vend].[sp_Email_Insert]
	-- Add the parameters for the stored procedure here
	@EmailAddr nvarchar(100)
AS
BEGIN
	BEGIN TRY
		INSERT Into Vend.tblEmail (EmailAddr)
		VALUES (@EmailAddr)
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