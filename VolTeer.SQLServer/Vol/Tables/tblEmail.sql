CREATE TABLE [Vol].[tblEmail] (
    [EmailID]   INT            IDENTITY (1, 1) NOT NULL,
    [EmailAddr] NVARCHAR (100) NULL,
    [ActiveFlg] BIT            NULL,
    CONSTRAINT [PK_tblEmail] PRIMARY KEY CLUSTERED ([EmailID] ASC)
);

