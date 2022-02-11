CREATE TABLE [dbo].[TerminalItems] (
    [ID]                       BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]                     NVARCHAR (MAX)  NULL,
    [TotalIncome]              DECIMAL (18, 2) NOT NULL,
    [AverageLengthOfStayTicks] BIGINT          NOT NULL,
    CONSTRAINT [PK_dbo.TerminalItems] PRIMARY KEY CLUSTERED ([ID] ASC)
);

