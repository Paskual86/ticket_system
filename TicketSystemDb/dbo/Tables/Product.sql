CREATE TABLE [dbo].[Product] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [Name]             NVARCHAR (150)  NOT NULL,
    [NetPrice]         DECIMAL (18, 3) CONSTRAINT [DF_Product_NetPrice] DEFAULT ((0)) NOT NULL,
    [VatId]            INT             NOT NULL,
    [GrossPrice]       DECIMAL (18, 3) NULL,
    [CategoryId]       INT             NULL,
    [NetPurchasePrice] DECIMAL (18, 3) NULL,
    [Comision]         DECIMAL (18, 3) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProductCategory] ([Id]),
    CONSTRAINT [FK_Product_Vat] FOREIGN KEY ([VatId]) REFERENCES [dbo].[Vat] ([Id])
);

