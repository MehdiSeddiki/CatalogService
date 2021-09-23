CREATE TABLE [dbo].[CatalogItems] (
    [id]              BIGINT        IDENTITY (1, 1) NOT NULL,
    [description]     VARCHAR (MAX) NOT NULL,
    [name]            VARCHAR (MAX) NOT NULL,
    [price]           FLOAT (53)    NOT NULL,
    [Picturefilename] VARCHAR (MAX) NOT NULL,
    [brandId]         BIGINT        NOT NULL,
    [TypeId]          BIGINT        NOT NULL,
    CONSTRAINT [PK_CatalogItems] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_CatalogItems_CatalogBrands] FOREIGN KEY ([brandId]) REFERENCES [dbo].[CatalogBrands] ([id]),
    CONSTRAINT [FK_CatalogItems_CatalogItems] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[CatalogTypes] ([id])
);

