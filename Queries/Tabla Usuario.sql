--3
CREATE TABLE STRANGER_STRINGS.Usuario(
Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
Usuario varchar(255),
Password varchar(255),
Cantidad_Intentos smallint,
)