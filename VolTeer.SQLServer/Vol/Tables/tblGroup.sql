CREATE TABLE [Vol].[tblGroup] (
    [GroupID]              INT           IDENTITY (1, 1) NOT NULL,
    [GroupName]            NVARCHAR (50) NULL,
    [ParticipationLevelID] INT           NULL,
    [ActiveFlg]            BIT           NULL,
    CONSTRAINT [PK_tblGroup] PRIMARY KEY CLUSTERED ([GroupID] ASC)
);

