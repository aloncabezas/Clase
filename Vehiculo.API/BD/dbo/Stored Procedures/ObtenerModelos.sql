 CREATE PROCEDURE ObtenerModelos
AS
BEGIN
    SELECT 
        Id,
        Nombre,
        IdMarca
    FROM 
        Modelos
END
