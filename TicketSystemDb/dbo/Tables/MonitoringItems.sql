CREATE TABLE [dbo].[MonitoringItems] (
    [ID]                 BIGINT          IDENTITY (1, 1) NOT NULL,
    [EntryTime]          DATETIME        NULL,
    [ExitTime]           DATETIME        NULL,
    [EntryID]            NVARCHAR (128)  NOT NULL,
    [Deposit]            DECIMAL (18, 2) NOT NULL,
    [ActualPrice]        DECIMAL (18, 2) NOT NULL,
    [TicketItemID]       BIGINT          NOT NULL,
    [PaymentMethod]      INT             NOT NULL,
    [TerminalID]         BIGINT          NOT NULL,
    [UserItemID]         NVARCHAR (128)  NOT NULL,
    [NumberOfTickets]    INT             NOT NULL,
    [PermForChildDrinks] BIT             NOT NULL,
    [PermForChildFood]   BIT             NOT NULL,
    CONSTRAINT [PK_dbo.MonitoringItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.MonitoringItems_dbo.ItemItems_EntryID] FOREIGN KEY ([EntryID]) REFERENCES [dbo].[ItemItems] ([EntryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MonitoringItems_dbo.TerminalItems_TerminalID] FOREIGN KEY ([TerminalID]) REFERENCES [dbo].[TerminalItems] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MonitoringItems_dbo.TicketItems_TicketItemID] FOREIGN KEY ([TicketItemID]) REFERENCES [dbo].[TicketItems] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.MonitoringItems_dbo.UserItems_UserItemID] FOREIGN KEY ([UserItemID]) REFERENCES [dbo].[UserItems] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EntryID]
    ON [dbo].[MonitoringItems]([EntryID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TicketItemID]
    ON [dbo].[MonitoringItems]([TicketItemID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TerminalID]
    ON [dbo].[MonitoringItems]([TerminalID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserItemID]
    ON [dbo].[MonitoringItems]([UserItemID] ASC);

