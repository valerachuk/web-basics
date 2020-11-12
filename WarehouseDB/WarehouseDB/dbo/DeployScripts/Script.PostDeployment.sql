/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

PRINT 'Hello from post deployment script'

DECLARE @manufacturer1 NVARCHAR(50) = 'Apple',
        @manufacturer2 NVARCHAR(50) = 'Samsung';

IF NOT EXISTS(SELECT * FROM Manufacturer WHERE Name = @manufacturer1)
INSERT INTO Manufacturer (Name) VALUES (@manufacturer1)

IF NOT EXISTS(SELECT * FROM Manufacturer WHERE Name = @manufacturer2)
INSERT INTO Manufacturer (Name) VALUES (@manufacturer2)

DECLARE @manufacturer1Id INT = (SELECT Id FROM Manufacturer WHERE Name = @manufacturer1),
        @manufacturer2Id INT = (SELECT Id FROM Manufacturer WHERE Name = @manufacturer2);




DECLARE @product1 NVARCHAR(50) = 'IPhone 11',
        @product2 NVARCHAR(50) = 'IPhone 12',
        @product3 NVARCHAR(50) = 'GALAXY S10',
        @product4 NVARCHAR(50) = 'GALAXY S20';

IF NOT EXISTS(SELECT * FROM Product WHERE Name = @product1)
INSERT INTO Product (Name, ManufacturerId) VALUES (@product1, @manufacturer1Id)

IF NOT EXISTS(SELECT * FROM Product WHERE Name = @product2)
INSERT INTO Product (Name, ManufacturerId) VALUES (@product2, @manufacturer1Id)

IF NOT EXISTS(SELECT * FROM Product WHERE Name = @product3)
INSERT INTO Product (Name, ManufacturerId) VALUES (@product3, @manufacturer2Id)

IF NOT EXISTS(SELECT * FROM Product WHERE Name = @product4)
INSERT INTO Product (Name, ManufacturerId) VALUES (@product4, @manufacturer2Id)

DECLARE @product1Id INT = (SELECT Id FROM Product WHERE Name = @product1),
        @product2Id INT = (SELECT Id FROM Product WHERE Name = @product2),
        @product3Id INT = (SELECT Id FROM Product WHERE Name = @product3),
        @product4Id INT = (SELECT Id FROM Product WHERE Name = @product4);




DECLARE @warehouse1 NVARCHAR(50) = 'USA',
        @warehouse2 NVARCHAR(50) = 'China';

IF NOT EXISTS(SELECT * FROM Warehouse WHERE Name = @warehouse1)
INSERT INTO Warehouse(Name) VALUES (@warehouse1)

IF NOT EXISTS(SELECT * FROM Warehouse WHERE Name = @warehouse2)
INSERT INTO Warehouse(Name) VALUES (@warehouse2)

DECLARE @warehouse1Id INT = (SELECT Id FROM Warehouse WHERE Name = @warehouse1),
        @warehouse2Id INT = (SELECT Id FROM Warehouse WHERE Name = @warehouse2);




IF NOT EXISTS(SELECT * FROM WarehouseProduct WHERE ProductId = @product1Id AND WarehouseId = @warehouse1Id)
INSERT INTO WarehouseProduct (WarehouseId, ProductId, Quantity) VALUES (@warehouse1Id, @product1Id, 5)

IF NOT EXISTS(SELECT * FROM WarehouseProduct WHERE ProductId = @product1Id AND WarehouseId = @warehouse2Id)
INSERT INTO WarehouseProduct (WarehouseId, ProductId, Quantity) VALUES (@warehouse2Id, @product1Id, 3)

IF NOT EXISTS(SELECT * FROM WarehouseProduct WHERE ProductId = @product4Id AND WarehouseId = @warehouse1Id)
INSERT INTO WarehouseProduct (WarehouseId, ProductId, Quantity) VALUES (@warehouse1Id, @product4Id, 4)

IF NOT EXISTS(SELECT * FROM WarehouseProduct WHERE ProductId = @product4Id AND WarehouseId = @warehouse2Id)
INSERT INTO WarehouseProduct (WarehouseId, ProductId, Quantity) VALUES (@warehouse2Id, @product4Id, 1)

IF NOT EXISTS(SELECT * FROM WarehouseProduct WHERE ProductId = @product3Id AND WarehouseId = @warehouse1Id)
INSERT INTO WarehouseProduct (WarehouseId, ProductId, Quantity) VALUES (@warehouse1Id, @product3Id, 7)
