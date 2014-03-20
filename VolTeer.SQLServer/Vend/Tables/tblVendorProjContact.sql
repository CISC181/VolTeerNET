CREATE TABLE [Vend].[tblVendorProjContact] (
    [VendorID]       UNIQUEIDENTIFIER NOT NULL,
    [ProjectID]      UNIQUEIDENTIFIER NOT NULL,
    [ContactID]      UNIQUEIDENTIFIER NOT NULL,
    [PrimaryContact] BIT              NULL,
    CONSTRAINT [PK_tblVendorProj] PRIMARY KEY CLUSTERED ([VendorID] ASC, [ProjectID] ASC, [ContactID] ASC),
    CONSTRAINT [FK_tblVendorProj_tblContact] FOREIGN KEY ([ContactID]) REFERENCES [Vend].[tblContact] ([ContactID]),
    CONSTRAINT [FK_tblVendorProj_tblProject] FOREIGN KEY ([ProjectID]) REFERENCES [Vend].[tblProject] ([ProjectID]),
    CONSTRAINT [FK_tblVendorProj_tblVendor] FOREIGN KEY ([VendorID]) REFERENCES [Vend].[tblVendor] ([VendorID])
);

