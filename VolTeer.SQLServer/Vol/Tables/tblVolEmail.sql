CREATE TABLE [Vol].[tblVolEmail] (
    [VolID]   UNIQUEIDENTIFIER NOT NULL,
    [EmailID] INT              NOT NULL,
    CONSTRAINT [PK_tblVolEmail] PRIMARY KEY CLUSTERED ([VolID] ASC, [EmailID] ASC),
    CONSTRAINT [FK_tblVolEmail_tblEmail] FOREIGN KEY ([EmailID]) REFERENCES [Vol].[tblEmail] ([EmailID]),
    CONSTRAINT [FK_tblVolEmail_tblVolunteer] FOREIGN KEY ([VolID]) REFERENCES [Vol].[tblVolunteer] ([VolID])
);

