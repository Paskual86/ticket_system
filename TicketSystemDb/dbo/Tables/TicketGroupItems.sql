CREATE TABLE [dbo].[TicketGroupItems] (
    [ID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.TicketGroupItems] PRIMARY KEY CLUSTERED ([ID] ASC)
);

