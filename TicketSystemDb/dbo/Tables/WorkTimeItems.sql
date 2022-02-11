CREATE TABLE [dbo].[WorkTimeItems] (
    [ID]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserItemID] NVARCHAR (128) NULL,
    [Date]       DATETIME       NOT NULL,
    [StartHour]  TIME (7)       NOT NULL,
    [EndHour]    TIME (7)       NULL,
    CONSTRAINT [PK_dbo.WorkTimeItems] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.WorkTimeItems_dbo.UserItems_UserItemID] FOREIGN KEY ([UserItemID]) REFERENCES [dbo].[UserItems] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserItemID]
    ON [dbo].[WorkTimeItems]([UserItemID] ASC);

