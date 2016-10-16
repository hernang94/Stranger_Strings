--1er Consulta
CREATE TABLE STRANGER_STRINGS.Direccion(
Id_Direccion INT IDENTITY(1,1) PRIMARY KEY,
Calle VARCHAR(255),
Numero NUMERIC(5,0),
Piso NUMERIC(2,0),
Departamento CHAR(2),
Codigo_Postal NUMERIC(6,0),
Localidad VARCHAR(255),
Provincia VARCHAR(255),
Pais VARCHAR(255),
)