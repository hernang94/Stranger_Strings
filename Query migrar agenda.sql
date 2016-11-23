SELECT	DATEPART(DW,Turno_Fecha),CAST(MAX(Turno_Fecha) AS TIME(0)),CAST(MIN(Turno_Fecha) AS TIME(0)),exm.Id
FROM gd_esquema.Maestra esqm, STRANGER_STRINGS.Especialidad_X_Medico exm JOIN STRANGER_STRINGS.Medico m ON(m.Id_Medico=exm.Id_Medico) 
JOIN STRANGER_STRINGS.Especialidad e ON(e.Especialidad_Codigo=exm.Especialidad_Codigo)
WHERE esqm.Medico_Nombre=m.Nombre AND esqm.Medico_Apellido=m.Apellido AND e.Especialidad_Descripcion=esqm.Especialidad_Descripcion
GROUP BY Medico_Nombre,DATEPART(DW,Turno_Fecha),exm.Id,e.Especialidad_Descripcion,m.Nombre

SELECT Turno_Fecha,Medico_Nombre,Especialidad_Descripcion FROM gd_esquema.Maestra
WHERE Medico_Nombre='CALEB' AND Especialidad_Descripcion IS NOT NULL AND Consulta_Sintomas IS NOT NULL
ORDER BY Turno_Fecha

PRINT CONVERT(DATE,'31-12-2015')

SELECT * FROM STRANGER_STRINGS.Horarios_Agenda ORDER BY Id_Especialidad_Medico