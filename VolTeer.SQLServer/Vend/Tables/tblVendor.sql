CREATE TABLE [Vend].[tblVendor] (
    [VendorID]   UNIQUEIDENTIFIER CONSTRAINT [DF_tblVendor_VendorID] DEFAULT (newid()) NOT NULL,
    [VendorName] NVARCHAR (50)    NULL,
    [ActiveFlg]  INT              NULL,
    CONSTRAINT [PK_tblVendor] PRIMARY KEY CLUSTERED ([VendorID] ASC)
);

