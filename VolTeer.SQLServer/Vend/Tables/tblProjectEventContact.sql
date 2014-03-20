CREATE TABLE [Vend].[tblProjectEventContact] (
    [EventID]        UNIQUEIDENTIFIER NOT NULL,
    [ContactID]      UNIQUEIDENTIFIER NOT NULL,
    [PrimaryContact] BIT              NULL,
    CONSTRAINT [PK_tblProjectEventContact] PRIMARY KEY CLUSTERED ([EventID] ASC, [ContactID] ASC),
    CONSTRAINT [FK_tblProjectEventContact_tblContact] FOREIGN KEY ([ContactID]) REFERENCES [Vend].[tblContact] ([ContactID]),
    CONSTRAINT [FK_tblProjectEventContact_tblProjectEvent] FOREIGN KEY ([EventID]) REFERENCES [Vend].[tblProjectEvent] ([EventID])
);

