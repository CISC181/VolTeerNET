-- =============================================
-- Author:		Skills Team
-- Create date: 3/11/2014
-- Updated Error Handeling and added Error with Line Number 03/18/2014
-- Description: Handles Selects to the Vol.tblSkill table
-- =============================================
CREATE PROCEDURE [Vol].[sp_Skill_Select]
	@SkillID uniqueidentifier
AS
BEGIN
	--SET NOCOUNT ON;

	BEGIN TRY
		IF @SkillID = NULL
		BEGIN
			SELECT 
				SkillID,
				SkillName,
				MstrSkillID
			FROM Vol.tblSkill
			ORDER BY SkillID;
		END
		ELSE
		BEGIN
			SELECT 
				SkillID,
				SkillName,
				MstrSkillID
			FROM Vol.tblSkill
			WHERE SkillID = @SkillID;
		END
	END TRY
	BEGIN CATCH

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;
		DECLARE @ErrorLine INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			   @ErrorSeverity = ERROR_SEVERITY(),
			   @ErrorState = ERROR_STATE(),
			   @ErrorLine = ERROR_LINE();
        RAISERROR (@ErrorMessage, -- Message text.
                   @ErrorSeverity, -- Severity.
                   @ErrorState, -- State.
				   @ErrorLine --Line Number.
                   );
	END CATCH
END

