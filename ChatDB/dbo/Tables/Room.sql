CREATE TABLE [dbo].[Room] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED ([Id] ASC)
);

