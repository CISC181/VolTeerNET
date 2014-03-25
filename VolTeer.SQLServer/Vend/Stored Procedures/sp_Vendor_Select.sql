

CREATE PROCEDURE [Vend].[sp_Vendor_Select]
	@VendorID uniqueidentifier
AS
BEGIN 
	IF @VendorID is not null 
		Select * from Vend.tblVendor where VendorID=@VendorID ORDER By VendorID
	ELSE
		Select * from Vend.tblVendor ORDER By VendorID

END 
