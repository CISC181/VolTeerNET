
-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description:	Handles Inserts into Vol.tblEmail
-- =============================================
CREATE PROCEDURE [Vol].[sp_Email_Insert] 
	@EmailAddr nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @EmailIdTable table
		( NewEmailID int );
	
	BEGIN TRY
		INSERT Vol.tblEmail( EmailAddr )
			OUTPUT INSERTED.EmailID
				INTO @EmailIdTable
		VALUES ( @EmailAddr );
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

	--Return the ID from the inserted row
	SELECT NewEmailID FROM @EmailIdTable;

END


