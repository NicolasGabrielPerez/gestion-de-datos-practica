
--Genero tabla temporal con los datos de los clientes
Select distinct Cliente_Dni,Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Fecha_Nac, Cliente_Mail, Cliente_Telefono
into #clientes
from gd_esquema.Maestra

--Migro los datos de clientes a personas.
insert into FSOCIETY.Personas(DNI,Nombre,Apellido,Direccion,[Fecha de Nacimiento])
Select distinct Cliente_Dni,Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Fecha_Nac
from #clientes

--Genero los usuarios para todos los clientes
DECLARE Mi_Cursor CURSOR FOR 
Select Id from FSOCIETY.Personas p
inner join #clientes c on c.Cliente_Dni = p.DNI

DECLARE @idPersona int

OPEN Mi_Cursor
FETCH NEXT FROM Mi_Cursor INTO @idPersona

WHILE @@FETCH_STATUS = 0

BEGIN
	EXECUTE FSOCIETY.sp_create_user @idPersona
	FETCH NEXT FROM Mi_Cursor INTO @idPersona
END
CLOSE Mi_Cursor
DEALLOCATE Mi_Cursor

--Cargo la tabla cliente
insert into FSOCIETY.Cliente(Id,Email,Telefono,Codigo_Postal,Habilitado)
Select u.Id,c.Cliente_Mail,c.Cliente_Telefono,'1406',1 from FSOCIETY.Personas p
inner join #clientes c on c.Cliente_Dni = p.DNI
inner join FSOCIETY.Usuarios u on u.IdPersona = p.Id

--Hago que los usuarios tengan rol cliente
insert into FSOCIETY.UsuariosRoles(IdUsuario,IdRol)
Select u.Id,(SELECT Id From FSOCIETY.Roles where Descripcion='cliente') from FSOCIETY.Personas p
inner join #clientes c on c.Cliente_Dni = p.DNI
inner join FSOCIETY.Usuarios u on u.IdPersona = p.Id

--Chequeo
/*Select * from FSOCIETY.Usuarios u
inner join FSOCIETY.Personas p on p.Id = u.IdPersona
inner join FSOCIETY.Cliente c on c.Id = u.Id
inner join FSOCIETY.UsuariosRoles ur on ur.IdUsuario = u.Id
inner join FSOCIETY.Roles ro on ur.IdRol = ro.Id*/

DROP TABLE #clientes