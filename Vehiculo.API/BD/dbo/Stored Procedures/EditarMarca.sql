CREATE PROCEDURE EditarMarca
    @Id uniqueidentifier,
    @Nombre varchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
    UPDATE [dbo].[Marcas]
    SET [Nombre] = @Nombre
    WHERE Id = @Id

    SELECT @Id
    COMMIT TRANSACTION
END