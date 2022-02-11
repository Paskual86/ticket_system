CREATE TABLE [dbo].[ItemItems] (
    [EntryID]     NVARCHAR (128) NOT NULL,
    [Firstname]   NVARCHAR (MAX) NULL,
    [Surname]     NVARCHAR (MAX) NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [PostalCode]  BIGINT         NOT NULL,
    [City]        NVARCHAR (MAX) NULL,
    [Region]      NVARCHAR (MAX) NULL,
    [Phone]       NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (MAX) NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    [NIP]         BIGINT         NOT NULL,
    [REGON]       BIGINT         NOT NULL,
    CONSTRAINT [PK_dbo.ItemItems] PRIMARY KEY CLUSTERED ([EntryID] ASC)
);

