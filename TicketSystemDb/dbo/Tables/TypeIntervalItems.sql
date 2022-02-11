CREATE TABLE [dbo].[TypeIntervalItems] (
    [ID]               BIGINT          NOT NULL,
    [GrossPrice1]      DECIMAL (18, 2) NOT NULL,
    [FromMinutes1]     INT             NOT NULL,
    [GrossPrice2]      DECIMAL (18, 2) NOT NULL,
    [FromMinutes2]     INT             NOT NULL,
    [GrossPrice3]      DECIMAL (18, 2) NOT NULL,
    [FromMinutes3]     INT             NOT NULL,
    [GrossPrice4]      DECIMAL (18, 2) NOT NULL,
    [FromMinutes4]     INT             NOT NULL,
    [GrossPriceAbove]  DECIMAL (18, 2) NOT NULL,
    [FromMinutesAbove] INT             NOT NULL,
    [ThingA]           BIT             NOT NULL,
    [ThingB]           BIT             NOT NULL,
    [ThingC]           BIT             NOT NULL,
    [ThingD]           BIT             NOT NULL,
    [VAT]              DECIMAL (18, 2) NOT NULL,
    [Discount]         DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.TypeIntervalItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.TypeIntervalItems_dbo.TicketItems_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[TicketItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[TypeIntervalItems]([ID] ASC);

