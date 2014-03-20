CREATE TABLE [Vend].[tblContactEmail] (
    [ContactID]    UNIQUEIDENTIFIER NOT NULL,
    [EmailID]      INT              NOT NULL,
    [PrimaryEmail] BIT              NULL,
    CONSTRAINT [PK_ContactEmail] PRIMARY KEY CLUSTERED ([ContactID] ASC, [EmailID] ASC),
    CONSTRAINT [FK_tblContactEmail_tblContact] FOREIGN KEY ([ContactID]) REFERENCES [Vend].[tblContact] ([ContactID]),
    CONSTRAINT [FK_tblContactEmail_tblEmail] FOREIGN KEY ([EmailID]) REFERENCES [Vend].[tblEmail] ([EmailID])
);

