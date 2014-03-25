
-- =============================================
-- Author:		Bert Gibbons
-- Create date: 3/15/2014
-- Description: List the states
-- =============================================
CREATE PROCEDURE [Vol].[sp_Vol_State_Select]
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN
			SELECT 
				StateID,
				Name as StateName,
				Abbreviation as StateAbbr
			FROM Vol.tblVolState
			Where Country = 'USA'
			Order By Abbreviation
		END
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
END


