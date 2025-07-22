CREATE PROCEDURE ObtenerModelosPorMarca
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, IdMarca, Nombre
    FROM [dbo].[Modelos]
    WHERE IdMarca = @IdMarca;
END