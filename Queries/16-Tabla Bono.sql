--16
CREATE TABLE STRANGER_STRINGS.Bono(
Id_Bono INT IDENTITY(1,1) PRIMARY KEY,
Fecha_Compra DATETIME,
Fecha_Impresion DATETIME,
Id_Paciente_Compro INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Paciente_Uso INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Paciente(Id_Paciente),
Id_Plan INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Plan_Medico(Id_Plan),
Numero_Consulta INT,
Id_Compra INT FOREIGN KEY REFERENCES STRANGER_STRINGS.Compra(Id_Compra)
//fijarse si esta bien las FK de pacientes con el DER