CREATE PROCEDURE ObtenerMarca
    @Id uniqueidentifier
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Nombre
    FROM Marcas
    WHERE Id = @Id
END