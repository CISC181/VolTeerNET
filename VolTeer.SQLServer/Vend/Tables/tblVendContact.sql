CREATE TABLE [Vend].[tblVendContact] (
    [VendorID]       UNIQUEIDENTIFIER NOT NULL,
    [ContactID]      UNIQUEIDENTIFIER NOT NULL,
    [PrimaryContact] BIT              NULL,
    CONSTRAINT [PK_tblVendContact] PRIMARY KEY CLUSTERED ([VendorID] ASC, [ContactID] ASC),
    CONSTRAINT [FK_tblVendContact_tblContact] FOREIGN KEY ([ContactID]) REFERENCES [Vend].[tblContact] ([ContactID]),
    CONSTRAINT [FK_tblVendContact_tblVendor] FOREIGN KEY ([VendorID]) REFERENCES [Vend].[tblVendor] ([VendorID])
);

