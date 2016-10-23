SELECT * FROM STRANGER_STRINGS.Paciente
SELECT * FROM STRANGER_STRINGS.Medico
SELECT Turno_Numero FROM gd_esquema.Maestra WHERE Consulta_Sintomas IS NOT NULL
SELECT DISTINCT Tipo_Especialidad_Descripcion FROM STRANGER_STRINGS.Especialidad
SELECT Bono_Consulta_Numero,Consulta_Sintomas FROM gd_esquema.Maestra WHERE Bono_Consulta_Numero IS NOT NULL ORDER BY Bono_Consulta_Numero ASC
SELECT * FROM gd_esquema.Maestra ORDER BY Paciente_Nombre
SELECT DISTINCT e.Bono_Consulta_Numero,e.Consulta_Sintomas, e.Bono_Consulta_Fecha_Impresion, p.Id_Paciente, p.Id_Paciente,p.Num_Doc, e.Plan_Med_Codigo 
FROM gd_esquema.Maestra e JOIN STRANGER_STRINGS.Paciente p on(e.Paciente_Dni=p.Num_Doc)
WHERE e.Bono_Consulta_Numero IS NOT NULL AND e.Consulta_Sintomas IS NOT NULL 
ORDER BY Num_Doc ASC
SELECT * FROM STRANGER_STRINGS.Bono ORDER BY Id_Paciente_Uso
DECLARE @VARIABLE_FALOPA INT
EXEC @VARIABLE_FALOPA= DBO.FX_Numero_Consulta_X_Paciente 1123960,71036
PRINT @VARIABLE_FALOPA
SELECT DISTINCT e.Bono_Consulta_Numero, e.Bono_Consulta_Fecha_Impresion,e.Bono_Consulta_Fecha_Impresion, p.Id_Paciente, p.Id_Paciente, e.Plan_Med_Codigo, DBO.FX_Numero_Consulta_X_Paciente(e.Paciente_Dni,e.Bono_Consulta_Numero) AS Num_Consulta
FROM gd_esquema.Maestra e JOIN STRANGER_STRINGS.Paciente p on(e.Paciente_Dni=p.Num_Doc)
WHERE e.Bono_Consulta_Numero IS NOT NULL AND e.Consulta_Sintomas IS NOT NULL 
ORDER BY Bono_Consulta_Numero ASC
SELECT Distinct e.Paciente_Nombre, DBO.FX_Numero_Consulta_X_Paciente(e.Paciente_Dni,e.Bono_Consulta_Numero) AS Num_Consulta
FROM gd_esquema.Maestra e