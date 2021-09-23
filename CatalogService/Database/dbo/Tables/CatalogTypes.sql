CREATE TABLE [dbo].[CatalogTypes] (
    [id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [type] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_CatalogTypes] PRIMARY KEY CLUSTERED ([id] ASC)
);

