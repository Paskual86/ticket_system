CREATE TABLE [dbo].[Magazine] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (150) NOT NULL,
    [Quantity]    INT            NOT NULL,
    CONSTRAINT [PK_Magazine] PRIMARY KEY CLUSTERED ([Id] ASC)
);

