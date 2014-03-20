

CREATE PROCEDURE [Vend].[sp_tblProject_Delete]
	@ProjectID uniqueidentifier,
	@flag bit output-- return 0 for fail,1 for success


AS
BEGIN
	BEGIN TRANSACTION 
		BEGIN TRY 
			UPDATE Vend.tblProject SET ActiveFlg = 0 Where ProjectID=@ProjectID set @flag=1; 
			set @flag=1;
			IF @@TRANCOUNT>0
				BEGIN commit TRANSACTION;
				END;
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				BEGIN rollback TRANSACTION; 
				END
			set @flag=0; 
		END CATCH

END
