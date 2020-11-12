SELECT SUM(WP.Quantity) AS Quantity, M.Name AS Manufacturer
    FROM Product P
    JOIN Manufacturer M ON P.ManufacturerId = M.Id
    JOIN WarehouseProduct WP ON P.Id = WP.ProductId
    GROUP BY M.Name
