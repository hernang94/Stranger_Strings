
DECLARE cursorcito CURSOR FOR
SELECT DISTINCT Paciente_Nombre, Paciente_Apellido,Paciente_Dni FROM gd_esquema.Maestra


DECLARE @nombre varchar(255), @apellido varchar(255),@dni numeric(18,0)
OPEN cursorcito;
FETCH NEXT FROM cursorcito INTO @nombre,@apellido,@dni
WHILE @@FETCH_STATUS=0
BEGIN
INSERT INTO STRANGER_STRINGS.Paciente (Nombre,Apellido,Tipo_Doc,Num_Doc) VALUES(@nombre,@apellido,'DNI',@dni)
FETCH NEXT FROM cursorcito INTO @nombre,@apellido,@dni
END;
CLOSE cursorcito

DEALLOCATE cursorcito