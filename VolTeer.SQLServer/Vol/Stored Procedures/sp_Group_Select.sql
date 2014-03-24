
-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description: Handles Selects to the Vol.tblGroup table
-- =============================================
CREATE PROCEDURE [Vol].[sp_Group_Select]
	@GroupID int = null
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN
			SELECT 
				GroupID,
				GroupName,
				ParticipationLevelID
			FROM Vol.tblGroup
			Where (@GroupID = 0 OR GroupID = @GroupID)
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


