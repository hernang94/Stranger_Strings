--10
CREATE TABLE STRANGER_STRINGS.Funcionalidad_X_Rol(
Id_Rol INT IDENTITY(1,1),
Id_Funcionalidad INT IDENTITY(1,1),
CONSTRAINT PK_Id_Funcionalidad_X_Rol PRIMARY KEY (Id_Rol, Id_Funcionalidad),
CONSTRAINT FK_Rol FOREIGN KEY (Id_Rol) REFERENCES STRANGER_STRINGS.Rol (Id_Rol),
CONSTRAINT FK_Funcionalidad FOREIGN KEY (Id_Funcionalidad) REFERENCES STRANGER_STRINGS.Funcionalidad (Id_Funcionalidad))