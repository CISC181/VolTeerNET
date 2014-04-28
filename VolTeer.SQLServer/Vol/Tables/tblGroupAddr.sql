CREATE TABLE [Vol].[tblGroupAddr] (
    [GroupID] INT NOT NULL,
    [AddrID]  INT NOT NULL,
    [PrimaryAddrID] BIT NOT NULL, 
    [ActiveFlg] BIT NOT NULL, 
    CONSTRAINT [PK_tblGroupAddr] PRIMARY KEY CLUSTERED ([GroupID] ASC, [AddrID] ASC),
    CONSTRAINT [FK_tblGroupAddr_tblAddress] FOREIGN KEY ([AddrID]) REFERENCES [Vol].[tblVolAddress] ([AddrID]),
    CONSTRAINT [FK_tblGroupAddr_tblGroup] FOREIGN KEY ([GroupID]) REFERENCES [Vol].[tblGroup] ([GroupID])
);

