INSERT INTO STRANGER_STRINGS.Usuario (Usuario,Pasword) values ('Pepe',HASHBYTES('SHA2_256','Judios'))
SELECT Pasword FROM STRANGER_STRINGS.Usuario
WHERE Pasword LIKE HASHBYTES('SHA2_256','Judios')
SELECT CONVERT(VARCHAR(18),Num_Doc) As Usuario, HASHBYTES('SHA2_256',Apellido) As Password
FROM STRANGER_STRINGS.Paciente
SELECT HASHBYTES('SHA2_256',Apellido)
FROM STRANGER_STRINGS.Paciente
