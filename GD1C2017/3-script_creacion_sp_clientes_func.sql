IF (OBJECT_ID ('FSOCIETY.sp_set_rol_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_set_rol_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_set_rol_cliente (@idCliente int)
AS BEGIN
BEGIN TRANSACTION
	INSERT INTO FSOCIETY.UsuariosRoles (IdUsuario, IdRol)
	values(@idCliente, 3)

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_crear_persona') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_crear_persona
GO

CREATE PROCEDURE FSOCIETY.sp_crear_persona (@nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
										@direccion NVARCHAR(255),
                                        @fecha_nacimiento DATETIME,
										@id INT OUTPUT)
AS BEGIN
    BEGIN TRANSACTION T1

	set @id = (SELECT MAX(id)+1 from FSOCIETY.Personas);

	insert into FSOCIETY.Personas (Nombre, Apellido, DNI, Direccion, [Fecha de Nacimiento])
	values (@nombre, @apellido, @dni, @direccion, @fecha_nacimiento)

  	Execute FSOCIETY.sp_create_user @id

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_crear_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_crear_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_crear_cliente (@telefono varchar(50), 
											@mail varchar(50),
											@codigoPostal varchar(10),
											@idCliente int OUTPUT,
											@habilitado int)
AS BEGIN
    BEGIN TRANSACTION T1

	insert into FSOCIETY.Cliente(id, Telefono, Email, Codigo_Postal, Habilitado)
	values (@idCliente, @telefono, @mail, @codigoPostal, @habilitado);
	
	if(@habilitado !=0)
		execute FSOCIETY.sp_set_rol_cliente @idCliente;

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_get_clientes') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_get_clientes
GO

CREATE PROCEDURE FSOCIETY.sp_get_clientes (@fieldName varchar(50), @fieldValue varchar(40))
AS BEGIN
	select per.Id, per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, 
per.[Fecha de Nacimiento], per.Direccion, cli.Codigo_Postal, cli.Habilitado
	from FSOCIETY.Personas per, FSOCIETY.Cliente cli, FSOCIETY.Usuarios us
	where per.Id = us.IdPersona and us.Id = cli.Id
		   and @fieldName = @fieldValue
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_get_cliente_by_id') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_get_cliente_by_id
GO

CREATE PROCEDURE FSOCIETY.sp_get_cliente_by_id(@id int)
AS BEGIN
	select per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, 
		   per.[Fecha de Nacimiento], per.Direccion, cli.Codigo_Postal, cli.Habilitado
	from FSOCIETY.Personas per, FSOCIETY.Cliente cli, FSOCIETY.Usuarios us
	where per.Id = us.IdPersona and us.Id = cli.Id
	and cli.Id = @id
END		   
GO

IF (OBJECT_ID ('FSOCIETY.sp_modificar_persona') IS NOT NULL)
  DROP PROCEDURE FSOCIETY.sp_modificar_persona
GO

CREATE PROCEDURE FSOCIETY.sp_modificar_persona (@nombre NVARCHAR(255),
                                        @apellido NVARCHAR(255),
                                        @dni NUMERIC(18, 0),
										@direccion NVARCHAR(255),
                                        @fecha_nacimiento DATETIME,
										@id INT OUTPUT)
AS BEGIN
    BEGIN TRANSACTION T1

	UPDATE FSOCIETY.Personas 
	set Nombre= @nombre, 
	Apellido = @apellido, 
	DNI = @dni, 
	Direccion = @direccion, 
	[Fecha de Nacimiento] = @fecha_nacimiento
	where Id = @id

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_delete_rol_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_delete_rol_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_delete_rol_cliente (@idCliente int)
AS BEGIN
BEGIN TRANSACTION T1
	
	DELETE FSOCIETY.UsuariosRoles 
	WHERE IdUsuario = @idCliente
	and IdRol = 3

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_modificar_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_modificar_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_modificar_cliente (@telefono varchar(50), 
											@mail varchar(50),
											@codigoPostal varchar(10),
											@idCliente int OUTPUT,
											@habilitado int)
AS BEGIN
    BEGIN TRANSACTION T1
	

	declare @estadoPrevio int = (select Habilitado 
								from FSOCIETY.Chofer 
								where Id = @idCliente)

	UPDATE FSOCIETY.Cliente
	set Telefono = @telefono, 
	Email = @mail, 
	Codigo_Postal = @codigoPostal, 
	Habilitado = @habilitado
	where Id = @idCliente

	if(@estadoPrevio = 1 and @estadoPrevio != @habilitado)
		execute FSOCIETY.sp_delete_rol_cliente @idCliente;

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_delete_rol_cliente') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_delete_rol_cliente
GO

CREATE PROCEDURE FSOCIETY.sp_delete_rol_cliente (@idCliente int)
AS BEGIN
BEGIN TRANSACTION T1
	
	DELETE FSOCIETY.UsuariosRoles 
	WHERE IdUsuario = @idCliente
	and IdRol = 3

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION
END
GO