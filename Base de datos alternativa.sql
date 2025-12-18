/* ============================
   CREAR BASE DE DATOS
   ============================ */
CREATE DATABASE AgendaContactosDB;
GO

USE AgendaContactosDB;
GO

/* ============================
   TABLA PRINCIPAL: CONTACTOS
   ============================ */
CREATE TABLE Contactos (
    IdContacto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Direccion VARCHAR(200),
    Instagram VARCHAR(100),
    Facebook VARCHAR(100),
    LinkedIn VARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

/* ============================
   DATOS DE PRUEBA (OPCIONAL)
   ============================ */
INSERT INTO Contactos 
(Nombre, Telefono, Direccion, Instagram, Facebook, LinkedIn)
VALUES
('Juan Perez', '8095551234', 'Santo Domingo', '@juanperez', 'facebook.com/juanperez', 'linkedin.com/in/juanperez'),
('Maria Gomez', '8294445678', 'Santiago', '@mariagomez', 'facebook.com/mariagomez', 'linkedin.com/in/mariagomez'),
('Carlos Ramirez', '8493339988', 'La Vega', '@carlosramirez', 'facebook.com/carlosramirez', 'linkedin.com/in/carlosramirez');
GO

/* ============================
   VISTA PARA LISTAR CONTACTOS
   ============================ */
CREATE VIEW vw_Contactos AS
SELECT 
    IdContacto,
    Nombre,
    Telefono,
    Direccion,
    Instagram,
    Facebook,
    LinkedIn,
    FechaRegistro
FROM Contactos;
GO

/* ============================
   PROCEDIMIENTO: INSERTAR
   ============================ */
CREATE PROCEDURE sp_InsertarContacto
    @Nombre VARCHAR(100),
    @Telefono VARCHAR(20),
    @Direccion VARCHAR(200),
    @Instagram VARCHAR(100),
    @Facebook VARCHAR(100),
    @LinkedIn VARCHAR(100)
AS
BEGIN
    INSERT INTO Contactos
    (Nombre, Telefono, Direccion, Instagram, Facebook, LinkedIn)
    VALUES
    (@Nombre, @Telefono, @Direccion, @Instagram, @Facebook, @LinkedIn)
END;
GO

/* ============================
   PROCEDIMIENTO: LISTAR
   ============================ */
CREATE PROCEDURE sp_ListarContactos
AS
BEGIN
    SELECT * FROM vw_Contactos
    ORDER BY Nombre;
END;
GO

/* ============================
   PROCEDIMIENTO: BUSCAR
   ============================ */
CREATE PROCEDURE sp_BuscarContacto
    @Texto VARCHAR(100)
AS
BEGIN
    SELECT * FROM vw_Contactos
    WHERE Nombre LIKE '%' + @Texto + '%'
       OR Telefono LIKE '%' + @Texto + '%';
END;
GO
