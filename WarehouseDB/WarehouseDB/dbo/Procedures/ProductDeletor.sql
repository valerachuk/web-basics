CREATE PROCEDURE [dbo].[ProductDeletor]
    @productId int
AS
    DELETE FROM Product
    WHERE Id = @productId
