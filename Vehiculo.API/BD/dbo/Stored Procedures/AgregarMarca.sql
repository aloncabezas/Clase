CREATE PROCEDURE AgregarMarca
    @Id UNIQUEIDENTIFIER,
    @Nombre VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        INSERT INTO [dbo].[Marcas] ([Id], [Nombre])
        VALUES (@Id, @Nombre);

        SELECT @Id;
    COMMIT TRANSACTION
END