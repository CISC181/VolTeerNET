CREATE TABLE [Vol].[tblVolAddr] (
    [VolID]  UNIQUEIDENTIFIER NOT NULL,
    [AddrID] INT              NOT NULL,
    CONSTRAINT [PK_tblVolAddr] PRIMARY KEY CLUSTERED ([VolID] ASC, [AddrID] ASC),
    CONSTRAINT [FK_tblVolAddr_tblAddress] FOREIGN KEY ([AddrID]) REFERENCES [Vol].[tblAddress] ([AddrID]),
    CONSTRAINT [FK_tblVolAddr_tblVolunteer] FOREIGN KEY ([VolID]) REFERENCES [Vol].[tblVolunteer] ([VolID])
);

