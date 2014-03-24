

CREATE PROCEDURE [Vend].[sp_tblVendor_Delete]
	@VendorID uniqueidentifier,
	@flag bit output-- return 0 for fail,1 for success


AS
BEGIN
	BEGIN TRANSACTION 
		BEGIN TRY 
			UPDATE Vend.tblVendor SET ActiveFlg = 0 Where VendorID=@VendorID; 
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

