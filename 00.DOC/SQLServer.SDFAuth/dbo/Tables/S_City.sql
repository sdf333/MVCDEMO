CREATE TABLE [dbo].[S_City] (
    [CityID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [CityName]    NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ZipCode]     NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ProvinceID]  BIGINT        NULL,
    [DateCreated] DATETIME      NULL,
    [DateUpdated] DATETIME      NULL,
    CONSTRAINT [PK_S_City] PRIMARY KEY CLUSTERED ([CityID] ASC)
);

