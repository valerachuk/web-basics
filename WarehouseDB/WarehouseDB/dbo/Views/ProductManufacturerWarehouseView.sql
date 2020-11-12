CREATE VIEW [dbo].[ProductManufacturerWarehouseView]
    AS SELECT P.Name AS ProductName, M.Name AS ManufacturerName, W.Name AS WarehouseName
    FROM Product P
    FULL OUTER JOIN Manufacturer M ON P.ManufacturerId = M.Id
    FULL OUTER JOIN WarehouseProduct WP ON P.Id = WP.ProductId
    FULL OUTER JOIN Warehouse W ON W.Id = WP.WarehouseId
