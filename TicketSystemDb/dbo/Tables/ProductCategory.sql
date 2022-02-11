CREATE TABLE [dbo].[ProductCategory] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (150) NOT NULL,
    [Active]      BIT            CONSTRAINT [DF_ProductCategory_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

