CREATE PROCEDURE [Vend].[sp_tblProject_Select]
	@ProjectID uniqueidentifier
As
BEGIN 
	IF @ProjectID is null
		Select * from Vend.tblProject ORDER By ProjectID
	ELSE
		Select * from Vend.tblProject where ProjectID=@ProjectID ORDER By ProjectID
END
