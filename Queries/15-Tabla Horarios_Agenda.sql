--15
CREATE TABLE STRANGER_STRINGS.Horarios_Agenda(
Id_Horario INT IDENTITY(1,1) PRIMARY KEY,
Dia SMALLINT,
Hora_Desde TIME,
Hora_Hasta TIME,
Id_Especialidad NUMERIC(18,0) FOREIGN KEY REFERENCES STRANGER_STRINGS.Especialidad(Especialidad_Codigo))