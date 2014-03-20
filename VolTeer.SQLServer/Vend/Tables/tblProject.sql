CREATE TABLE [Vend].[tblProject] (
    [ProjectID]   UNIQUEIDENTIFIER CONSTRAINT [DF_tblProject_ProjectID] DEFAULT (newid()) NOT NULL,
    [ProjectName] NVARCHAR (50)    NULL,
    [ProjectDesc] NVARCHAR (MAX)   NULL,
    [AddrID]      INT              NULL,
    [ActiveFlg]   INT              NULL,
    CONSTRAINT [PK_tblProject] PRIMARY KEY CLUSTERED ([ProjectID] ASC),
    CONSTRAINT [FK_tblProject_tblAddress] FOREIGN KEY ([AddrID]) REFERENCES [Vend].[tblAddress] ([AddrID])
);

