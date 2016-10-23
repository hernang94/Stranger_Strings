SELECT e.Paciente_Nombre,e.Paciente_Dni,e.Consulta_Sintomas,e.Compra_Bono_Fecha,e.Bono_Consulta_Fecha_Impresion, e.Turno_Fecha, e.Turno_Numero
FROM gd_esquema.Maestra e
ORDER BY Turno_Numero
SELECT * FROM STRANGER_STRINGS.Paciente
UPDATE STRANGER_STRINGS.Paciente 
SET Cantidad_Consulta = 0
WHERE Num_Doc = 72215288

INSERT INTO STRANGER_STRINGS.Turno(Turno_Numero,Id_Paciente) VALUES(55000,1)
SET IDENTITY_INSERT STRANGER_STRINGS.TURNO OFF
INSERT INTO STRANGER_STRINGS.Turno(Id_Paciente) VALUES (2)
SELECT * FROM STRANGER_STRINGS.Turno
SET IDENTITY_INSERT STRANGER_STRINGS.Turno ON
GO
INSERT INTO STRANGER_STRINGS.Turno(Turno_Numero,Turno_Fecha,Id_Paciente)
SELECT DISTINCT e.Turno_Numero, e.Turno_Fecha,m.Id_Paciente
FROM STRANGER_STRINGS.Paciente m JOIN gd_esquema.Maestra e ON(m.Num_Doc=e.Paciente_Dni)
WHERE Turno_Numero IS NOT NULL 
ORDER BY 1
SELECT * FROM gd_esquema.Maestra

SELECT * FROM STRANGER_STRINGS.Bono

SELECT m.Consulta_Sintomas,m.Consulta_Enfermedades,b.Id_Bono
FROM gd_esquema.Maestra m, STRANGER_STRINGS.Bono b
WHERE m.Bono_Consulta_Numero=b.Id_Bono and m.Consulta_Sintomas IS NOT NULL
ORDER BY b.Id_Bono

SELECT * FROM STRANGER_STRINGS.Consulta ORDER BY Id_Consulta