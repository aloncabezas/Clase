CREATE PROCEDURE EditarModelo
    @Id UNIQUEIDENTIFIER,
    @IdMarca UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        UPDATE [dbo].[Modelos]
        SET IdMarca = @IdMarca,
            Nombre = @Nombre
        WHERE Id = @Id;

        SELECT @Id AS IdEditado;
    COMMIT TRANSACTION
END