--19
CREATE TABLE STRANGER_STRINGS.Turno(
Turno_Numero INT IDENTITY(1,1) PRIMARY KEY,
Turno_Fecha DATETIME,
Id_Paciente INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Medico INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Medico(Id_Medico),
Id_Consulta INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Consulta(Id_Consulta),
Id_Cancelacion INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Cancelacion_Turno(Id_Cancelacion),
Id_Horario INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Horarios_Agenda(Id_Horario))