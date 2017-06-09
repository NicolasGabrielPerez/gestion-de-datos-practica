IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_get_modif_roles')
DROP PROCEDURE FSOCIETY.sp_get_modif_roles
GO

CREATE PROCEDURE FSOCIETY.sp_get_modif_roles(@username VARCHAR(50)) 
AS
BEGIN TRANSACTION T1
  /* obtiene roles para admin y todos los roles <> admin para quien no lo sea */
  SELECT * FROM FSOCIETY.Roles
  WHERE (ID <> 1) 
  OR 1 = (SELECT ID
			FROM FSOCIETY.Usuarios u, FSOCIETY.UsuariosRoles r
            WHERE u.Username = @username
            AND r.IdRol = u.IdPersona);
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_usuarios_roles')
DROP PROCEDURE FSOCIETY.sp_delete_usuarios_roles
GO

CREATE PROCEDURE FSOCIETY.sp_delete_usuarios_roles(@id int) AS 
BEGIN TRANSACTION T1
	DELETE FSOCIETY.Usuarios where Id = @id 
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_update_roles')
DROP PROCEDURE FSOCIETY.sp_get_modif_roles
GO

CREATE PROCEDURE FSOCIETY.sp_update_roles (@id INT, @nombre VARCHAR(50), @habilitado BIT) 
AS 
BEGIN TRANSACTION T1
	UPDATE FSOCIETY.Roles 
	SET Descripcion = @nombre,
        Habilitado = @habilitado
    WHERE Id = @id;
	IF @habilitado = 0
	BEGIN
		EXECUTE FSOCIETY.sp_delete_usuarios_roles @id;
	END
COMMIT TRANSACTION T1;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_rol')
DROP PROCEDURE FSOCIETY.sp_insert_rol
GO

CREATE PROCEDURE FSOCIETY.sp_insert_rol (@nombre VARCHAR(50), @habilitado BIT) AS 
BEGIN TRANSACTION T1
	INSERT INTO FSOCIETY.Roles (Descripcion, Habilitado)
	VALUES (@nombre, @habilitado)
	
	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_get_rol_funcionalidades')
DROP PROCEDURE FSOCIETY.sp_get_rol_funcionalidades
GO

CREATE PROCEDURE FSOCIETY.sp_get_rol_funcionalidades(@idrol INT) AS BEGIN
  /* Lista las funcionalidades que tiene asignado un rol */
BEGIN TRANSACTION T1
  SELECT func.Id, func.Descripcion
    FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol
	WHERE rolfunc.IdRol = @idrol
     AND func.Id = rolfunc.IdFuncionalidad
     AND rol.Id = @idrol
END 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_funcionalidad')
DROP PROCEDURE FSOCIETY.sp_insert_funcionalidad
GO

CREATE PROCEDURE FSOCIETY.sp_insert_funcionalidad (@idrol INT, @idfun INT) AS 
BEGIN TRANSACTION T1
  /* agrego funcionalidad si no existe */
    INSERT INTO FSOCIETY.RolFuncionalidades (idRol, IdFuncionalidad)
    VALUES (@idrol, @idfun)
    if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_funcionalidad')
DROP PROCEDURE FSOCIETY.sp_delete_funcionalidad
GO

CREATE PROCEDURE FSOCIETY.sp_delete_funcionalidad (@idrol INT, @idfun INT) AS 
BEGIN TRANSACTION T1
  DELETE FROM FSOCIETY.RolFuncionalidades
   WHERE IdRol = @idrol
     AND IdFuncionalidad = @idfun

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION T1
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_delete_all_funcionalidades')
DROP PROCEDURE FSOCIETY.sp_delete_all_funcionalidades
GO

CREATE PROCEDURE FSOCIETY.sp_delete_all_funcionalidades (@idrol INT) AS 
BEGIN TRANSACTION T1
  DELETE FROM FSOCIETY.RolFuncionalidades
   WHERE IdRol = @idrol
     
	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
COMMIT TRANSACTION T1
GO