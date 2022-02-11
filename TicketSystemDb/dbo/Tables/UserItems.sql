CREATE TABLE [dbo].[UserItems] (
    [ID]                NVARCHAR (128) NOT NULL,
    [Firstname]         NVARCHAR (MAX) NULL,
    [Surname]           NVARCHAR (MAX) NULL,
    [Address]           NVARCHAR (MAX) NULL,
    [PostalCode]        BIGINT         NOT NULL,
    [City]              NVARCHAR (MAX) NULL,
    [Region]            NVARCHAR (MAX) NULL,
    [Phone]             NVARCHAR (MAX) NULL,
    [Email]             NVARCHAR (MAX) NULL,
    [Email2]            NVARCHAR (MAX) NULL,
    [Session_LoginTime] DATETIME       NULL,
    [Login]             NVARCHAR (MAX) NULL,
    [Password]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.UserItems] PRIMARY KEY CLUSTERED ([ID] ASC)
);

