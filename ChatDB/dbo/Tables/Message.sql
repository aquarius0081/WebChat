CREATE TABLE [dbo].[Message] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Author]      NVARCHAR (200) NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [RoomId]      INT            NOT NULL,
    [Text]        NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Message_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id])
);

