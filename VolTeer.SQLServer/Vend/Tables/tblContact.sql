CREATE TABLE [Vend].[tblContact] (
    [ContactID]         UNIQUEIDENTIFIER CONSTRAINT [DF_tblContact_ContactID] DEFAULT (newid()) NOT NULL,
    [ContactFirstName]  NVARCHAR (50)    NULL,
    [ContactMiddleName] NVARCHAR (50)    NULL,
    [ContactLastName]   NVARCHAR (50)    NULL,
    [ActiveFlg]         BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED ([ContactID] ASC)
);

