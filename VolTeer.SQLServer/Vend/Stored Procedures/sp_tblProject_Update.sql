-- =============================================
-- Author:		Vendors Team
-- Create date:	3/13/2014
-- Description:	Update the table, set the 'ActiveFlg' to false.  
--				If ActiveFlg doesn't exist, create the column.
-- =============================================
CREATE PROCEDURE [Vend].[sp_tblProject_Update]
				@flag bit output,
				@ProjectID uniqueidentifier,
                @ProjectName nvarchar(50),
				@ProjectDesc nvarchar(MAX),
				@AddrID int
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE tblProject SET
			ProjectName = @ProjectName,
			ProjectDesc = @ProjectDesc,
			AddrID = @AddrID


			WHERE ProjectID = @ProjectID
			SET @flag = 1;
			IF @@TRANCOUNT > 0
				BEGIN commit TRANSACTION;
				END
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				BEGIN rollback TRANSACTION;
				END
		END CATCH
END
