
--Genero tabla temporal con los datos de los choferes
Select distinct Chofer_Dni,Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Fecha_Nac, Chofer_Mail, Chofer_Telefono
into #choferes
from gd_esquema.Maestra

--Migro los datos de choferes a personas.
insert into FSOCIETY.Personas(DNI,Nombre,Apellido,Direccion,[Fecha de Nacimiento])
Select distinct Chofer_Dni,Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Fecha_Nac 
from #choferes

--Genero los usuarios para todos los choferes
DECLARE Mi_Cursor CURSOR FOR 
Select Id from FSOCIETY.Personas p
inner join #choferes c on c.Chofer_DNI = p.DNI

DECLARE @query int

OPEN Mi_Cursor
FETCH NEXT FROM Mi_Cursor INTO @query

WHILE @@FETCH_STATUS = 0

BEGIN
	EXECUTE FSOCIETY.sp_create_user @query
	FETCH NEXT FROM Mi_Cursor INTO @query
END
CLOSE Mi_Cursor
DEALLOCATE Mi_Cursor

--Cargo la tabla chofer
insert into FSOCIETY.Chofer(Id,Email,Telefono,Habilitado)
Select u.Id,c.Chofer_Mail,c.Chofer_Telefono,1 from FSOCIETY.Personas p
inner join #choferes c on c.Chofer_DNI = p.DNI
inner join FSOCIETY.Usuarios u on u.IdPersona = p.Id

--Hago que los usuarios tengan rol Chofer
insert into FSOCIETY.UsuariosRoles(IdUsuario,IdRol)
Select u.Id,(SELECT Id From FSOCIETY.Roles where Descripcion='Chofer') from FSOCIETY.Personas p
inner join #choferes c on c.Chofer_DNI = p.DNI
inner join FSOCIETY.Usuarios u on u.IdPersona = p.Id

--Chequeo
/*Select * from FSOCIETY.Usuarios u
inner join FSOCIETY.Personas p on p.Id = u.IdPersona
inner join FSOCIETY.Chofer c on c.Id = u.Id
inner join FSOCIETY.UsuariosRoles ur on ur.IdUsuario = u.Id
inner join FSOCIETY.Roles ro on ur.IdRol = ro.Id*/

DROP TABLE #choferes