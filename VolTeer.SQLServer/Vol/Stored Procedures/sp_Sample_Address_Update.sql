﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Vol].[sp_Sample_Address_Update]
                @AddrID int,
                @AddrLine1 nvarchar(50),
                @AddrLine2 nvarchar(50),
                @AddrLine3 nvarchar(50),
                @City nvarchar(30),
                @St char(2),
                @Zip int,
                @Zip4 int,
				@ActiveFlg bit
AS
BEGIN
	
		BEGIN TRY
			Update VOL.tblSampleAddress
			set AddrLine1 = @AddrLine1,
			AddrLine2 = @AddrLine2,
			AddrLine3 = @AddrLine3,
			City = @City,
			St = @St,
			Zip = @Zip,
			Zip4 = @Zip4,
			ActiveFlg = @ActiveFlg
			Where AddrID = @AddrID

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

