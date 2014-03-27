-- =============================================
-- Author:		Skills Team
-- Create date: 3/11/2014
-- Updated Error Handeling and added Error with Line Number 03/18/2014
-- Description:	Handles Inserts into Vol.tblSkill and returns the SkillID
-- =============================================
CREATE PROCEDURE [Vol].[sp_Skill_Insert] 
	@SkillName nvarchar(50), 
	@MstrSkillID uniqueidentifier,
	@ReqCert bit
AS
BEGIN
	--SET NOCOUNT ON;
	
	DECLARE @IdTable table
		( NewSkillID uniqueidentifier );
	
	BEGIN TRY

		BEGIN TRANSACTION
			
			INSERT Vol.tblSkill ( SkillName, MstrSkillID, ReqCert )
				OUTPUT INSERTED.SkillID
				INTO @IdTable
			VALUES ( @SkillName, @MstrSkillID, @ReqCert );
		
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

	--Return the ID from the inserted row
	SELECT NewSkillID FROM @IdTable;

END

