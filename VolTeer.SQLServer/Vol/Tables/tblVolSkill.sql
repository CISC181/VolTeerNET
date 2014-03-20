CREATE TABLE [Vol].[tblVolSkill] (
    [VolID]   UNIQUEIDENTIFIER NOT NULL,
    [SkillID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_tblVolSkill] PRIMARY KEY CLUSTERED ([VolID] ASC, [SkillID] ASC),
    CONSTRAINT [FK_tblVolSkill_tblSkill] FOREIGN KEY ([SkillID]) REFERENCES [Vol].[tblSkill] ([SkillID]),
    CONSTRAINT [FK_tblVolSkill_tblVolunteer] FOREIGN KEY ([VolID]) REFERENCES [Vol].[tblVolunteer] ([VolID])
);

