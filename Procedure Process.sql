CREATE PROCEDURE USP_GetProducto
@Nombre VARCHAR,
@Estado BIT=NULL
AS
BEGIN
SELECT Id, Nombre, Precio, Estado
FROM Lab_Producto
WHERE (Estado=@Estado OR @Estado IS NULL)
END

CREATE PROCEDURE USP_InsertProducto
@Id INT,
@Nombre VARCHAR(50),
@Precio INT,
@Estado BIT=NULL
AS
BEGIN
INSERT INTO Lab_Producto(Id,Nombre,Precio,Estado) VALUES (@Id,@Nombre,@Precio,@Estado)
END

CREATE PROCEDURE USP_UpdateProducto
@Id INT,
@Nombre VARCHAR(50),
@Precio INT,
@Estado BIT=NULL
AS
BEGIN
UPDATE Lab_Producto SET Nombre = @Nombre, Precio = @Precio, Estado = @Estado
WHERE Id = @Id
END

CREATE PROCEDURE USP_DeleteProducto
@Id INT,
@Estado BIT=NULL
AS
BEGIN
UPDATE Lab_Producto SET Estado = @Estado
WHERE Id = @Id
END
