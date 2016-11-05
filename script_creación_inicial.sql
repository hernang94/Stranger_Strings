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
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Registro_Cancelacion_Medico'))
    DROP TABLE STRANGER_STRINGS.Registro_Cancelacion_Medico

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Turno'))
    DROP TABLE STRANGER_STRINGS.Turno

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'STRANGER_STRINGS.Cancelacion_Turno'))
    DROP TABLE STRANGER_STRINGS.Cancelacion_Turno

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
Familiares_A_Cargo NUMERIC(10,0),
Codigo_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Codigo_Plan),
Cantidad_Consulta INT,
Id_Usuario INT  FOREIGN KEY REFERENCES STRANGER_STRINGS.Usuario(Id_Usuario),
Estado_Afiliado CHAR(1) CHECK(Estado_Afiliado = 'A' OR Estado_Afiliado = 'D' OR Estado_Afiliado IS NULL),
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
Descripcion VARCHAR(225),
Estado CHAR(1)CHECK(Estado = 'E' OR Estado = 'D' OR Estado IS NULL))
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
PRIMARY KEY (Id),
FOREIGN KEY (Id_Medico) REFERENCES STRANGER_STRINGS.Medico (Id_Medico),
FOREIGN KEY (Especialidad_Codigo) REFERENCES STRANGER_STRINGS.Especialidad (Especialidad_Codigo))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Horarios_Agenda(
Id_Horario INT IDENTITY(1,1) PRIMARY KEY,
Dia SMALLINT,
Hora_Desde TIME,
Hora_Hasta TIME,
Id_Especialidad_Medico INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Especialidad_X_Medico(Id))
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
Fecha_Y_Hora_Llegada DATETIME,
Fecha_Y_Hora_Atencion DATETIME,
Sintomas VARCHAR(225),
Enfermedades VARCHAR(225),
Bono_Consulta_Id INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Bono(Id_Bono),
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Cancelacion_Turno(
Id_Cancelacion INT IDENTITY(1,1) PRIMARY KEY,
Tipo_Cancelacion CHAR(1) CHECK(Tipo_Cancelacion = 'A' OR Tipo_Cancelacion = 'M'),
Motivo VARCHAR(225))

-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Turno(
Turno_Numero INT IDENTITY(1,1) PRIMARY KEY,
Turno_Fecha DATETIME,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Medico_x_Esp INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Especialidad_X_Medico(Id),
Id_Consulta INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Consulta(Id_Consulta),
--Cambio la FK a la tabla de Cancelación. La cancelación tiene que tener obligatoriamente el turno que se
--cancela, en cambio los turnos no tienen porque tener una fk porque no siempre son cancelados
Id_Cancelacion INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Cancelacion_Turno(Id_Cancelacion),
Id_Horario INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Horarios_Agenda(Id_Horario))
-----------------------------------------------------------
CREATE TABLE STRANGER_STRINGS.Registro_Cancelacion_Medico(
Id_Registro INT IDENTITY(1,1) PRIMARY KEY,
Id_Med INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Medico(Id_Medico),
Dia_Desde DATETIME,
Dia_Hasta DATETIME
)

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
UPDATE STRANGER_STRINGS.Paciente
SET Estado_Afiliado = 'A'
CREATE NONCLUSTERED INDEX IX_DNI_PACIENTE ON STRANGER_STRINGS.Paciente(Num_Doc)
GO
------------------------------------------------
SET IDENTITY_INSERT STRANGER_STRINGS.Turno ON
GO
INSERT INTO STRANGER_STRINGS.Turno(Turno_Numero,Turno_Fecha,Id_Paciente,Id_Medico_x_Esp)
SELECT DISTINCT e.Turno_Numero, e.Turno_Fecha,m.Id_Paciente,(SELECT Id FROM STRANGER_STRINGS.Especialidad_X_Medico es WHERE es.Especialidad_Codigo=e.Especialidad_Codigo AND es.Id_Medico=d.Id_Medico) as Id_Medico
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
INSERT INTO STRANGER_STRINGS.Consulta(Sintomas,Enfermedades,Fecha_Y_Hora_Llegada,Fecha_Y_Hora_Atencion,Bono_Consulta_Id,Id_Paciente)
SELECT m.Consulta_Sintomas,m.Consulta_Enfermedades,m.Turno_Fecha,m.Turno_Fecha,b.Id_Bono,b.Id_Paciente_Uso
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
(SELECT tabla1.Fila FROM (SELECT ROW_NUMBER() OVER(ORDER BY c.Fecha_Y_Hora_Llegada) AS Fila,c.Bono_Consulta_Id as nro_bono
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

UPDATE STRANGER_STRINGS.Turno
SET Id_Consulta=(SELECT TOP 1 id_cons FROM
(SELECT c.Id_Consulta as id_cons, c.Id_Paciente as id_pas, c.Fecha_Y_Hora_Llegada as fecha 
FROM STRANGER_STRINGS.Consulta c 
JOIN STRANGER_STRINGS.Bono b ON(b.Id_Bono=c.Bono_Consulta_Id))As tablaAux
WHERE  tablaAux.id_pas=Id_Paciente AND tablaAux.fecha=Turno_Fecha )

UPDATE STRANGER_STRINGS.TURNO
SET Id_Horario = (SELECT Id_Horario FROM STRANGER_STRINGS.Horarios_Agenda h
WHERE h.Id_Especialidad_Medico=t.Id_Medico_x_Esp AND h.Dia=DATEPART(DW,t.Turno_Fecha) AND CONVERT(TIME,t.Turno_Fecha) BETWEEN h.Hora_Desde AND h.Hora_Hasta)
FROM STRANGER_STRINGS.Turno t

UPDATE STRANGER_STRINGS.Paciente
SET Sexo = 'M'

UPDATE STRANGER_STRINGS.Paciente
SET Estado_Civil = 'Soltero/a'

UPDATE STRANGER_STRINGS.Paciente
SET Familiares_A_Cargo = 0,Num_Afiliado_Raiz = REVERSE(Num_Doc),Num_Afiliado_Resto=01

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
INSERT INTO STRANGER_STRINGS.Rol(Descripcion,Estado)
VALUES('Administrador','E')
INSERT INTO STRANGER_STRINGS.Rol(Descripcion,Estado)
VALUES('Afiliado','E')
INSERT INTO STRANGER_STRINGS.Rol(Descripcion,Estado)
VALUES('Profesional','E')

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
WHERE r.Descripcion IN ('Administrador','Afiliado','Profesional') AND u.Usuario LIKE 'admin' AND u.Pasword=HASHBYTES('SHA2_256','w23e')


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

--INSERT DE AGENDA--
--CREO TABLA TEMPORAL
SELECT me.Id,m.Num_Doc,e.Especialidad_Codigo
INTO STRANGER_STRINGS.#Medicos_x_Especialidad_AUX
FROM STRANGER_STRINGS.Especialidad_X_Medico me JOIN STRANGER_STRINGS.Medico m ON(m.Id_Medico=me.Id_Medico) 
JOIN STRANGER_STRINGS.Especialidad e ON(me.Especialidad_Codigo=e.Especialidad_Codigo)

INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28072053	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10006	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10026	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10017	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54980698	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	65090855	AND Especialidad_Codigo =	10039	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	97196837	AND Especialidad_Codigo =	10034	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10048	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54030479	AND Especialidad_Codigo =	10029	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	9954476	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	27123524	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10000	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10025	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86815204	AND Especialidad_Codigo =	10022	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST( '2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10025	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10015	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(1	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	96743144	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28072053	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10006	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10026	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10017	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54980698	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	97196837	AND Especialidad_Codigo =	10036	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10048	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54030479	AND Especialidad_Codigo =	10029	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	9954476	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	27123524	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10000	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10025	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86815204	AND Especialidad_Codigo =	10022	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10025	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(2	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	96743144	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28072053	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10006	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10026	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54980698	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	65090855	AND Especialidad_Codigo =	10039	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	97196837	AND Especialidad_Codigo =	10034	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10014	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10048	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54030479	AND Especialidad_Codigo =	10029	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	88421890	AND Especialidad_Codigo =	10021	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	9954476	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	46998467	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10025	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86815204	AND Especialidad_Codigo =	10022	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10027	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10015	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(3	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	96743144	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28072053	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10006	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	35198771	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10026	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54980698	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	97196837	AND Especialidad_Codigo =	10036	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10014	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10048	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	88421890	AND Especialidad_Codigo =	10021	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	9954476	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	46998467	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(4	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	96743144	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28072053	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10026	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54980698	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10019	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	65090855	AND Especialidad_Codigo =	10039	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	97196837	AND Especialidad_Codigo =	10034	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10010	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	10014	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10048	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	9954476	AND Especialidad_Codigo =	10024	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	27123524	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	46998467	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	92746405	AND Especialidad_Codigo =	10018	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	CAST ('2016-10-01 20:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86815204	AND Especialidad_Codigo =	10022	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10001	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	28036677	AND Especialidad_Codigo =	10027	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 17:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 7:00' AS TIME(0))	,	CAST ('2016-10-01 11:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10015	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	CAST ('2016-10-01 18:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(5	,	CAST ('2016-10-01 8:00' AS TIME(0))	,	CAST ('2016-10-01 16:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	96743144	AND Especialidad_Codigo =	10016	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	86526083	AND Especialidad_Codigo =	10017	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	10675835	AND Especialidad_Codigo =	10038	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	52427724	AND Especialidad_Codigo =	10004	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	54851289	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	80527583	AND Especialidad_Codigo =	10012	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	1465925	AND Especialidad_Codigo =	10033	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	20407720	AND Especialidad_Codigo =	9999	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 14:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	18756896	AND Especialidad_Codigo =	10042	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	72817971	AND Especialidad_Codigo =	10007	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 12:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	27123524	AND Especialidad_Codigo =	10032	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	56949224	AND Especialidad_Codigo =	10020	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	78862992	AND Especialidad_Codigo =	10045	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	3116603	AND Especialidad_Codigo =	10047	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 15:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	93533777	AND Especialidad_Codigo =	10037	))
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia, Hora_Desde, Hora_Hasta, Id_Especialidad_Medico) VALUES	(6	,	CAST ('2016-10-01 10:00' AS TIME(0))	,	CAST ('2016-10-01 13:00' AS TIME(0))	,	(SELECT Id FROM STRANGER_STRINGS.#Medicos_x_Especialidad_AUX WHERE Num_Doc = 	85129809	AND Especialidad_Codigo =	10019	))

DROP TABLE STRANGER_STRINGS.#Medicos_x_Especialidad_AUX
GO
--------------------------------------------------------
--TRIGGER ACTUALIZAR CANT CONSULTAS PACIENTE
IF OBJECT_ID ('STRANGER_STRINGS.TR_ACTUALIZAR_CONSULTAS', 'TR') IS NOT NULL  
   DROP TRIGGER STRANGER_STRINGS.TR_ACTUALIZAR_CONSULTAS; 
GO
CREATE TRIGGER STRANGER_STRINGS.TR_ACTUALIZAR_CONSULTAS
ON STRANGER_STRINGS.Consulta
FOR INSERT
AS 
BEGIN
UPDATE STRANGER_STRINGS.Paciente
SET Cantidad_Consulta +=1
FROM STRANGER_STRINGS.Paciente p, inserted i
WHERE p.Id_Paciente=i.Id_Paciente
END
GO
--------------------------------------------------------

--***STORED PROCEDURE LOGIN***
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
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_ACTUALIZAR_INTENTOS
@Usuario varchar(255)
AS
BEGIN
UPDATE STRANGER_STRINGS.Usuario
SET Cantidad_Intentos=Cantidad_Intentos-1
WHERE Usuario=@Usuario
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_REINICIAR_INTENTOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_REINICIAR_INTENTOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_REINICIAR_INTENTOS
@Usuario varchar(255)
AS
BEGIN
UPDATE STRANGER_STRINGS.Usuario
SET Cantidad_Intentos=3
WHERE Usuario=@Usuario
END
GO

-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_GET_ROLES')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_GET_ROLES
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_GET_ROLES
@Usuario VARCHAR(255)
AS
BEGIN
SELECT r.Descripcion FROM STRANGER_STRINGS.Rol r JOIN STRANGER_STRINGS.Rol_X_Usuario ru ON(r.Id_Rol=ru.Id_Rol) 
JOIN STRANGER_STRINGS.Usuario u ON(u.Id_Usuario=ru.Id_Usuario)
WHERE @Usuario=u.Usuario
END
GO

-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_GET_ESPECIALIDADES')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_GET_ESPECIALIDADES
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_GET_ESPECIALIDADES
@Num_Doc NUMERIC(18,0)
AS
BEGIN
SELECT e.Especialidad_Codigo,e.Especialidad_Descripcion,m.Apellido,m.Nombre 
	FROM STRANGER_STRINGS.Medico m, STRANGER_STRINGS.Especialidad e, STRANGER_STRINGS.Especialidad_X_Medico exm
	WHERE m.Num_Doc=@Num_Doc AND m.Id_Medico=exm.Id_Medico AND e.Especialidad_Codigo=exm.Especialidad_Codigo
END
GO

-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_PEDIR_TURNOS_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNOS_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNOS_AFILIADO
@Num_Doc NUMERIC(18,0)
AS
BEGIN 
SELECT t.Turno_Numero,t.Turno_Fecha,m.Apellido,e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Paciente p ON (p.Id_Paciente=t.Id_Paciente),STRANGER_STRINGS.Medico m ,
STRANGER_STRINGS.Especialidad e
WHERE p.Num_Doc = @Num_Doc 
AND m.Id_Medico=(SELECT Id_Medico FROM STRANGER_STRINGS.Especialidad_X_Medico es WHERE es.Id=t.Id_Medico_x_Esp) 
AND e.Especialidad_Codigo=(SELECT es.Especialidad_Codigo FROM STRANGER_STRINGS.Especialidad_X_Medico es WHERE es.Id=t.Id_Medico_x_Esp)
AND t.Id_Cancelacion IS NULL
END 
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_PEDIR_TURNOS_MEDICO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNOS_MEDICO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNOS_MEDICO
@Num_Doc NUMERIC (18,0)
AS
BEGIN
SELECT t.Turno_Fecha FROM (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AS TablaAux, STRANGER_STRINGS.Turno t
WHERE TablaAux.Id=t.Id_Medico_x_Esp
END
GO
-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CANCELAR_TURNO_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNO_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNO_AFILIADO
--Variables que manda la app
@Turno_Fecha DATETIME,
@Num_Doc NUMERIC(18,0),
@Apellido_Profesional VARCHAR(255),
@Especialidad_Codigo NUMERIC(18,0),
@Tipo_Cancelacion CHAR(1),
@Motivo VARCHAR(225)
AS
BEGIN
--Variables necesarias para realizar la cancelación
DECLARE @Id_Paciente INT= (SELECT Id_Paciente FROM STRANGER_STRINGS.Paciente WHERE Num_Doc=@Num_Doc)
DECLARE @Id_Profesional INT= (SELECT m.Id_Medico FROM STRANGER_STRINGS.Medico m WHERE m.Apellido=@Apellido_Profesional AND m.Id_Medico in(SELECT e.Id_Medico FROM STRANGER_STRINGS.Especialidad_X_Medico e WHERE e.Especialidad_Codigo=@Especialidad_Codigo))
DECLARE @Id_Insert INT
INSERT INTO STRANGER_STRINGS.Cancelacion_Turno(Tipo_Cancelacion,Motivo)
VALUES(@Tipo_Cancelacion,@Motivo)
SET @Id_Insert= SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Turno
SET Id_Cancelacion=@Id_Insert
WHERE Id_Paciente=@Id_Paciente AND DATEDIFF(mi,Turno_Fecha,@Turno_Fecha)=0
END
GO

-----------------------------------------
/*IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL
@Turno_Fecha CHAR(10),
@Num_Doc NUMERIC(18,0),
@Tipo_Cancelacion CHAR(1),
@Motivo VARCHAR(225)
AS
BEGIN
DECLARE @Id_Insert INT
INSERT INTO STRANGER_STRINGS.Cancelacion_Turno(Tipo_Cancelacion,Motivo)
VALUES(@Tipo_Cancelacion,@Motivo)
SET @Id_Insert= SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Turno
SET Id_Cancelacion=@Id_Insert
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND CONVERT(DATE,Turno_Fecha)=CONVERT(DATETIME,RIGHT(@Turno_Fecha,4)+LEFT(@Turno_Fecha,2)+SUBSTRING(@Turno_Fecha,4,2))
UPDATE STRANGER_STRINGS.Turno
SET Id_Horario=NULL
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND CONVERT(DATE,Turno_Fecha)=CONVERT(DATETIME,RIGHT(@Turno_Fecha,4)+LEFT(@Turno_Fecha,2)+SUBSTRING(@Turno_Fecha,4,2))
END
GO*/

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_DIA_PROFESIONAL
@Turno_Fecha DATETIME,
@Num_Doc NUMERIC(18,0),
@Tipo_Cancelacion CHAR(1),
@Motivo VARCHAR(225)
AS
BEGIN
DECLARE @Id_Insert INT
INSERT INTO STRANGER_STRINGS.Cancelacion_Turno(Tipo_Cancelacion,Motivo)
VALUES(@Tipo_Cancelacion,@Motivo)
SET @Id_Insert= SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Turno
SET Id_Cancelacion=@Id_Insert
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND DATEDIFF(dd,Turno_Fecha,@Turno_Fecha)=0
UPDATE STRANGER_STRINGS.Turno
SET Id_Horario=NULL
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND DATEDIFF(dd,Turno_Fecha,@Turno_Fecha)=0
INSERT INTO STRANGER_STRINGS.Registro_Cancelacion_Medico(Id_Med,Dia_Desde,Dia_Hasta) 
VALUES ((SELECT Id_Medico FROM STRANGER_STRINGS.Medico WHERE Num_Doc=@Num_Doc),@Turno_Fecha,@Turno_Fecha)
END
GO
-----------------------------------------
/*IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL
@Tipo_Cancelacion CHAR(1),
@Motivo VARCHAR(225),
@Num_Doc NUMERIC(18,0),
@Especialidad VARCHAR(255),
@Fecha_Desde CHAR(10),
@Fecha_Hasta CHAR(10)
AS
BEGIN
DECLARE @Id_Insert INT
INSERT INTO STRANGER_STRINGS.Cancelacion_Turno(Tipo_Cancelacion,Motivo)
VALUES(@Tipo_Cancelacion,@Motivo)
SET @Id_Insert= SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Turno
SET Id_Cancelacion=@Id_Insert
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND Turno_Fecha BETWEEN CONVERT(DATETIME,RIGHT(@Fecha_Desde,4)+LEFT(@Fecha_Desde,2)+SUBSTRING(@Fecha_Desde,4,2)) AND CONVERT(DATETIME,RIGHT(@Fecha_Hasta,4)+LEFT(@Fecha_Hasta,2)+SUBSTRING(@Fecha_Hasta,4,2))
UPDATE STRANGER_STRINGS.Turno
SET Id_Horario=NULL
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND Turno_Fecha BETWEEN CONVERT(DATETIME,RIGHT(@Fecha_Desde,4)+LEFT(@Fecha_Desde,2)+SUBSTRING(@Fecha_Desde,4,2)) AND CONVERT(DATETIME,RIGHT(@Fecha_Hasta,4)+LEFT(@Fecha_Hasta,2)+SUBSTRING(@Fecha_Hasta,4,2))
END
GO*/

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CANCELAR_TURNOS_RANGO_PROFESIONAL
@Tipo_Cancelacion CHAR(1),
@Motivo VARCHAR(225),
@Num_Doc NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0),
@Fecha_Desde DATETIME,
@Fecha_Hasta DATETIME
AS
BEGIN
DECLARE @Id_Insert INT
INSERT INTO STRANGER_STRINGS.Cancelacion_Turno(Tipo_Cancelacion,Motivo)
VALUES(@Tipo_Cancelacion,@Motivo)
SET @Id_Insert= SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Turno
SET Id_Cancelacion=@Id_Insert
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND Turno_Fecha BETWEEN @Fecha_Desde AND @Fecha_Hasta
UPDATE STRANGER_STRINGS.Turno
SET Id_Horario=NULL
WHERE Id_Medico_x_Esp IN (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc) AND Turno_Fecha BETWEEN  @Fecha_Desde AND @Fecha_Hasta
INSERT INTO STRANGER_STRINGS.Registro_Cancelacion_Medico(Id_Med,Dia_Desde,Dia_Hasta) 
VALUES ((SELECT Id_Medico FROM STRANGER_STRINGS.Medico WHERE Num_Doc=@Num_Doc),@Fecha_Desde,@Fecha_Hasta)
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_BUSCAR_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_BUSCAR_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_BUSCAR_AFILIADO
@Num_Doc NUMERIC(18,0)
AS
BEGIN 
SELECT p.Nombre, p.Apellido, p.Tipo_Doc, p.Num_Doc, p.Direccion, p.Telefono, p.Mail, p.Fecha_Nac, p.Sexo, p.Estado_Civil,p.Familiares_A_Cargo, pm.Descripcion 
FROM STRANGER_STRINGS.Paciente p JOIN STRANGER_STRINGS.Plan_Medico pm ON(p.Codigo_Plan=pm.Codigo_Plan)
WHERE p.Num_Doc=@Num_Doc AND p.Estado_Afiliado!='D'
END 
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_BAJA_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_BAJA_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_BAJA_AFILIADO
@Num_Doc NUMERIC(18,0),
@Fecha_Baja DATETIME,
@Retorno INT OUTPUT
AS
BEGIN
DECLARE @Id_Paciente INT = (SELECT p.Id_Paciente FROM STRANGER_STRINGS.Paciente p WHERE p.Num_Doc=@Num_Doc)
IF NOT EXISTS(SELECT * FROM STRANGER_STRINGS.Paciente p
			WHERE p.Num_Doc=@Num_Doc)
			BEGIN
SET @Retorno=-1-- Paciente no existe
RETURN
END
IF EXISTS (SELECT * FROM Baja_Paciente b WHERE b.Id_Paciente=@Id_Paciente)
BEGIN
SET @Retorno=-2--Paciente dado de baja anteriormente
RETURN
END
UPDATE STRANGER_STRINGS.Paciente
SET Estado_Afiliado = 'D'
WHERE Num_Doc=@Num_Doc
INSERT INTO STRANGER_STRINGS.Baja_Paciente(Id_Paciente,Fecha_Baja)
VALUES (@Id_Paciente,@Fecha_Baja)
DELETE FROM STRANGER_STRINGS.Turno
WHERE Id_Paciente=@Id_Paciente AND Id_Consulta IS NULL 
SET @Retorno = 0 --Baja Paciente OK
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_MODIFICAR_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_MODIFICAR_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_MODIFICAR_AFILIADO
@Nombre VARCHAR(255),
@Apellido VARCHAR(255),
@Tipo_Doc VARCHAR(10),
@Num_Doc NUMERIC(18,0),
@Direccion VARCHAR(255),
@Telefono NUMERIC(18,0),
@Mail VARCHAR(255),
@Fecha_Nac DATETIME,
@Sexo CHAR(1),
@Estado_Civil VARCHAR(15),
@Familiares_A_Cargo INT,
@Retorno INT OUTPUT
AS
BEGIN
IF NOT EXISTS(SELECT * FROM STRANGER_STRINGS.Paciente p
			WHERE p.Num_Doc=@Num_Doc)
			BEGIN
--RAISERROR('Paciente no encontrado',10,1)
SET @Retorno=-1 
RETURN
END
UPDATE STRANGER_STRINGS.Paciente
SET Direccion=@Direccion,Telefono=@Telefono,Mail=@Mail,Fecha_Nac=@Fecha_Nac,Estado_Civil=@Estado_Civil
WHERE Num_Doc=@Num_Doc
SET @Retorno=0 --OK
END 
GO
-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_REGISTRAR_RESULTADO_CONSULTA')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_REGISTRAR_RESULTADO_CONSULTA
GO


CREATE PROCEDURE STRANGER_STRINGS.SP_REGISTRAR_RESULTADO_CONSULTA
@Id_Consulta INT,
@Fecha_Y_Hora_Atencion DATETIME,
@Sintomas VARCHAR(255),
@Diagnostico VARCHAR(255)
AS 
BEGIN
UPDATE STRANGER_STRINGS.Consulta
SET Fecha_Y_Hora_Atencion=@Fecha_Y_Hora_Atencion,Sintomas=@Sintomas, Enfermedades=@Diagnostico
WHERE Id_Consulta=@Id_Consulta
END
GO
-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_PEDIR_TURNO_MEDICO_FECHA')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNO_MEDICO_FECHA
GO

/*CREATE PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNO_MEDICO_FECHA
@Num_Doc INT,
@Especialidad VARCHAR(255),
@Fecha CHAR(10)
AS
BEGIN
SELECT t.Turno_Fecha,p.Nombre,p.Apellido,t.Id_Consulta
		FROM STRANGER_STRINGS.Turno t JOIN Paciente p ON (p.Id_Paciente=t.Id_Paciente)
		WHERE t.Id_Medico_x_Esp=(SELECT es.Id FROM STRANGER_STRINGS.Especialidad_X_Medico es 
												WHERE (SELECT e.Especialidad_Codigo  FROM STRANGER_STRINGS.Especialidad e WHERE Especialidad_Descripcion=@Especialidad)=es.Especialidad_Codigo AND es.Id_Medico=(SELECT m.Id_Medico 
												FROM STRANGER_STRINGS.Medico m WHERE m.Num_Doc=@Num_Doc))
		AND CONVERT(DATE,t.Turno_Fecha)=CONVERT(DATETIME,RIGHT(@Fecha,4)+LEFT(@Fecha,2)+SUBSTRING(@Fecha,4,2))
END
GO*/

CREATE PROCEDURE STRANGER_STRINGS.SP_PEDIR_TURNO_MEDICO_FECHA
@Num_Doc INT,
@Especialidad_Codigo NUMERIC(18,0),
@Fecha DATETIME
AS
BEGIN
SELECT t.Turno_Fecha,p.Nombre,p.Apellido,t.Id_Consulta
		FROM STRANGER_STRINGS.Turno t JOIN Paciente p ON (p.Id_Paciente=t.Id_Paciente)
		WHERE t.Id_Medico_x_Esp=(SELECT es.Id FROM STRANGER_STRINGS.Especialidad_X_Medico es 
												WHERE @Especialidad_Codigo=es.Especialidad_Codigo AND es.Id_Medico=(SELECT m.Id_Medico 
												FROM STRANGER_STRINGS.Medico m WHERE m.Num_Doc=@Num_Doc))
		AND DATEDIFF(day,t.Turno_Fecha,@Fecha)=0
END
GO
-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CAMBIO_PLAN')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CAMBIO_PLAN
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CAMBIO_PLAN
@Num_Doc NUMERIC(18,0),
@Motivo VARCHAR(255),
@Descripcion_Plan_Viejo VARCHAR(30),
@Descripcion_Plan_Nuevo VARCHAR(30)
AS
BEGIN
DECLARE @Id_Afiliado INT= (SELECT p.Id_Paciente FROM STRANGER_STRINGS.Paciente p WHERE p.Num_Doc=@Num_Doc)
DECLARE @Id_Plan_Viejo INT= (SELECT Codigo_Plan FROM STRANGER_STRINGS.Plan_Medico WHERE Descripcion=@Descripcion_Plan_Viejo)
DECLARE @Id_Plan_Nuevo INT= (SELECT Codigo_Plan FROM STRANGER_STRINGS.Plan_Medico WHERE Descripcion=@Descripcion_Plan_Nuevo)
INSERT INTO STRANGER_STRINGS.Cambio_Plan (Id_Paciente,Motivo,Codigo_Plan_Viejo,Codigo_Plan_Nuevo)
VALUES(@Id_Afiliado,@Motivo,@Id_Plan_Viejo,@Id_Plan_Nuevo)
UPDATE STRANGER_STRINGS.Paciente
SET	Codigo_Plan=@Id_Plan_Nuevo
WHERE Id_Paciente=@Id_Afiliado
END
GO
-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_ALTA_AGENDA')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_ALTA_AGENDA
GO

/*CREATE PROCEDURE STRANGER_STRINGS.SP_ALTA_AGENDA
@Num_Doc NUMERIC(18,0),
@Especialidad_Descripcion VARCHAR(255),
@Dia_Semana SMALLINT,
@Hora_Desde CHAR(2),
@Hora_Hasta CHAR(2)
AS
BEGIN
DECLARE @Id_Medico INT= (SELECT Id_Medico FROM STRANGER_STRINGS.Medico WHERE Num_Doc=35198771)
DECLARE @Id_Medico_X_Especialidad INT= (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo)
WHERE em.Id_Medico=@Id_Medico AND e.Especialidad_Descripcion LIKE '%'+@Especialidad_Descripcion+'%')
DECLARE @Cant_Horas_A_Insertar INT= (DATEDIFF(HH,CONVERT(DATETIME,@Hora_Desde+':00',120),CONVERT(DATETIME,@Hora_Hasta+':00',120)))
DECLARE @Cant_Horas_De_Trabajo INT= (SELECT SUM(DATEDIFF(HH,CONVERT(DATETIME,ha.Hora_Desde,120),CONVERT(DATETIME,ha.Hora_Hasta,120))) FROM STRANGER_STRINGS.Horarios_Agenda ha 
JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(ha.Id_Especialidad_Medico=em.Id)
WHERE em.Id_Medico=@Id_Medico)
IF((@Cant_Horas_De_Trabajo+@Cant_Horas_A_Insertar)>48)
BEGIN
		RAISERROR('El profesional ya posee sus 48hs semanales de trabajo ocupadas',10,1)
		RETURN
		END
ELSE IF EXISTS(SELECT * FROM STRANGER_STRINGS.Horarios_Agenda ha JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(ha.Id_Especialidad_Medico=em.Id) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
			   WHERE ha.Id_Especialidad_Medico!=@Id_Medico_X_Especialidad AND m.Id_Medico=@Id_Medico AND ha.Dia=@Dia_Semana 
			   AND ha.Hora_Desde=@Hora_Desde AND ha.Hora_Hasta=@Hora_Hasta)
BEGIN
		RAISERROR('El profesional ya atiende otra especialidad en esa franja horaria y dia seleccionado',10,1)
		RETURN
		END
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia,Hora_Desde,Hora_Hasta,Id_Especialidad_Medico)
VALUES(@Dia_Semana,CAST(@Hora_Desde+':00'AS TIME(0)),CAST(@Hora_Hasta+':00' AS TIME(0)),@Id_Medico_X_Especialidad)
END
GO*/
CREATE PROCEDURE STRANGER_STRINGS.SP_ALTA_AGENDA
@Num_Doc NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0),
@Dia_Semana SMALLINT,
@Hora_Desde TIME,
@Hora_Hasta TIME,
@Output INT
AS
BEGIN
DECLARE @Id_Medico INT= (SELECT Id_Medico FROM STRANGER_STRINGS.Medico WHERE Num_Doc=35198771)
DECLARE @Id_Medico_X_Especialidad INT= (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo)
WHERE em.Id_Medico=@Id_Medico AND e.Especialidad_Codigo=@Especialidad_Codigo)
DECLARE @Cant_Horas_A_Insertar INT= (DATEDIFF(HH,@Hora_Desde,@Hora_Hasta))
DECLARE @Cant_Horas_De_Trabajo INT= (SELECT SUM(DATEDIFF(HH,CONVERT(DATETIME,ha.Hora_Desde,120),CONVERT(DATETIME,ha.Hora_Hasta,120))) FROM STRANGER_STRINGS.Horarios_Agenda ha 
JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(ha.Id_Especialidad_Medico=em.Id)
WHERE em.Id_Medico=@Id_Medico)
IF((@Cant_Horas_De_Trabajo+@Cant_Horas_A_Insertar)>48)
BEGIN
		--RAISERROR('El profesional ya posee sus 48hs semanales de trabajo ocupadas',10,1)
		SET @Output=-1
		RETURN
		END
ELSE IF EXISTS(SELECT * FROM STRANGER_STRINGS.Horarios_Agenda ha JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(ha.Id_Especialidad_Medico=em.Id) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
			   WHERE ha.Id_Especialidad_Medico!=@Id_Medico_X_Especialidad AND m.Id_Medico=@Id_Medico AND ha.Dia=@Dia_Semana 
			   AND ha.Hora_Desde=@Hora_Desde AND ha.Hora_Hasta=@Hora_Hasta)
BEGIN
		--RAISERROR('El profesional ya atiende otra especialidad en esa franja horaria y dia seleccionado',10,1)
		SET @Output=-2
		RETURN
		END
INSERT INTO STRANGER_STRINGS.Horarios_Agenda(Dia,Hora_Desde,Hora_Hasta,Id_Especialidad_Medico)
VALUES(@Dia_Semana,@Hora_Desde,@Hora_Hasta,@Id_Medico_X_Especialidad)
SET @Output=0--OK
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_SOLICITAR_TURNO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_SOLICITAR_TURNO
GO

/*CREATE PROCEDURE STRANGER_STRINGS.SP_SOLICITAR_TURNO
@Fecha_Turno CHAR(10),
@Num_Doc_Paciente NUMERIC(18,0),
@Num_Doc_Profesional NUMERIC(18,0),
@Especialidad_Descripcion VARCHAR(255)
AS
BEGIN
DECLARE @Id_Paciente INT = (SELECT p.Id_paciente FROM STRANGER_STRINGS.Paciente p WHERE p.Num_Doc=@Num_Doc_Paciente)
DECLARE @Id_Medico_X_Especialidad INT = (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc_Profesional AND e.Especialidad_Descripcion LIKE '%'+@Especialidad_Descripcion+'%')
DECLARE @Fecha_Turno_Convertida DATETIME= CONVERT(DATETIME,RIGHT(@Fecha_Turno,4)+LEFT(@Fecha_Turno,2)+SUBSTRING(@Fecha_Turno,4,2))
INSERT INTO STRANGER_STRINGS.Turno(Id_Paciente,Id_Medico_x_Esp,Turno_Fecha,Id_Horario)
VALUES(@Id_Paciente,@Id_Medico_X_Especialidad,@Fecha_Turno_Convertida,
(SELECT a.Id_Horario FROM STRANGER_STRINGS.Horarios_Agenda a 
WHERE a.Dia=DATEPART(DW,@Fecha_Turno_Convertida) AND 
CAST(@Fecha_Turno as Time(0)) BETWEEN a.Hora_Desde AND a.Hora_Hasta 
AND a.Id_Especialidad_Medico=@Id_Medico_X_Especialidad))
END
GO*/
CREATE PROCEDURE STRANGER_STRINGS.SP_SOLICITAR_TURNO
@Fecha_Turno DATETIME,
@Num_Doc_Paciente NUMERIC(18,0),
@Num_Doc_Profesional NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0)
AS
BEGIN
DECLARE @Id_Paciente INT = STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE(@Num_Doc_Paciente)
DECLARE @Id_Medico_X_Especialidad INT = (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc_Profesional AND e.Especialidad_Codigo=@Especialidad_Codigo)
INSERT INTO STRANGER_STRINGS.Turno(Id_Paciente,Id_Medico_x_Esp,Turno_Fecha,Id_Horario)
VALUES(@Id_Paciente,@Id_Medico_X_Especialidad,@Fecha_Turno,
(SELECT a.Id_Horario FROM STRANGER_STRINGS.Horarios_Agenda a 
WHERE a.Dia=DATEPART(DW,@Fecha_Turno) AND 
CAST(@Fecha_Turno as Time(0)) BETWEEN a.Hora_Desde AND a.Hora_Hasta 
AND a.Id_Especialidad_Medico=@Id_Medico_X_Especialidad))
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_ESPECIALIDADES')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_ESPECIALIDADES
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_ESPECIALIDADES
AS
BEGIN
SELECT Especialidad_Descripcion, Especialidad_Codigo FROM STRANGER_STRINGS.Especialidad
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_MEDICOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_MEDICOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_MEDICOS
AS
BEGIN
SELECT m.Nombre, m.Apellido, m.Num_Doc FROM STRANGER_STRINGS.Medico m 
END
GO
-----------------------------------------
/*
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_FECHAS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_FECHAS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_FECHAS
@Num_Doc NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0)
AS
BEGIN
DECLARE @Id_Medico_X_Especialidad INT = (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc AND e.Especialidad_Codigo=@Especialidad_Codigo)
SELECT Dia FROM STRANGER_STRINGS.Horarios_Agenda WHERE @Id_Medico_X_Especialidad=Id_Especialidad_Medico
END
GO*/
-----------------------------------------
/*IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_HORARIOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_HORARIOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_HORARIOS
@Num_Doc NUMERIC(18,0),
@Especialidad_Descripcion VARCHAR(255),
@Fecha CHAR(10)
AS
BEGIN
DECLARE @Id_Medico_X_Especialidad INT = (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc AND e.Especialidad_Descripcion LIKE '%'+@Especialidad_Descripcion+'%')
END
GO*/

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_HORARIOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_HORARIOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_HORARIOS
@Num_Doc NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0),
@Fecha DATETIME
AS
BEGIN
DECLARE @Id_Medico_X_Especialidad INT = (SELECT em.Id FROM STRANGER_STRINGS.Especialidad_X_Medico em 
JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) JOIN STRANGER_STRINGS.Medico m ON(em.Id_Medico=m.Id_Medico)
WHERE m.Num_Doc=@Num_Doc AND e.Especialidad_Codigo=@Especialidad_Codigo)
END
GO

-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_TOP5_CANCELACIONES')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_TOP5_CANCELACIONES
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_TOP5_CANCELACIONES
@Fecha_Inicio_Semestre DATETIME,
@Fecha_Fin_Semestre DATETIME
AS
BEGIN
SELECT COUNT(*) AS Cant, e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t, STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo)
WHERE em.Id=t.Id_Medico_x_Esp AND t.Id_Cancelacion IS NOT NULL AND t.Turno_Fecha BETWEEN @Fecha_Inicio_Semestre AND @Fecha_FIN_Semestre
GROUP BY t.Id_Medico_x_Esp, e.Especialidad_Descripcion
ORDER BY 1 DESC
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_TOP5_BONOS_ESPECIALIDAD')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_TOP5_BONOS_ESPECIALIDAD
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_TOP5_BONOS_ESPECIALIDAD
@Fecha_Inicio_Semestre DATETIME,
@Fecha_Fin_Semestre DATETIME
AS
BEGIN
SELECT COUNT(*) AS Cant, e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t, STRANGER_STRINGS.Especialidad_X_Medico em JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo)
WHERE em.Id=t.Id_Medico_x_Esp AND t.Id_Consulta IS NOT NULL AND t.Turno_Fecha BETWEEN @Fecha_Inicio_Semestre AND @Fecha_Fin_Semestre
GROUP BY t.Id_Medico_x_Esp, e.Especialidad_Descripcion
ORDER BY 1 DESC
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_TOP5_PROFESIONALES_CONSULTADOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_TOP5_PROFESIONALES_CONSULTADOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_TOP5_PROFESIONALES_CONSULTADOS
@Fecha_Inicio_Semestre DATETIME,
@Fecha_Fin_Semestre DATETIME
AS
BEGIN
SELECT COUNT(*) AS Cantidad,m.Nombre,m.Apellido,pm.Descripcion AS Tipo_De_Plan,e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(t.Id_Medico_x_Esp=em.Id)
JOIN STRANGER_STRINGS.Medico m ON(m.Id_Medico=em.Id_Medico) JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) 
JOIN STRANGER_STRINGS.Paciente p ON(t.Id_Paciente=p.Id_Paciente) JOIN STRANGER_STRINGS.Plan_Medico pm ON(p.Codigo_Plan=pm.Codigo_Plan)
WHERE t.Id_Consulta IS NOT NULL AND t.Turno_Fecha BETWEEN @Fecha_Inicio_Semestre AND @Fecha_Fin_Semestre
GROUP BY m.Nombre,m.Apellido,pm.Descripcion,e.Especialidad_Descripcion
ORDER BY 1 DESC
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_TOP5_PROFESIONALES_POCAS_HORAS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_TOP5_PROFESIONALES_POCAS_HORAS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_TOP5_PROFESIONALES_POCAS_HORAS
@Fecha_Inicio_Semestre DATETIME,
@Fecha_Fin_Semestre DATETIME
AS
BEGIN
SELECT COUNT(*)*0.5 AS Horas_Trabajadas,m.Nombre,m.Apellido,pm.Descripcion AS Tipo_De_Plan,e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Especialidad_X_Medico em ON(t.Id_Medico_x_Esp=em.Id)
JOIN STRANGER_STRINGS.Medico m ON(m.Id_Medico=em.Id_Medico) JOIN STRANGER_STRINGS.Especialidad e ON(em.Especialidad_Codigo=e.Especialidad_Codigo) 
JOIN STRANGER_STRINGS.Paciente p ON(t.Id_Paciente=p.Id_Paciente) JOIN STRANGER_STRINGS.Plan_Medico pm ON(p.Codigo_Plan=pm.Codigo_Plan)
WHERE t.Id_Consulta IS NOT NULL AND t.Turno_Fecha BETWEEN @Fecha_Inicio_Semestre AND @Fecha_Fin_Semestre 
GROUP BY m.Nombre,m.Apellido,pm.Descripcion,e.Especialidad_Descripcion
ORDER BY 1 ASC
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_TOP5_AFILIDOS_BONOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_TOP5_AFILIDOS_BONOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_TOP5_AFILIDOS_BONOS
@Fecha_Inicio_Semestre DATETIME,
@Fecha_Fin_Semestre DATETIME
AS
BEGIN
SELECT COUNT(c.Cantidad_Bonos)AS Bonos_Comprados,p.Apellido,p.Nombre,
CASE WHEN (p.Num_Afiliado_Resto=01 AND p.Familiares_A_Cargo!=0) THEN 'SI'
	 WHEN (p.Num_Afiliado_Resto>01 AND p.Familiares_A_Cargo=0) THEN 'SI'
	 ELSE 'NO'
	 END AS Pertenece_A_Grupo_Familiar
FROM STRANGER_STRINGS.Paciente p JOIN STRANGER_STRINGS.Compra c ON(p.Id_Paciente=c.Id_Paciente)
WHERE c.Fecha_Compra BETWEEN @Fecha_Inicio_Semestre AND @Fecha_Fin_Semestre
GROUP BY p.Nombre,p.Apellido,p.Num_Afiliado_Resto,p.Familiares_A_Cargo
ORDER BY 1 DESC
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_GET_PRECIO_BONO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_GET_PRECIO_BONO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_GET_PRECIO_BONO
@Descripcion VARCHAR(255)
AS
BEGIN
SELECT p.Precio_Bono_Consulta
	FROM STRANGER_STRINGS.Plan_Medico p
	WHERE p.Descripcion=@Descripcion
END
GO

-----------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_COMPRA_BONOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_COMPRA_BONOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_COMPRA_BONOS
@Num_Doc NUMERIC(18,0),
@Fecha_Compra DATETIME,
@Cantidad_Bonos INT
AS
BEGIN
DECLARE @Id_Paciente INT = STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE(@Num_Doc)
DECLARE @Codigo_Plan INT = (SELECT Codigo_Plan FROM STRANGER_STRINGS.Paciente WHERE Id_Paciente=@Id_Paciente)
DECLARE @Precio_Bono INT = (SELECT Precio_Bono_Consulta FROM STRANGER_STRINGS.Plan_Medico WHERE Codigo_Plan=@Codigo_Plan)
DECLARE @Contador INT=0
INSERT INTO STRANGER_STRINGS.Compra (Fecha_Compra,Cantidad_Bonos,Importe_Total,Id_Paciente)
VALUES (@Fecha_Compra,@Cantidad_Bonos,(@Precio_Bono*@Cantidad_Bonos),@Id_Paciente)
DECLARE @Id_Insert INT =SCOPE_IDENTITY()
WHILE @Contador<@Cantidad_Bonos
BEGIN
INSERT INTO STRANGER_STRINGS.Bono(Fecha_Compra,Id_Paciente_Compro,Codigo_Plan,Id_Compra) VALUES(@Fecha_Compra,@Id_Paciente,@Codigo_Plan,@Id_Insert)
SET @Contador+=1
END
END
GO

-----------------------------------------

IF EXISTS(SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'STRANGER_STRINGS.FX_OBTENER_RESTO')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION STRANGER_STRINGS.FX_OBTENER_RESTO
GO

CREATE FUNCTION STRANGER_STRINGS.FX_OBTENER_RESTO(@Num_Afiliado_Raiz NUMERIC(20,0))
RETURNS NUMERIC(2,0)
AS
BEGIN
DECLARE @Resto NUMERIC(2,0)
SET @Resto=(SELECT TOP 1 (Num_Afiliado_Resto)+1 FROM STRANGER_STRINGS.Paciente p
			WHERE p.Num_Afiliado_Raiz=@Num_Afiliado_Raiz
			ORDER BY Num_Afiliado_Resto DESC)

RETURN @Resto
END
GO

-----------------------------------------------

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_ALTA_AFILIADO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_ALTA_AFILIADO
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_ALTA_AFILIADO
@Nombre VARCHAR(255),
@Apellido VARCHAR(255),
@Tipo_Doc VARCHAR(10),
@Num_Doc NUMERIC(18,0),
@Direccion VARCHAR(255),
@Telefono NUMERIC(18,0),
@Mail VARCHAR(255),
@Fecha_Nac DATETIME,
@Sexo CHAR(1),
@Estado_Civil VARCHAR(15),
@Familiares_A_Cargo INT,
@Codigo_Plan INT,
@Num_Afiliado_Raiz NUMERIC(20,0),
@Num_Afiliado NUMERIC(20,0)=NULL OUTPUT,
@Retorno INT OUTPUT

AS
BEGIN
IF EXISTS( SELECT * FROM STRANGER_STRINGS.Paciente WHERE Num_Doc=@Num_Doc)
BEGIN
		--RAISERROR('Paciente ya existente',10,1)
		SET @Retorno=-1
		RETURN
		END
IF @Num_Afiliado_Raiz IS NULL
BEGIN
	INSERT INTO STRANGER_STRINGS.Paciente (Nombre,Apellido,Tipo_Doc,Num_Doc,Direccion,Telefono,Mail,Fecha_Nac,Sexo,Estado_Civil,Familiares_A_Cargo,Codigo_Plan,Num_Afiliado_Raiz,Num_Afiliado_Resto,Cantidad_Consulta,Estado_Afiliado)
	VALUES(@Nombre,@Apellido,@Tipo_Doc,@Num_Doc,@Direccion,@Telefono,@Mail,@Fecha_Nac,@Sexo,@Estado_Civil,@Familiares_A_Cargo,@Codigo_Plan,REVERSE(@Num_Doc),01,0,'A')
	SET @Num_Afiliado=REVERSE(@Num_Doc)
	END
ELSE
BEGIN
	INSERT INTO STRANGER_STRINGS.Paciente (Nombre,Apellido,Tipo_Doc,Num_Doc,Direccion,Telefono,Mail,Fecha_Nac,Sexo,Estado_Civil,Familiares_A_Cargo,Codigo_Plan,Num_Afiliado_Raiz,Num_Afiliado_Resto,Cantidad_Consulta,Estado_Afiliado)
	VALUES(@Nombre,@Apellido,@Tipo_Doc,@Num_Doc,@Direccion,@Telefono,@Mail,@Fecha_Nac,@Sexo,@Estado_Civil,@Familiares_A_Cargo,@Codigo_Plan,@Num_Afiliado_Raiz,STRANGER_STRINGS.FX_OBTENER_RESTO(@Num_Afiliado_Raiz),0,'A')
END
INSERT INTO STRANGER_STRINGS.Usuario (Usuario,Pasword,Cantidad_Intentos) VALUES (CONVERT(VARCHAR,@Num_Doc),HASHBYTES('SHA2_256',@Apellido),3)
DECLARE @Id_Insert INT = SCOPE_IDENTITY()
UPDATE STRANGER_STRINGS.Paciente
SET Id_Usuario=@Id_Insert
WHERE Num_Doc=@Num_Doc
SET @Retorno=0 --OK
END
GO

-----------------------------------------------
IF EXISTS(SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE
GO

CREATE FUNCTION STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE(@Num_Doc NUMERIC(18,0))
RETURNS INT
AS
BEGIN
DECLARE @Id_Paciente INT
SET @Id_Paciente=(SELECT Id_Paciente FROM STRANGER_STRINGS.Paciente WHERE Num_Doc=@Num_Doc)
RETURN @Id_Paciente
END
GO
--------------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_BUSCAR_PROFESIONALES_SEGUN_CRITERIOS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_BUSCAR_PROFESIONALES_SEGUN_CRITERIOS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_BUSCAR_PROFESIONALES_SEGUN_CRITERIOS
@Nombre VARCHAR(255),
@Apellido VARCHAR(255), 
@Especialidad_Codigo NUMERIC(18,0)
AS
BEGIN
DECLARE @QueryCompleta NVARCHAR(1500)
DECLARE @Query1 VARCHAR(500) = 'SELECT DISTINCT m.Id_Medico,m.Nombre,m.Apellido,e.Especialidad_Codigo,e.Especialidad_Descripcion
								FROM STRANGER_STRINGS.Medico m JOIN STRANGER_STRINGS.Especialidad_X_Medico es ON (m.Id_Medico = 
								es.Id_Medico) JOIN STRANGER_STRINGS.Especialidad e ON(es.Especialidad_Codigo = e.Especialidad_Codigo)
								WHERE '
DECLARE @Query2 VARCHAR(500) = ' '
DECLARE @Query3 VARCHAR(500) = 'm.Nombre LIKE @Nombre AND m.Apellido LIKE @Apellido'
DECLARE @Query4 VARCHAR(500) = ' ORDER BY m.Apellido,m.Nombre,m.Id_Medico,e.Especialidad_Descripcion ASC'

IF @Especialidad_Codigo >0
SET @Query2 = 'e.Especialidad_Codigo = @Especialidad_Codigo AND '
SET @Nombre = '%' + @Nombre + '%'
SET @Apellido = '%' + @Apellido + '%'


SET @QueryCompleta = @Query1 + @Query2 + @Query3 + @Query4

EXEC sp_executesql @QueryCompleta, N'@Nombre VARCHAR(255), @Apellido VARCHAR(255),
  @Especialidad_Codigo NUMERIC(18,0)',@Nombre, @Apellido,@Especialidad_Codigo
END
GO

----------------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_LISTAR_TURNOS_MEDICO')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_LISTAR_TURNOS_MEDICO
GO
CREATE PROCEDURE STRANGER_STRINGS.SP_LISTAR_TURNOS_MEDICO
@Id_Medico INT,
@Especialidad_Codigo NUMERIC(18,0),
@Fecha DATETIME
AS
BEGIN
SELECT t.Turno_Numero, p.Nombre,p.Apellido,p.Num_Doc,CONVERT(TIME,t.Turno_Fecha,120)
		FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Paciente p ON(t.Id_Paciente=p.Id_Paciente)
		WHERE t.Id_Medico_x_Esp = (SELECT Id FROM STRANGER_STRINGS.Especialidad_X_Medico WHERE Id_Medico=@Id_Medico
		AND Especialidad_Codigo=@Especialidad_Codigo) AND DATEDIFF(day,t.Turno_Fecha,@Fecha)=0
		ORDER BY CONVERT(TIME,t.Turno_Fecha,120) ASC
END
GO
----------------------------------------------
IF EXISTS(SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'STRANGER_STRINGS.FX_OBTENER_BONO')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION STRANGER_STRINGS.FX_OBTENER_BONO
GO

CREATE FUNCTION STRANGER_STRINGS.FX_OBTENER_BONO(@Num_Afiliado_Raiz NUMERIC(20,0),@Cod_Plan INT)
RETURNS INT
AS
BEGIN
DECLARE @Id_Bono INT = (SELECT Id_Bono FROM STRANGER_STRINGS.Bono 
					WHERE Id_Paciente_Compro IN (SELECT Id_Paciente FROM STRANGER_STRINGS.Paciente 
					WHERE Num_Afiliado_Raiz=@Num_Afiliado_Raiz) AND Numero_Consulta IS NULL 
					AND Codigo_Plan=@Cod_Plan )
RETURN @Id_Bono
END
GO
-----------------------------------------------------
IF EXISTS(SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'STRANGER_STRINGS.FX_OBTENER_CANTIDAD_DE_BONOS')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION STRANGER_STRINGS.FX_OBTENER_CANTIDAD_DE_BONOS
GO

CREATE FUNCTION STRANGER_STRINGS.FX_OBTENER_CANTIDAD_DE_BONOS(@Num_Afiliado_Raiz NUMERIC(20,0),@Cod_Plan INT)
RETURNS INT 
AS
BEGIN
DECLARE @Cantidad INT = (SELECT COUNT(Id_Bono) FROM STRANGER_STRINGS.Bono 
					WHERE Id_Paciente_Compro IN (SELECT Id_Paciente FROM STRANGER_STRINGS.Paciente 
					WHERE Num_Afiliado_Raiz=@Num_Afiliado_Raiz) AND Numero_Consulta IS NULL 
					AND Codigo_Plan=@Cod_Plan )
RETURN @Cantidad
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_CREAR_CONSULTA')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_CREAR_CONSULTA
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_CREAR_CONSULTA
@Fecha DATETIME,
@Num_Doc NUMERIC(18,0),
@Nro_Turno INT,
@Id_Bono INT,
@Retorno INT OUTPUT
AS
BEGIN
DECLARE @Id_Paciente INT
SET @Id_Paciente = STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE(@Num_Doc)
DECLARE @Nro_Raiz_Paciente NUMERIC(20,0)=(SELECT Num_Afiliado_Raiz FROM STRANGER_STRINGS.Paciente WHERE Id_Paciente = @Id_Paciente)
DECLARE @Cod_Plan_Paciente INT= (SELECT Codigo_Plan FROM STRANGER_STRINGS.Paciente WHERE Id_Paciente=@Id_Paciente)

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO STRANGER_STRINGS.Consulta(Fecha_Y_Hora_Llegada,Bono_Consulta_Id,Id_Paciente)
			VALUES(@Fecha,@Id_Bono,@Id_Paciente)
			DECLARE @Id_Insert INT = SCOPE_IDENTITY()
			UPDATE STRANGER_STRINGS.Turno
			SET Id_Consulta = @Id_Insert
			WHERE Turno_Numero=@Nro_Turno
			UPDATE STRANGER_STRINGS.Bono
			SET Numero_Consulta = (SELECT Cantidad_Consulta FROM STRANGER_STRINGS.Paciente
								 WHERE Id_Paciente=@Id_Paciente),Id_Paciente_Uso = @Id_Paciente,Fecha_Impresion=@Fecha
			WHERE Id_Bono=@Id_Bono
			SET @Retorno=1
			COMMIT
		END TRY
		BEGIN CATCH
		SET @Retorno=0
		ROLLBACK
		END CATCH
END
GO
-------------------------------------------------

IF EXISTS(SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'STRANGER_STRINGS.FX_FECHA_DISPONIBLE')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION STRANGER_STRINGS.FX_FECHA_DISPONIBLE
GO


CREATE FUNCTION STRANGER_STRINGS.FX_FECHA_DISPONIBLE(@Id_Medico NUMERIC(18,0),@Id_Med_Esp NUMERIC(18,0),@Fecha DATETIME)
RETURNS INT
AS
BEGIN
DECLARE @Turnos_Totales INT, @Turnos_Ocup INT, @Resto INT,@Id_Registro INT,@Retorno INT

SELECT @Id_Registro=Id_Registro
FROM STRANGER_STRINGS.Registro_Cancelacion_Medico re
WHERE re.Id_Med=@Id_Medico AND @Fecha BETWEEN re.Dia_Desde AND re.Dia_Hasta

SELECT @Turnos_Totales=SUM(DATEDIFF(mi,h.Hora_Desde,h.Hora_Hasta))
		FROM STRANGER_STRINGS.Horarios_Agenda h
		WHERE h.Id_Especialidad_Medico=@Id_Med_Esp AND h.Dia=DATEPART(dw,@Fecha)

SELECT @Turnos_Ocup=COUNT(DISTINCT t.Turno_Numero)
		FROM STRANGER_STRINGS.Turno t
		WHERE Id_Paciente IS NOT NULL AND DATEDIFF(dd,t.Turno_Fecha,@Fecha)=0 AND t.Id_Medico_x_Esp=@Id_Med_Esp

SET @Resto=@Turnos_Totales-@Turnos_Ocup

IF(@Resto>0 AND @Id_Registro IS NULL)
BEGIN
SET @Retorno=0
RETURN @Retorno
END
SET @Retorno=-1
RETURN @Retorno
END
GO

IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_OBTENER_FECHAS_FUTURAS')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_OBTENER_FECHAS_FUTURAS
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_OBTENER_FECHAS_FUTURAS
@Num_Doc NUMERIC(18,0),
@Especialidad_Codigo NUMERIC(18,0),
@Fecha_Actual DATETIME
AS
BEGIN
CREATE TABLE #Fechas_Futuras(Fecha DATE)
DECLARE @Id_Medico INT = (SELECT Id_Medico FROM STRANGER_STRINGS.Medico WHERE Num_Doc=@Num_Doc)
DECLARE @Id_Medico_Esp INT = (SELECT Id FROM STRANGER_STRINGS.Especialidad_X_Medico 
							WHERE Id_Medico=@Id_Medico AND Especialidad_Codigo=@Especialidad_Codigo)
DECLARE @Fecha DATE,@Contador INT = 30,@iterador INT =0
WHILE @iterador<@Contador
BEGIN
SET @Fecha=DATEADD(dd,@iterador,@Fecha_Actual)
IF (STRANGER_STRINGS.FX_FECHA_DISPONIBLE(@Id_Medico,@Id_Medico_Esp,@Fecha)=0)
BEGIN
INSERT INTO #Fechas_Futuras(Fecha) VALUES(@Fecha)
END
SET @iterador+=1
END
SELECT Fecha FROM #Fechas_Futuras
END
GO
------------------------------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_HORARIO_DISPONIBLE_PARA_FECHA')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_HORARIO_DISPONIBLE_PARA_FECHA
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_HORARIO_DISPONIBLE_PARA_FECHA
@Fecha DATETIME,
@Num_Doc INT,
@Especialidad_Codigo NUMERIC(18,0)
AS
BEGIN
DECLARE @Hora_Desde TIME,@Hora_Hasta TIME, @Id_Med_Esp INT,@Cantidad_Turnos INT,@Iterador INT=0,@Hora TIME,@Fecha_Completa DATETIME
SELECT @Id_Med_Esp=Id
FROM STRANGER_STRINGS.Especialidad_X_Medico es JOIN STRANGER_STRINGS.Medico m ON(m.Id_Medico=es.Id_Medico)
WHERE m.Num_Doc=@Num_Doc AND es.Especialidad_Codigo=@Especialidad_Codigo

SELECT @Hora_Desde=h.Hora_Desde,@Hora_Hasta=h.Hora_Hasta
FROM STRANGER_STRINGS.Horarios_Agenda h
WHERE h.Dia=DATEPART(dw,@Fecha) AND h.Id_Especialidad_Medico=@Id_Med_Esp

CREATE TABLE #HorariosPosibles(hora DATETIME)

SET @Cantidad_Turnos=DATEDIFF(mi,@Hora_Desde,@Hora_Hasta)/30

WHILE @Iterador<@Cantidad_Turnos
BEGIN
SET @Hora=DATEADD(mi,@Iterador*30,@Hora_Desde)
SET @Fecha_Completa = @Fecha+CONVERT(DATETIME,@Hora,120)
IF NOT EXISTS ( SELECT * FROM STRANGER_STRINGS.Turno t 
							WHERE t.Id_Medico_x_Esp=@Id_Med_Esp
							AND DATEDIFF(mi,t.Turno_Fecha,@Fecha_Completa)=0 AND t.Id_Paciente IS NOT NULL
							)
			BEGIN			
				INSERT INTO  #HorariosPosibles (hora) VALUES (@Hora)
			END		
			SET @Iterador+=1
			END
SELECT hora FROM #HorariosPosibles
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_GET_ESPECIALIDADES_ABM_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_GET_ESPECIALIDADES_ABM_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_GET_ESPECIALIDADES_ABM_ROL
AS
BEGIN
SELECT Descripcion, Estado FROM STRANGER_STRINGS.Rol
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_MODIFICAR_NOMBRE_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_MODIFICAR_NOMBRE_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_MODIFICAR_NOMBRE_ROL
@Nombre VARCHAR(255),
@Rol_Descripcion VARCHAR(255)
AS
BEGIN
UPDATE STRANGER_STRINGS.Rol
SET Descripcion=@Nombre
WHERE Id_Rol=(SELECT Id_Rol FROM STRANGER_STRINGS.Rol WHERE Descripcion=@Rol_Descripcion)
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_ELIMINAR_FUNCIONALIDAD_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_ELIMINAR_FUNCIONALIDAD_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_ELIMINAR_FUNCIONALIDAD_ROL
@Rol VARCHAR(255),
@Funcionalidad_Descripcion VARCHAR(255)
AS
BEGIN
DELETE FROM STRANGER_STRINGS.Funcionalidad_X_Rol
WHERE Id_Rol=(SELECT r.Id_Rol FROM STRANGER_STRINGS.Rol r WHERE r.Descripcion=@Rol) 
AND Id_Funcionalidad= (SELECT f.Id_Funcionalidad FROM STRANGER_STRINGS.Funcionalidad f WHERE f.Descripcion=@Funcionalidad_Descripcion)
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_AGREGAR_FUNCIONALIDAD_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_AGREGAR_FUNCIONALIDAD_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_AGREGAR_FUNCIONALIDAD_ROL
@Rol VARCHAR(255),
@Funcionalidad_Descripcion VARCHAR(255)
AS
BEGIN
INSERT INTO STRANGER_STRINGS.Funcionalidad_X_Rol(Id_Rol,Id_Funcionalidad)
VALUES((SELECT r.Id_Rol FROM STRANGER_STRINGS.Rol r WHERE r.Descripcion=@Rol),(SELECT f.Id_Funcionalidad FROM STRANGER_STRINGS.Funcionalidad f WHERE f.Descripcion=@Funcionalidad_Descripcion))
END
GO
----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_HABILITAR_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_HABILITAR_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_HABILITAR_ROL
@Rol VARCHAR(255)
AS
BEGIN
UPDATE STRANGER_STRINGS.Rol
SET Estado='E'
WHERE Descripcion=@Rol
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_ELIMINAR_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_ELIMINAR_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_ELIMINAR_ROL
@Rol VARCHAR(255)
AS
BEGIN
UPDATE STRANGER_STRINGS.Rol
SET Estado='D'
WHERE Descripcion=@Rol
DELETE FROM STRANGER_STRINGS.Rol_X_Usuario
WHERE Id_Rol=(SELECT r.Id_Rol FROM STRANGER_STRINGS.Rol r WHERE r.Descripcion=@Rol)
END
GO

-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_AGREGAR_ROL')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_AGREGAR_ROL
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_AGREGAR_ROL
@Rol VARCHAR(255)
AS
BEGIN
INSERT INTO STRANGER_STRINGS.Rol(Descripcion,Estado)
VALUES(@Rol,'E')
END
GO
-----------------------------------------
IF EXISTS(SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE')
                    AND type IN ( N'P', N'PC' ) )
DROP PROCEDURE STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE
GO

CREATE PROCEDURE STRANGER_STRINGS.SP_MOSTRAR_BONOS_PACIENTE
@Num_Doc NUMERIC (18,0),
@Retorno INT OUTPUT
AS
BEGIN
DECLARE @Id_Paciente INT = STRANGER_STRINGS.FX_OBTENER_ID_PACIENTE(@Num_Doc)
DECLARE @Num_Afiliado_Raiz NUMERIC(20,0),@Cod_Plan INT

SELECT @Num_Afiliado_Raiz=Num_Afiliado_Raiz, @Cod_Plan=Codigo_Plan
FROM STRANGER_STRINGS.Paciente
WHERE Id_Paciente=@Id_Paciente

DECLARE @Cantidad_Bonos INT = STRANGER_STRINGS.FX_OBTENER_CANTIDAD_DE_BONOS(@Num_Afiliado_Raiz,@Cod_Plan)
IF @Cantidad_Bonos>0
BEGIN
	SELECT  Id_Bono,Fecha_Compra,Codigo_Plan 
	FROM STRANGER_STRINGS.Bono WHERE Id_Paciente_Compro IN (SELECT Id_Paciente FROM STRANGER_STRINGS.Paciente WHERE Num_Afiliado_Raiz=@Num_Afiliado_Raiz)
	SET @Retorno = 1
	END
ELSE
BEGIN
SET @Retorno=0
END
END
GO
