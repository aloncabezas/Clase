CREATE PROCEDURE AgregarModelo
    @Id UNIQUEIDENTIFIER,
    @IdMarca UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        INSERT INTO [dbo].[Modelos] ([Id], [IdMarca], [Nombre])
        VALUES (@Id, @IdMarca, @Nombre);

        SELECT @Id AS IdInsertado;
    COMMIT TRANSACTION
END