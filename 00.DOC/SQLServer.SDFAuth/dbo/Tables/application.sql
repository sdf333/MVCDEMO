CREATE TABLE [dbo].[application] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [AppName]    NVARCHAR (50)  NOT NULL,
    [Descript]   NVARCHAR (100) NULL,
    [status]     TINYINT        DEFAULT ((1)) NOT NULL,
    [sdf_sdfsdf] NCHAR (10)     NULL,
    CONSTRAINT [PK_APPLICATION] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'application', @level2type = N'COLUMN', @level2name = N'id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '应用程序名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'application', @level2type = N'COLUMN', @level2name = N'AppName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'application', @level2type = N'COLUMN', @level2name = N'Descript';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '状态 0:停用 1：正常', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'application', @level2type = N'COLUMN', @level2name = N'status';

