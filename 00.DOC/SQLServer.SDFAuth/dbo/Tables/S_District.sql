CREATE TABLE [dbo].[S_District] (
    [DistrictID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [DistrictName] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CityID]       BIGINT        NULL,
    [DateCreated]  DATETIME      NULL,
    [DateUpdated]  DATETIME      NULL,
    CONSTRAINT [PK_S_District] PRIMARY KEY CLUSTERED ([DistrictID] ASC)
);

