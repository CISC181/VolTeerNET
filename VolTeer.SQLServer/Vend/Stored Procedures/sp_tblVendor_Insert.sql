

CREATE PROCEDURE [Vend].[sp_tblVendor_Insert]
	@VendorID uniqueidentifier,
	@VendorName nvarchar(50)

AS
BEGIN
	INSERT Vend.tblVendor (VendorID, VendorName)
	VALUES
	(@VendorID, @VendorName)
END
