CREATE TABLE [dbo].[CatalogBrands] (
    [id]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [brand] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CatalogBrand] PRIMARY KEY CLUSTERED ([id] ASC)
);

