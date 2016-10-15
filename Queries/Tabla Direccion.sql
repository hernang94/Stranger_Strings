--1er Consulta
CREATE TABLE STRANGER_STRINGS.Direccion(
Id_Direccion INT IDENTITY(1,1) CONSTRAINT PK_Id_Direccion PRIMARY KEY,
Calle varchar(255),
Numero numeric(5,0),
Piso numeric(2,0),
Departamento char(2),
Codigo_Postal numeric (6,0),
Localidad varchar(255),
Provincia varchar(255),
Pais varchar(255),
)