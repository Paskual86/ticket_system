CREATE TABLE [dbo].[TicketItems] (
    [ID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [GroupID]   BIGINT         NOT NULL,
    [IsDefault] BIT            NOT NULL,
    [TimeType]  INT            NOT NULL,
    [Monday]    BIT            NOT NULL,
    [Tuesday]   BIT            NOT NULL,
    [Wednesday] BIT            NOT NULL,
    [Thursday]  BIT            NOT NULL,
    [Friday]    BIT            NOT NULL,
    [Saturday]  BIT            NOT NULL,
    [Sunday]    BIT            NOT NULL,
    CONSTRAINT [PK_dbo.TicketItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.TicketItems_dbo.TicketGroupItems_GroupID] FOREIGN KEY ([GroupID]) REFERENCES [dbo].[TicketGroupItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GroupID]
    ON [dbo].[TicketItems]([GroupID] ASC);

