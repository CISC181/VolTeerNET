

CREATE PROCEDURE [Vend].[sp_tblProject_Insert]
	@ProjectID uniqueidentifier,
	@ProjectName nvarchar(50), 
	@ProjectDesc nvarchar(max),
	@AddrID int

AS
BEGIN
	INSERT Vend.tblProject (ProjectID, ProjectName, ProjectDesc, AddrID)
	VALUES
	(@ProjectID, @ProjectName, @ProjectDesc, @AddrID)
END
SELECT @addrid=SCOPE_IDENTITY()

