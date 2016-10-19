--Selecciono BD

USE GD2C2016
GO

--Si no existe el esquema lo creo

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'STRANGER_STRINGS')
BEGIN
    EXEC ('CREATE SCHEMA STRANGER_STRINGS AUTHORIZATION gd')
END
GO

--Si existen las tablas las dropeo

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Turno'))
    DROP TABLE STRANGER_STRINGS.Turno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Consulta'))
    DROP TABLE STRANGER_STRINGS.Consulta

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Cancelacion_Turno'))
    DROP TABLE STRANGER_STRINGS.Cancelacion_Turno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Bono'))
    DROP TABLE STRANGER_STRINGS.Bono

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Horarios_Agenda'))
    DROP TABLE STRANGER_STRINGS.Horarios_Agenda

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Especialidad_X_Medico'))
    DROP TABLE STRANGER_STRINGS.Especialidad_X_Medico

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Especialidad'))
    DROP TABLE STRANGER_STRINGS.Especialidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Medico'))
    DROP TABLE STRANGER_STRINGS.Medico

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Rol_X_Usuario'))
    DROP TABLE STRANGER_STRINGS.Rol_X_Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Funcionalidad_X_Rol'))
    DROP TABLE STRANGER_STRINGS.Funcionalidad_X_Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Rol'))
    DROP TABLE STRANGER_STRINGS.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Funcionalidad'))
    DROP TABLE STRANGER_STRINGS.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Cambio_Plan'))
    DROP TABLE STRANGER_STRINGS.Cambio_Plan

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Baja_Paciente'))
    DROP TABLE STRANGER_STRINGS.Baja_Paciente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Compra'))
    DROP TABLE STRANGER_STRINGS.Compra

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Paciente'))
    DROP TABLE STRANGER_STRINGS.Paciente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Usuario'))
    DROP TABLE STRANGER_STRINGS.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Plan_Medico'))
    DROP TABLE STRANGER_STRINGS.Plan_Medico

--Fin de chequeo de tablas

--Creacion de tablas 

CREATE TABLE STRANGER_STRINGS.Plan_Medico(
Id_Plan INT IDENTITY(1,1) PRIMARY KEY,
Descripcion VARCHAR(255),
Precio_Bono_Consulta NUMERIC(18,0),
Precio_Bono_Farmacia NUMERIC(18,0)
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Usuario(
Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
Usuario VARCHAR(255),
Password VARCHAR(255),
Cantidad_Intentos SMALLINT,
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Paciente(
Id_Paciente INT IDENTITY(1,1) PRIMARY KEY,
Num_Afiliado_Raiz NUMERIC(20,0) UNIQUE,
Num_Afiliado_Resto NUMERIC(2,0) UNIQUE,
Nombre VARCHAR(255),
Apellido VARCHAR(255),
Tipo_Doc VARCHAR(10),
Num_Doc NUMERIC(18,0),
Direccion VARCHAR(255),
Telefono NUMERIC(18,0),
Mail VARCHAR(255),
Fecha_Nac DATETIME,
Sexo CHAR(1) CHECK(Sexo = 'F' OR Sexo = 'M'),
Estado_Civil VARCHAR(15),
Familiares_A_Cargo INT,
Id_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Id_Plan),
Cantidad_Consulta INT,
Id_Usuario INT  FOREIGN KEY REFERENCES STRANGER_STRINGS.Usuario(Id_Usuario),
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Compra(
Id_Compra INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Compra datetime,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Baja_Paciente(
Id_Baja INT IDENTITY(1,1) CONSTRAINT PK_Id_Baja PRIMARY KEY,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Fecha_Baja DATETIME)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Cambio_Plan(
Id_Cambio INT IDENTITY(1,1)PRIMARY KEY,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Motivo VARCHAR(255),
Id_Plan_Viejo INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Id_Plan),
Id_Plan_Nuevo INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Id_Plan))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Funcionalidad(
Id_Funcionalidad INT IDENTITY(1,1) PRIMARY KEY,
Descripcion VARCHAR(225))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Rol(
Id_Rol INT IDENTITY(1,1)PRIMARY KEY,
Descripcion VARCHAR(225))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Funcionalidad_X_Rol(
Id_Rol INT ,
Id_Funcionalidad INT ,
PRIMARY KEY (Id_Rol, Id_Funcionalidad),
FOREIGN KEY (Id_Rol) REFERENCES STRANGER_STRINGS.Rol (Id_Rol),
FOREIGN KEY (Id_Funcionalidad) REFERENCES STRANGER_STRINGS.Funcionalidad (Id_Funcionalidad))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Rol_X_Usuario(
Id_Rol INT ,
Id_Usuario INT ,
PRIMARY KEY (Id_Rol, Id_Usuario),
FOREIGN KEY (Id_Rol) REFERENCES STRANGER_STRINGS.Rol (Id_Rol),
FOREIGN KEY (Id_Usuario) REFERENCES STRANGER_STRINGS.Usuario (Id_Usuario))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Medico(
Id_Medico INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(225),
Apellido VARCHAR(225),
Tipo_Doc VARCHAR(225),
Num_Doc NUMERIC(18,0),
Direccion VARCHAR(255),
Telefono NUMERIC(18,0),
Mail VARCHAR(225),
Fecha_Nac DATETIME,
Sexo CHAR(1) CHECK(Sexo = 'F' OR Sexo = 'M'),
Id_Usuario INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Usuario(Id_Usuario))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Especialidad(
Especialidad_Codigo NUMERIC(18,0) PRIMARY KEY,
Especialidad_Descripcion VARCHAR(225),
Tipo_Especialidad_Codigo NUMERIC(18,0),
Tipo_Especialidad_Descripcion VARCHAR(225))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Especialidad_X_Medico(
Id INT IDENTITY(1,1),
Id_Medico INT ,
Especialidad_Codigo NUMERIC(18,0) ,
PRIMARY KEY (Id_Medico, Id, Especialidad_Codigo),
FOREIGN KEY (Id_Medico) REFERENCES STRANGER_STRINGS.Medico (Id_Medico),
FOREIGN KEY (Especialidad_Codigo) REFERENCES STRANGER_STRINGS.Especialidad (Especialidad_Codigo))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Horarios_Agenda(
Id_Horario INT IDENTITY(1,1) PRIMARY KEY,
Dia SMALLINT,
Hora_Desde TIME,
Hora_Hasta TIME,
Id_Especialidad NUMERIC(18,0) FOREIGN KEY REFERENCES STRANGER_STRINGS.Especialidad(Especialidad_Codigo))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Bono(
Id_Bono INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Compra DATETIME,
Fecha_Impresion DATETIME,
Id_Paciente_Compro INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Paciente_Uso INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Id_Plan),
Numero_Consulta INT,
Id_Compra INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Compra(Id_Compra))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Cancelacion_Turno(
Id_Cancelacion INT IDENTITY(1,1) PRIMARY KEY,
Tipo_Cancelacion CHAR(1) CHECK(Tipo_Cancelacion = 'A' OR Tipo_Cancelacion = 'M'),
Motivo VARCHAR(225))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Consulta(
Id_Consulta INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Y_Hora DATETIME,
Sintomas VARCHAR(225),
Enfermedades VARCHAR(225),
Bono_Consulta_Id INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Bono(Id_Bono))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Turno(
Turno_Numero INT IDENTITY(1,1) PRIMARY KEY,
Turno_Fecha DATETIME,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Medico INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Medico(Id_Medico),
Id_Consulta INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Consulta(Id_Consulta),
Id_Cancelacion INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Cancelacion_Turno(Id_Cancelacion),
Id_Horario INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Horarios_Agenda(Id_Horario))
-----------------------------------------------------------

--Fin de creacion de tablas