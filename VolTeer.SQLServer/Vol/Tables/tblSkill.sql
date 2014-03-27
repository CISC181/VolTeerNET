CREATE TABLE [Vol].[tblSkill] (
    [SkillID]     UNIQUEIDENTIFIER CONSTRAINT [DF_tblSkill_SkillID] DEFAULT (newid()) NOT NULL,
    [SkillName]   NVARCHAR (50)    NULL,
    [MstrSkillID] UNIQUEIDENTIFIER NULL,
    [ReqCert]     BIT              NULL,
    [ActiveFlg]   INT              CONSTRAINT [DF_tblSkill_ActiveFlg] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED ([SkillID] ASC),
    CONSTRAINT [FK_Skill_Skill] FOREIGN KEY ([MstrSkillID]) REFERENCES [Vol].[tblSkill] ([SkillID])
);

