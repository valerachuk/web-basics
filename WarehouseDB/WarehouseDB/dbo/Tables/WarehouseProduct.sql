CREATE TABLE [dbo].[WarehouseProduct]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [WarehouseId] INT NULL, 
    [ProductId] INT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_WarehouseProduct_Warehouse] FOREIGN KEY (WarehouseId) REFERENCES Warehouse(Id) ON DELETE SET NULL, 
    CONSTRAINT [FK_WarehouseProduct_Product] FOREIGN KEY (ProductId) REFERENCES Product(Id) ON DELETE SET NULL
)
