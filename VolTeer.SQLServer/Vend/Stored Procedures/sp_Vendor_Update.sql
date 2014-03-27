-- =============================================
-- Author:		Vendors Team
-- Create date: 3/13/2014
-- Description:	 update each of the table's attributes, except the key
-- =============================================
CREATE PROCEDURE [Vend].[sp_Vendor_Update]
				@flag bit output,
				@VendorID uniqueidentifier,
				@VendorName nvarchar(50)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE tblVendor SET
			VendorName = @Vendorname
			WHERE VendorID = @VendorID
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

