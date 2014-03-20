CREATE TABLE [Vend].[tblEventRating] (
    [RatingID]    INT              NOT NULL,
    [EventID]     UNIQUEIDENTIFIER NULL,
    [VolID]       UNIQUEIDENTIFIER NULL,
    [RatingValue] INT              NULL,
    [ActiveFlg]   BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblEventRating] PRIMARY KEY CLUSTERED ([RatingID] ASC),
    CONSTRAINT [FK_tblEventRating_tblProjectEvent] FOREIGN KEY ([EventID]) REFERENCES [Vend].[tblProjectEvent] ([EventID])
);

