CREATE TABLE [Vol].[tblVolState] (
    [StateID]                 INT           NOT NULL,
    [name]                    VARCHAR (255) NULL,
    [abbreviation]            VARCHAR (255) NULL,
    [country]                 VARCHAR (255) NULL,
    [type]                    VARCHAR (255) NULL,
    [sort]                    INT           NULL,
    [status]                  VARCHAR (255) NULL,
    [occupied]                VARCHAR (255) NULL,
    [notes]                   VARCHAR (255) NULL,
    [fips_state]              VARCHAR (255) NULL,
    [assoc_press]             VARCHAR (255) NULL,
    [standard_federal_region] VARCHAR (255) NULL,
    [census_region]           VARCHAR (255) NULL,
    [census_region_name]      VARCHAR (255) NULL,
    [census_division]         VARCHAR (255) NULL,
    [census_devision_name]    VARCHAR (255) NULL,
    [circuit_court]           VARCHAR (255) NULL,
    CONSTRAINT [PK_state] PRIMARY KEY CLUSTERED ([StateID] ASC)
);

