CREATE TABLE [Vend].[tblProjectEvent] (
    [EventID]       UNIQUEIDENTIFIER CONSTRAINT [DF_tblProjectEvent_EventID] DEFAULT (newid()) NOT NULL,
    [ProjectID]     UNIQUEIDENTIFIER NOT NULL,
    [StartDateTime] DATETIME         NULL,
    [EndDateTime]   DATETIME         NULL,
    [AddrID]        INT              NULL,
    CONSTRAINT [PK_tblProjectEvent_1] PRIMARY KEY CLUSTERED ([EventID] ASC)
);

