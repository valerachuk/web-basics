CREATE PROCEDURE [dbo].[WarehouseProductAdder]
    @warehouseId INT,
    @productId INT,
    @quantity INT
AS
    INSERT INTO WarehouseProduct(WarehouseId, ProductId, Quantity)
    VALUES (@warehouseId, @productId, @quantity)
