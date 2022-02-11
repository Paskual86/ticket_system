CREATE TABLE [dbo].[TypeMinuteItems] (
    [ID]               BIGINT          NOT NULL,
    [GrossPrice]       DECIMAL (18, 2) NOT NULL,
    [ForMinutes]       INT             NOT NULL,
    [ExtraPay]         DECIMAL (18, 2) NOT NULL,
    [ForNextMinutes]   INT             NOT NULL,
    [IsFixedPrice]     BIT             NOT NULL,
    [VAT]              DECIMAL (18, 2) NOT NULL,
    [Discount]         DECIMAL (18, 2) NOT NULL,
    [GrossPriceAbove]  DECIMAL (18, 2) NOT NULL,
    [FromMinutesAbove] INT             NOT NULL,
    CONSTRAINT [PK_dbo.TypeMinuteItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.TypeMinuteItems_dbo.TicketItems_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[TicketItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[TypeMinuteItems]([ID] ASC);

