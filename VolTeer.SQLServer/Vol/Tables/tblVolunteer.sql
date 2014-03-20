CREATE TABLE [Vol].[tblVolunteer] (
    [VolID]         UNIQUEIDENTIFIER CONSTRAINT [DF_tblVolunteer_VolID] DEFAULT (newid()) NOT NULL,
    [ActiveFlg]     BIT              NULL,
    [VolFirstName]  NVARCHAR (20)    NULL,
    [VolMiddleName] NVARCHAR (20)    NULL,
    [VolLastName]   NVARCHAR (30)    NULL,
    CONSTRAINT [PK_Volunteer] PRIMARY KEY CLUSTERED ([VolID] ASC)
);

