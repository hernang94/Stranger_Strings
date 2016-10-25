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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Cancelacion_Turno'))
    DROP TABLE STRANGER_STRINGS.Cancelacion_Turno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Turno'))
    DROP TABLE STRANGER_STRINGS.Turno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Consulta'))
    DROP TABLE STRANGER_STRINGS.Consulta

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
Codigo_Plan INT PRIMARY KEY,
Descripcion VARCHAR(255),
Precio_Bono_Consulta NUMERIC(18,0),
Precio_Bono_Farmacia NUMERIC(18,0)
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Usuario(
Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
--Por default en la migración defino como usuario el dni
Usuario VARCHAR(255),
--Le saque la segunda s porque lo tomaba como una palabra reservada ponele
--Por default es el apellido en la migración
--Con varybinary se ve joya el hash y se guarda como corresponde
Pasword VARBINARY(255),
Cantidad_Intentos SMALLINT,
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Paciente(
Id_Paciente INT IDENTITY(1,1) PRIMARY KEY,
Num_Afiliado_Raiz NUMERIC(20,0),
Num_Afiliado_Resto NUMERIC(2,0),
Nombre VARCHAR(255),
Apellido VARCHAR(255),
Tipo_Doc VARCHAR(10),
Num_Doc NUMERIC(18,0),
Direccion VARCHAR(255),
Telefono NUMERIC(18,0),
Mail VARCHAR(255),
Fecha_Nac DATETIME,
Sexo CHAR(1) CHECK(Sexo = 'F' OR Sexo = 'M' OR Sexo IS NULL),
Estado_Civil VARCHAR(15),
Familiares_A_Cargo INT,
Codigo_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Codigo_Plan),
Cantidad_Consulta INT,
Id_Usuario INT  FOREIGN KEY REFERENCES STRANGER_STRINGS.Usuario(Id_Usuario),
)
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Compra(
Id_Compra INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Compra datetime,
Cantidad_Bonos INT,
Importe_Total NUMERIC(7,2),
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
Codigo_Plan_Viejo INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Codigo_Plan),
Codigo_Plan_Nuevo INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Codigo_Plan))
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
Sexo CHAR(1) CHECK(Sexo = 'F' OR Sexo = 'M' OR Sexo IS NULL),
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
Codigo_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Codigo_Plan),
Numero_Consulta INT,
Id_Compra INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Compra(Id_Compra))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Consulta(
Id_Consulta INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Y_Hora DATETIME,
Sintomas VARCHAR(225),
Enfermedades VARCHAR(225),
Bono_Consulta_Id INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Bono(Id_Bono),
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Turno(
Turno_Numero INT IDENTITY(1,1) PRIMARY KEY,
Turno_Fecha DATETIME,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Medico INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Medico(Id_Medico),
Id_Consulta INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Consulta(Id_Consulta),
--Cambio la FK a la tabla de Cancelación. La cancelación tiene que tener obligatoriamente el turno que se
--cancela, en cambio los turnos no tienen porque tener una fk porque no siempre son cancelados
--Id_Cancelacion INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Cancelacion_Turno(Id_Cancelacion),
Id_Horario INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Horarios_Agenda(Id_Horario))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Cancelacion_Turno(
Id_Cancelacion INT IDENTITY(1,1) PRIMARY KEY,
Id_Turno INT FOREIGN KEY REFERENCES STRANGER_STRINGS.TURNO(Turno_Numero),
Tipo_Cancelacion CHAR(1) CHECK(Tipo_Cancelacion = 'A' OR Tipo_Cancelacion = 'M'),
Motivo VARCHAR(225))
-----------------------------------------------------------

--Fin de creacion de tablas

--Migracion

------------------------------------------------
INSERT INTO STRANGER_STRINGS.Especialidad
SELECT DISTINCT m.Especialidad_Codigo, m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo, m.Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Especialidad_Codigo IS NOT NULL
ORDER BY 1 ASC
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Medico(Nombre,Apellido,Num_Doc,Direccion,Telefono,Mail,Fecha_Nac)
SELECT DISTINCT m.Medico_Nombre,m.Medico_Apellido,m.Medico_Dni,m.Medico_Direccion,m.Medico_Telefono,m.Medico_Mail,m.Medico_Fecha_Nac
FROM gd_esquema.Maestra m
WHERE m.Medico_Nombre IS NOT NULL
UPDATE STRANGER_STRINGS.Medico 
SET Tipo_Doc='DNI'
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Especialidad_X_Medico(Id_Medico,Especialidad_Codigo)
SELECT DISTINCT m.Id_Medico, e.Especialidad_Codigo
FROM STRANGER_STRINGS.Medico m JOIN gd_esquema.Maestra e ON (m.Num_Doc=e.Medico_Dni)
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Plan_Medico(Codigo_Plan,Descripcion,Precio_Bono_Consulta,Precio_Bono_Farmacia)
SELECT DISTINCT e.Plan_Med_Codigo,e.Plan_med_Descripcion,e.Plan_Med_Precio_Bono_Consulta,e.Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra e
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Paciente(Nombre,Apellido,Num_Doc,Direccion,Telefono,Mail,Fecha_Nac,Codigo_Plan)
SELECT DISTINCT e.Paciente_Nombre,e.Paciente_Apellido,e.Paciente_Dni,e.Paciente_Direccion,e.Paciente_Telefono,e.Paciente_Mail,e.Paciente_Fecha_Nac,e.Plan_Med_Codigo
FROM gd_esquema.Maestra e
WHERE e.Paciente_Nombre IS NOT NULL
UPDATE STRANGER_STRINGS.Paciente
SET Tipo_Doc='DNI'
UPDATE STRANGER_STRINGS.Paciente
SET Cantidad_Consulta = 0
------------------------------------------------
SET IDENTITY_INSERT STRANGER_STRINGS.Turno ON
GO
INSERT INTO STRANGER_STRINGS.Turno(Turno_Numero,Turno_Fecha,Id_Paciente,Id_Medico)
SELECT DISTINCT e.Turno_Numero, e.Turno_Fecha,m.Id_Paciente,d.Id_Medico
FROM STRANGER_STRINGS.Paciente m JOIN gd_esquema.Maestra e ON(m.Num_Doc=e.Paciente_Dni) JOIN STRANGER_STRINGS.Medico d ON(e.Medico_Dni=d.Num_Doc)
WHERE Turno_Numero IS NOT NULL 
SET IDENTITY_INSERT STRANGER_STRINGS.Turno OFF
GO
--SELECT * FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Medico m ON(t.Id_Medico=m.Id_Medico
------------------------------------------------
SET IDENTITY_INSERT STRANGER_STRINGS.Bono ON
GO
INSERT INTO STRANGER_STRINGS.Bono(Id_Bono,Fecha_Impresion,Id_Paciente_Compro,Id_Paciente_Uso,Codigo_Plan)
SELECT DISTINCT e.Bono_Consulta_Numero,e.Bono_Consulta_Fecha_Impresion,p.Id_Paciente ,p.Id_Paciente, e.Plan_Med_Codigo
FROM gd_esquema.Maestra e JOIN STRANGER_STRINGS.Paciente p on(e.Paciente_Dni=p.Num_Doc)
WHERE e.Bono_Consulta_Numero IS NOT NULL AND e.Consulta_Sintomas IS NOT NULL 
ORDER BY Bono_Consulta_Numero ASC
SET IDENTITY_INSERT STRANGER_STRINGS.Bono OFF
GO
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Consulta(Sintomas,Enfermedades,Fecha_Y_Hora,Bono_Consulta_Id,Id_Paciente)
SELECT m.Consulta_Sintomas,m.Consulta_Enfermedades,m.Turno_Fecha,b.Id_Bono,b.Id_Paciente_Uso
FROM gd_esquema.Maestra m, STRANGER_STRINGS.Bono b
WHERE m.Bono_Consulta_Numero=b.Id_Bono and m.Consulta_Sintomas IS NOT NULL
ORDER BY b.Id_Bono
------------------------------------------------
INSERT INTO STRANGER_STRINGS.Compra (Fecha_Compra,Id_Paciente,Cantidad_Bonos,Importe_Total)
SELECT DISTINCT b.Fecha_Impresion,b.Id_Paciente_Uso,COUNT(b.Id_Bono), SUM(p.Precio_Bono_Consulta)
FROM STRANGER_STRINGS.Bono b, STRANGER_STRINGS.Plan_Medico p
WHERE b.Codigo_Plan=p.Codigo_Plan
GROUP BY b.Fecha_Impresion,b.Id_Paciente_Uso
ORDER BY b.Id_Paciente_Uso,b.Fecha_Impresion

UPDATE STRANGER_STRINGS.Bono 
SET Id_Compra=c.Id_Compra
FROM STRANGER_STRINGS.Bono b JOIN STRANGER_STRINGS.Compra c ON(b.Id_Paciente_Uso=c.Id_Paciente)
WHERE b.Fecha_Impresion=c.Fecha_Compra

UPDATE STRANGER_STRINGS.Bono
SET Numero_Consulta=
(SELECT tabla1.Fila FROM (SELECT ROW_NUMBER() OVER(ORDER BY c.Fecha_Y_Hora) AS Fila,c.Bono_Consulta_Id as nro_bono
FROM STRANGER_STRINGS.Consulta c
WHERE c.Id_Paciente=bn.Id_Paciente_Uso ) As tabla1
WHERE tabla1.nro_bono=bn.Id_Bono)
FROM STRANGER_STRINGS.Bono bn

UPDATE STRANGER_STRINGS.Paciente
SET Cantidad_Consulta=
(SELECT tabla1.cantidad FROM(
SELECT COUNT (*) as cantidad, Id_Paciente FROM STRANGER_STRINGS.Consulta
GROUP BY Id_Paciente) as tabla1
WHERE tabla1.Id_Paciente=p.Id_Paciente)
FROM STRANGER_STRINGS.Paciente p



------------------------------------------------ FIN MIGRACION

--SETEO DE USUARIOS, ROLES y FUNCIONALIDADES
--FUNCIONALIDADES
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('ABM de Afiliado')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('ABM de Rol')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Compra de Bonos')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Solicitar Turno')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Registro de Llegada')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Registro de Resultado')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Cancelar Atención Médica')
INSERT INTO STRANGER_STRINGS.Funcionalidad(Descripcion)
VALUES('Listado Estadístico')

--ROLES
INSERT INTO STRANGER_STRINGS.Rol(Descripcion)
VALUES('Administrador')
INSERT INTO STRANGER_STRINGS.Rol(Descripcion)
VALUES('Afiliado')
INSERT INTO STRANGER_STRINGS.Rol(Descripcion)
VALUES('Profesional')

--FUNCIONALIDADES X ROL
INSERT INTO STRANGER_STRINGS.Funcionalidad_X_Rol(Id_Rol,Id_Funcionalidad)
SELECT r.Id_Rol, f.Id_Funcionalidad
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Funcionalidad f
WHERE r.Descripcion='Administrador' AND f.Descripcion in ('ABM de Afiliado','ABM de Rol','Registro de Llegada','Listado Estadístico')

INSERT INTO STRANGER_STRINGS.Funcionalidad_X_Rol(Id_Rol,Id_Funcionalidad)
SELECT r.Id_Rol, f.Id_Funcionalidad
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Funcionalidad f
WHERE r.Descripcion='Afiliado' AND f.Descripcion in ('Compra de Bonos','Solicitar Turno','Cancelar Atención Médica')

INSERT INTO STRANGER_STRINGS.Funcionalidad_X_Rol(Id_Rol,Id_Funcionalidad)
SELECT r.Id_Rol, f.Id_Funcionalidad
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Funcionalidad f
WHERE r.Descripcion='Profesional' AND f.Descripcion in ('Cancelar Atención Médica','Registro de Resultado')

--USUARIOS Y ROLES X USUARIO
INSERT INTO STRANGER_STRINGS.Usuario(Usuario,Pasword) VALUES ('admin',HASHBYTES('SHA2_256','w23e'))
INSERT INTO STRANGER_STRINGS.Rol_X_Usuario (r.Id_Rol,u.Id_Usuario)
SELECT r.Id_Rol,u.Id_Usuario
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Usuario u
WHERE r.Descripcion LIKE 'Administrador' AND u.Usuario LIKE 'admin' AND u.Pasword=HASHBYTES('SHA2_256','w23e')


INSERT INTO STRANGER_STRINGS.Usuario(Usuario,Pasword)
SELECT CONVERT(VARCHAR,p.Num_Doc) As Usuario, HASHBYTES('SHA2_256',p.Apellido)
FROM STRANGER_STRINGS.Paciente p

INSERT INTO STRANGER_STRINGS.Rol_X_Usuario(Id_Rol,Id_Usuario)
SELECT r.Id_Rol,u.Id_Usuario
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Usuario u JOIN STRANGER_STRINGS.Paciente p ON(CONVERT(VARCHAR,p.Num_Doc)=u.Usuario)
WHERE r.Descripcion LIKE 'Afiliado'

INSERT INTO STRANGER_STRINGS.Usuario(Usuario,Pasword)
SELECT CONVERT(VARCHAR,Num_Doc) As Usuario, HASHBYTES('SHA2_256',Apellido)
FROM STRANGER_STRINGS.Medico

INSERT INTO STRANGER_STRINGS.Rol_X_Usuario(Id_Rol,Id_Usuario)
SELECT r.Id_Rol,u.Id_Usuario
FROM STRANGER_STRINGS.Rol r,STRANGER_STRINGS.Usuario u JOIN STRANGER_STRINGS.Medico m ON(CONVERT(VARCHAR,m.Num_Doc)=u.Usuario)
WHERE r.Descripcion LIKE 'Profesional'

UPDATE STRANGER_STRINGS.Usuario
SET Cantidad_Intentos=3

UPDATE STRANGER_STRINGS.Paciente
SET Id_Usuario=
(SELECT u.Id_Usuario FROM STRANGER_STRINGS.Usuario u
WHERE u.Usuario=CONVERT(VARCHAR,p.Num_Doc))
FROM STRANGER_STRINGS.Paciente p

UPDATE STRANGER_STRINGS.Medico
SET Id_Usuario=
(SELECT u.Id_Usuario FROM STRANGER_STRINGS.Usuario u
WHERE u.Usuario=CONVERT(VARCHAR,m.Num_Doc))
FROM STRANGER_STRINGS.Medico m

--FIN SETEO DE USUARIOS



--***STORED PROCEDURE LOGIN(PENDIENTE DE REVISION)***
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_LOGIN')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_LOGIN
GO
CREATE PROCEDURE STRANGER_STRINGS.SP_LOGIN
@Usuario varchar(255), 
@Pass varchar(255),
@Bit INT OUTPUT
AS
BEGIN
IF EXISTS(
SELECT u.Usuario,u.Pasword
FROM STRANGER_STRINGS.Usuario u JOIN STRANGER_STRINGS.Rol_X_Usuario r ON(u.Id_Usuario=r.Id_Usuario)
WHERE @Usuario=u.Usuario AND HASHBYTES('SHA2_256',@Pass)=u.Pasword)
SET @Bit=1
ELSE
SET @Bit=0
END
GO
-----------------------------------------