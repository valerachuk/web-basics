CREATE PROCEDURE [dbo].[ManufacturerProductsCreator]
    @manufacturerName NVARCHAR(50),
    @products [NameTableType] READONLY
AS
BEGIN

    INSERT INTO dbo.Manufacturer([Name])
    VALUES (@manufacturerName)

    DECLARE @manufacturerId INT;
    SET @manufacturerId = SCOPE_IDENTITY();

    INSERT INTO Product([Name], [ManufacturerId])
    SELECT [Name], @manufacturerId FROM @products
END
