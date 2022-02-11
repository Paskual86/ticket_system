CREATE TABLE [dbo].[Vat] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Value] DECIMAL (18, 3) NOT NULL,
    CONSTRAINT [PK_Vat] PRIMARY KEY CLUSTERED ([Id] ASC)
);

