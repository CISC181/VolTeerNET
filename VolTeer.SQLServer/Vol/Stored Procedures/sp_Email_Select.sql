
-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description: Handles Selects to the Vol.tblEmail table
-- =============================================
CREATE PROCEDURE [Vol].[sp_Email_Select]
	@EmailID int
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		IF @EmailID = NULL
		BEGIN
			SELECT 
				EmailID,
				EmailAddr
			FROM Vol.tblEmail
			ORDER BY EmailID;
		END
		ELSE
		BEGIN
			SELECT 
				EmailID,
				EmailAddr
			FROM Vol.tblEmail
			WHERE EmailID = @EmailID;
		END
	END TRY
	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END


