
-- =============================================
-- Author:		Projects Group
-- Create date: 3/12/2014
-- Description:	Handles Inserts into Vol.tblGroup
-- =============================================
CREATE PROCEDURE [Vol].[sp_Group_Insert] 
	@GroupName nvarchar(50), 
	@ParticipationLevelID int
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @GrpIdTable table
		( NewGroupID int );
	
	BEGIN TRY
		INSERT Vol.tblGroup ( GroupName, ParticipationLevelID )
			OUTPUT INSERTED.GroupID
				INTO @GrpIdTable
		VALUES ( @GroupName, @ParticipationLevelID );
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

	--Return the ID from the inserted row
	SELECT NewGroupID FROM @GrpIdTable;

END

