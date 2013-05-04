CREATE TABLE [dbo].[user] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [userName] NVARCHAR (20) NOT NULL,
    [password] VARCHAR (30)  NULL,
    [status]   TINYINT       NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UK_UserName] UNIQUE NONCLUSTERED ([userName] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'user', @level2type = N'COLUMN', @level2name = N'id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '用户名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'user', @level2type = N'COLUMN', @level2name = N'userName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '密码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'user', @level2type = N'COLUMN', @level2name = N'password';

