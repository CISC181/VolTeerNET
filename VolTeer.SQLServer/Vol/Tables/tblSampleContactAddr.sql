CREATE TABLE [vol].[tblSampleContactAddr]
(
	[ContactID] INT NOT NULL , 
    [AddrID] INT NOT NULL, 
    PRIMARY KEY ([ContactID], [AddrID]), 
    CONSTRAINT [FK_tblSampleContactAddr_tblContact] FOREIGN KEY ([ContactID]) REFERENCES [vol].[tblSampleContact]([ContactID]), 
    CONSTRAINT [FK_tblSampleContactAddr_tblAddress] FOREIGN KEY ([AddrID]) REFERENCES [vol].[tblSampleAddress]([AddrID])
)
