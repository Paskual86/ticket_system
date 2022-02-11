CREATE TABLE [dbo].[TypeNoLimitItems] (
    [ID]         BIGINT          NOT NULL,
    [GrossPrice] DECIMAL (18, 2) NOT NULL,
    [VAT]        DECIMAL (18, 2) NOT NULL,
    [Discount]   DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.TypeNoLimitItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.TypeNoLimitItems_dbo.TicketItems_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[TicketItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[TypeNoLimitItems]([ID] ASC);

