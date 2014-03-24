CREATE TABLE [Vend].[tblVendorAddr] (
    [VendorID] UNIQUEIDENTIFIER NOT NULL,
    [AddrID]   INT              NOT NULL,
    [HQ]       BIT              NULL,
    CONSTRAINT [PK_tblVendorAddr] PRIMARY KEY CLUSTERED ([VendorID] ASC, [AddrID] ASC),
    CONSTRAINT [FK_tblVendorAddr_tblAddress] FOREIGN KEY ([AddrID]) REFERENCES [Vend].[tblVendAddress] ([AddrID]),
    CONSTRAINT [FK_tblVendorAddr_tblVendor] FOREIGN KEY ([VendorID]) REFERENCES [Vend].[tblVendor] ([VendorID])
);

