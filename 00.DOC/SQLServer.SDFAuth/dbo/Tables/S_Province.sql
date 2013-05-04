CREATE TABLE [dbo].[S_Province] (
    [ProvinceID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [ProvinceName] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateCreated]  DATETIME      NULL,
    [DateUpdated]  DATETIME      NULL,
    CONSTRAINT [PK_S_Province] PRIMARY KEY CLUSTERED ([ProvinceID] ASC)
);

