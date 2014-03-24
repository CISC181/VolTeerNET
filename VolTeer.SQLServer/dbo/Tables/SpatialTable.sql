CREATE TABLE [dbo].[SpatialTable] (
    [id]       INT               IDENTITY (1, 1) NOT NULL,
    [GeogCol1] [sys].[geography] NULL,
    [GeogCol2] AS                ([GeogCol1].[STAsText]())
);

