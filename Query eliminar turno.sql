SELECT * FROM STRANGER_STRINGS.Cancelacion_Turno
SELECT * FROM STRANGER_STRINGS.Turno

SELECT * FROM gd_esquema.Maestra
	WHERE Turno_Numero=192891

SELECT m.Apellido, m.Nombre ,e.Especialidad_Descripcion FROM STRANGER_STRINGS.Especialidad_X_Medico espx, STRANGER_STRINGS.Especialidad e, STRANGER_STRINGS.Medico m
WHERE m.Id_Medico=espx.Id_Medico AND e.Especialidad_Codigo=espx.Especialidad_Codigo

SELECT t.Turno_Numero,t.Turno_Fecha,m.Apellido,e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Paciente p ON (p.Id_Paciente=t.Id_Paciente), STRANGER_STRINGS.Medico m JOIN STRANGER_STRINGS.Especialidad_X_Medico es ON(m.Id_Medico=es.Id_Medico) JOIN STRANGER_STRINGS.Especialidad e ON(e.Especialidad_Codigo=es.Especialidad_Codigo)
WHERE p.Num_Doc=72215288 AND t.Id_Medico=m.Id_Medico

SELECT DISTINCT tablaAux.Turno_Fecha,tablaAux.Apellido,tablaAux.Especialidad_Descripcion FROM (SELECT t.Turno_Numero,t.Turno_Fecha,m.Apellido,e.Especialidad_Descripcion
FROM STRANGER_STRINGS.Turno t JOIN STRANGER_STRINGS.Paciente p ON (p.Id_Paciente=t.Id_Paciente), STRANGER_STRINGS.Medico m JOIN STRANGER_STRINGS.Especialidad_X_Medico es ON(m.Id_Medico=es.Id_Medico) JOIN STRANGER_STRINGS.Especialidad e ON(e.Especialidad_Codigo=es.Especialidad_Codigo)
WHERE p.Num_Doc=72215288 AND t.Id_Medico=m.Id_Medico) AS tablaAux JOIN STRANGER_STRINGS.Cancelacion_Turno c ON(tablaAux.Turno_Numero!=c.Id_Turno)