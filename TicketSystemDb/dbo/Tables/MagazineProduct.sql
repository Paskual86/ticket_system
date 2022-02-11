CREATE TABLE [dbo].[MagazineProduct] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [MagazineId] INT NOT NULL,
    [ProductId]  INT NOT NULL,
    CONSTRAINT [PK_MagazineProduct] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MagazineProduct_Magazine] FOREIGN KEY ([MagazineId]) REFERENCES [dbo].[Magazine] ([Id]),
    CONSTRAINT [FK_MagazineProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

