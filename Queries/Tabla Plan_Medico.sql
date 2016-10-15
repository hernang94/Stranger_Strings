--2
CREATE TABLE STRANGER_STRINGS.Plan_Medico(
Id_Plan INT IDENTITY(1,1) PRIMARY KEY,
Descripcion VARCHAR(255),
Precio_Bono_Consulta NUMERIC(18,0),
Precio_Bono_Farmacia NUMERIC(18,0)
)