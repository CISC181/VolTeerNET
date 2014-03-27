CREATE TABLE [Vol].[tblGroupVol] (
    [GroupID] INT              NOT NULL,
    [VolID]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_tblGroupVol] PRIMARY KEY CLUSTERED ([GroupID] ASC, [VolID] ASC),
    CONSTRAINT [FK_tblGroupVol_tblGroup] FOREIGN KEY ([GroupID]) REFERENCES [Vol].[tblGroup] ([GroupID]),
    CONSTRAINT [FK_tblGroupVol_tblVolunteer] FOREIGN KEY ([VolID]) REFERENCES [Vol].[tblVolunteer] ([VolID])
);

