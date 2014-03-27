-- =============================================
-- Author:		Skills Team
-- Create date: 3/11/2014
-- Updated Error Handeling and added Error with Line Number 03/18/2014
-- Description:	Handles deletes from Vol.tblSkill
--				 by setting the active flag to 0 instead of deleting a row.
-- =============================================
CREATE PROCEDURE [Vol].[sp_Skill_Delete] 
	@SkillID uniqueidentifier,
	@ActiveFlg int 
AS
BEGIN

	--SET NOCOUNT ON;

	BEGIN TRY

		BEGIN TRANSACTION 

			UPDATE Vol.tblSkill
			SET ActiveFlg = 0
			WHERE SkillID = @SkillID;

			UPDATE Vol.tblSkill
			SET MstrSkillID = (
				SELECT 
					MstrSkillID
				FROM Vol.tblSkill
				WHERE SkillID = @SkillID )
			WHERE MstrSkillID = @SkillID;

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

