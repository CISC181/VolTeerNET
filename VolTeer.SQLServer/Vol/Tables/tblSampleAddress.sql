CREATE TABLE [Vol].[tblSampleAddress] (
    [AddrID]    INT           IDENTITY (1, 1) NOT NULL,
    [ActiveFlg] BIT           NULL,
    [AddrLine1] NVARCHAR (50) NULL,
    [AddrLine2] NVARCHAR (50) NULL,
    [AddrLine3] NVARCHAR (50) NULL,
    [City]      NVARCHAR (30) NULL,
    [St]        CHAR (2)      NULL,
    [Zip]       INT           NULL,
    [Zip4]      INT           NULL,
    CONSTRAINT [PK_tblSampleAddress] PRIMARY KEY CLUSTERED ([AddrID] ASC)
);

