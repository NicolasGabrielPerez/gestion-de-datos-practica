
IF (OBJECT_ID ('FSOCIETY.sp_crear_chofer') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_crear_chofer
GO

CREATE PROCEDURE FSOCIETY.sp_crear_chofer (@telefono varchar(50), 
											@mail varchar(50),
											@idChofer int OUTPUT,
											@habilitado int)
AS BEGIN
    BEGIN TRANSACTION T1

	insert into FSOCIETY.Chofer(id, Telefono, Email, Habilitado)
	values (@idChofer, @telefono, @mail, @habilitado);
	
	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_get_chofer') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_get_chofer
GO

CREATE PROCEDURE FSOCIETY.sp_get_chofer (@fieldName varchar(50), @fieldValue varchar(40))
AS BEGIN
	select per.Id, per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, 
per.[Fecha de Nacimiento], per.Direccion, cli.Habilitado
	from FSOCIETY.Personas per, FSOCIETY.Chofer cli, FSOCIETY.Usuarios us
	where per.Id = us.IdPersona and us.Id = cli.Id
		   and @fieldName = @fieldValue
END
GO

IF (OBJECT_ID ('FSOCIETY.sp_get_chofer_by_id') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_get_chofer_by_id
GO

CREATE PROCEDURE FSOCIETY.sp_get_chofer_by_id(@id int)
AS BEGIN
	select per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, 
		   per.[Fecha de Nacimiento], per.Direccion,  cli.Habilitado
	from FSOCIETY.Personas per, FSOCIETY.Chofer cli, FSOCIETY.Usuarios us
	where per.Id = us.IdPersona and us.Id = cli.Id
	and cli.Id = @id
END		   
GO

IF (OBJECT_ID ('FSOCIETY.sp_modificar_chofer') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_modificar_chofer
GO

CREATE PROCEDURE FSOCIETY.sp_modificar_chofer (@telefono varchar(50), 
											@mail varchar(50),
											@idChofer int OUTPUT,
											@habilitado int)
AS BEGIN
    BEGIN TRANSACTION T1
	

	declare @estadoPrevio int = (select Habilitado 
								from FSOCIETY.Chofer 
								where Id = @idChofer)

	UPDATE FSOCIETY.Chofer
	set Telefono = @telefono, 
	Email = @mail, 
	Habilitado = @habilitado
	where Id = @idChofer

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

