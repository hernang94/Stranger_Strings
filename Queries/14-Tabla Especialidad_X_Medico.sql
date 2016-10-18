--14
CREATE TABLE STRANGER_STRINGS.Especialidad_X_Medico(
Id INT IDENTITY(1,1),
Id_Medico INT ,
Especialidad_Codigo NUMERIC(18,0) ,
PRIMARY KEY (Id_Medico, Id, Especialidad_Codigo),
FOREIGN KEY (Id_Medico) REFERENCES STRANGER_STRINGS.Medico (Id_Medico),
FOREIGN KEY (Especialidad_Codigo) REFERENCES STRANGER_STRINGS.Especialidad (Especialidad_Codigo))