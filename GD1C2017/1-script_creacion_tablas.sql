USE [GD1C2017]
GO

/*Set schema*/
DECLARE @schemaName as nvarchar(100)
DECLARE @schemaId as int

SET @schemaName = 'FSOCIETY'
SET @schemaId = (select schema_id from sys.schemas where name = @schemaName)

/*Drop constraints*/
DECLARE @query AS nvarchar(400)
DECLARE foreingkeys CURSOR FOR SELECT 
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE schema_id=@schemaId

OPEN foreingkeys

FETCH NEXT FROM foreingkeys INTO @query

WHILE @@fetch_status = 0

BEGIN
    --PRINT @query
	exec (@query)
    FETCH NEXT FROM foreingkeys INTO @query
END
CLOSE foreingkeys
DEALLOCATE foreingkeys

/*Drop tables*/
DECLARE @queryDrop AS nvarchar(400)
DECLARE tables CURSOR FOR select 
	'DROP TABLE [' + s.name +
	'].[' + t.name + ']'
from sys.tables t
inner join sys.schemas s on t.schema_id = s.schema_id
where t.schema_id=@schemaId

OPEN tables

FETCH NEXT FROM tables INTO @queryDrop

WHILE @@fetch_status = 0

BEGIN
    --PRINT @queryDrop
	exec (@queryDrop)
    FETCH NEXT FROM tables INTO @queryDrop
END
CLOSE tables
DEALLOCATE tables

/*DROP PROCEDURES*/
DECLARE @procedureDrop AS nvarchar(400)
DECLARE proceduress CURSOR FOR select 
'DROP PROCEDURE [' + s.name +
	'].[' + o.name + ']'
from sys.objects o
inner join sys.schemas s on o.schema_id = s.schema_id
where o.schema_id=@schemaId and type = 'P'

OPEN proceduress

FETCH NEXT FROM proceduress INTO @procedureDrop
WHILE @@fetch_status = 0

BEGIN
	exec (@procedureDrop)
    FETCH NEXT FROM proceduress INTO @procedureDrop
END
CLOSE proceduress
DEALLOCATE proceduress

/* DROP SCHEMA*/
/*
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'FSOCIETY')
    DROP SCHEMA FSOCIETY
GO
*/
/* SCHEMA CREATION */

/*CREATE SCHEMA FSOCIETY
GO
*/
/****** Object:  Table [FSOCIETY].[Autos]    Script Date: 21/04/2017 12:36:03 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

----------------------------------------
--Roles
----------------------------------------

CREATE TABLE [FSOCIETY].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----------------------------------------
--Funcionalidades
----------------------------------------
CREATE TABLE [FSOCIETY].[Funcionalidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[FormName] [varchar](50) NULL,
	[IdFuncionalidadPadre] [int] NULL
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Funcionalidades_Funcionalidades] FOREIGN KEY([IdFuncionalidadPadre])
REFERENCES [FSOCIETY].[Funcionalidades] ([Id])
GO

ALTER TABLE [FSOCIETY].[Funcionalidades] CHECK CONSTRAINT [FK_Funcionalidades_Funcionalidades]
GO
----------------------------------------
--RolFuncionalidades
----------------------------------------
CREATE TABLE [FSOCIETY].[RolFuncionalidades](
	[IdRol] [int] NOT NULL,
	[IdFuncionalidad] [int] NOT NULL,
 CONSTRAINT [PK_RolFuncionalidades] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC,
	[IdFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncionalidades_Funcionalidades] FOREIGN KEY([IdFuncionalidad])
REFERENCES [FSOCIETY].[Funcionalidades] ([Id])
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades] CHECK CONSTRAINT [FK_RolFuncionalidades_Funcionalidades]
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades]  WITH CHECK ADD  CONSTRAINT [FK_RolFuncionalidades_Roles] FOREIGN KEY([IdRol])
REFERENCES [FSOCIETY].[Roles] ([Id])
GO

ALTER TABLE [FSOCIETY].[RolFuncionalidades] CHECK CONSTRAINT [FK_RolFuncionalidades_Roles]
GO

----------------------------------------
--Personas
----------------------------------------
CREATE TABLE [FSOCIETY].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[DNI] [varchar](8) NOT NULL UNIQUE,
	[Direccion] [varchar](250) NOT NULL,
	[Fecha de Nacimiento] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----------------------------------------
--Usuarios
----------------------------------------
CREATE TABLE [FSOCIETY].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Reintentos] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([IdPersona])
REFERENCES [FSOCIETY].[Personas] ([Id])
GO

ALTER TABLE [FSOCIETY].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas]
GO
----------------------------------------
--UsuariosRoles
----------------------------------------
CREATE TABLE [FSOCIETY].[UsuariosRoles](
	[IdUsuario] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_UsuariosRoles] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY([IdRol])
REFERENCES [FSOCIETY].[Roles] ([Id])
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Roles]
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosRoles_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[UsuariosRoles] CHECK CONSTRAINT [FK_UsuariosRoles_Usuarios]
GO
----------------------------------------
--Chofer
----------------------------------------
CREATE TABLE [FSOCIETY].[Chofer](
	[Id] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Chofer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Chofer]  WITH CHECK ADD  CONSTRAINT [FK_Chofer_Usuarios] FOREIGN KEY([Id])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[Chofer] CHECK CONSTRAINT [FK_Chofer_Usuarios]
GO
----------------------------------------
--Marcas
----------------------------------------
CREATE TABLE [FSOCIETY].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
----------------------------------------
--Modelo
----------------------------------------
CREATE TABLE [FSOCIETY].[Modelos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Modelos]  WITH CHECK ADD  CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [FSOCIETY].[Marcas] ([Id])
GO

ALTER TABLE [FSOCIETY].[Modelos] CHECK CONSTRAINT [FK_Modelos_Marcas]
GO

----------------------------------------
--Turnos
----------------------------------------
CREATE TABLE [FSOCIETY].[Turnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora_De_Inicio] [int] NOT NULL,
	[Hora_De_Finalizacion] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Valor_Km] [smallmoney] NOT NULL,
	[Precio_Base] [smallmoney] NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
----------------------------------------
--Autos
----------------------------------------
CREATE TABLE [FSOCIETY].[Autos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](8) NOT NULL,
	[IdModelo] [int] NOT NULL,
	[IdChofer] [int] NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Autos] CHECK CONSTRAINT [FK_Autos_Chofer]
GO

ALTER TABLE [FSOCIETY].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Modelos] FOREIGN KEY([IdModelo])
REFERENCES [FSOCIETY].[Modelos] ([Id])
GO

ALTER TABLE [FSOCIETY].[Autos] CHECK CONSTRAINT [FK_Autos_Modelos]
GO

----------------------------------------
--AutosTurnos
----------------------------------------

CREATE TABLE [FSOCIETY].[AutosTurnos](
	[IdAuto] [int] NOT NULL,
	[IdTurno] [int] NOT NULL,
 CONSTRAINT [PK_AutosTurnos] PRIMARY KEY CLUSTERED 
(
	[IdAuto] ASC,
	[IdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [FSOCIETY].[AutosTurnos]  WITH CHECK ADD  CONSTRAINT [FK_AutosTurnos_Autos] FOREIGN KEY([IdAuto])
REFERENCES [FSOCIETY].[Autos] ([Id])
GO

ALTER TABLE [FSOCIETY].[AutosTurnos] CHECK CONSTRAINT [FK_AutosTurnos_Autos]
GO

ALTER TABLE [FSOCIETY].[AutosTurnos]  WITH CHECK ADD  CONSTRAINT [FK_AutosTurnos_Turnos] FOREIGN KEY([IdTurno])
REFERENCES [FSOCIETY].[Turnos] ([Id])
GO

ALTER TABLE [FSOCIETY].[AutosTurnos] CHECK CONSTRAINT [FK_AutosTurnos_Turnos]
GO

----------------------------------------
--Cliente
----------------------------------------
CREATE TABLE [FSOCIETY].[Cliente](
	[Id] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Codigo_Postal] [varchar](10) NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuarios] FOREIGN KEY([Id])
REFERENCES [FSOCIETY].[Usuarios] ([Id])
GO

ALTER TABLE [FSOCIETY].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuarios]
GO

----------------------------------------
--Viajes
----------------------------------------
CREATE TABLE [FSOCIETY].[Viaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdChofer] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[CantKm] [int] NOT NULL,
	[FechaHoraInicio] [date] NOT NULL,
	[FechaHoraFin] [date] NOT NULL
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[Id]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Chofer]
GO

ALTER TABLE [FSOCIETY].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [FSOCIETY].[Cliente] ([Id])
GO

ALTER TABLE [FSOCIETY].[Viaje] CHECK CONSTRAINT [FK_Viaje_Cliente]
GO
----------------------------------------
--Facturacion
----------------------------------------
CREATE TABLE [FSOCIETY].[Facturacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdViaje] [int] NOT NULL,
	[FechaInicio] [smalldatetime] NOT NULL,
	[FechaFin] [smalldatetime] NOT NULL,
	[Importe] [money] NOT NULL,
 CONSTRAINT [PK_Facturacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Facturacion]  WITH CHECK ADD  CONSTRAINT [FK_Facturacion_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [FSOCIETY].[Cliente] ([Id])
GO

ALTER TABLE [FSOCIETY].[Facturacion] CHECK CONSTRAINT [FK_Facturacion_Cliente]
GO

ALTER TABLE [FSOCIETY].[Facturacion]  WITH CHECK ADD  CONSTRAINT [FK_Facturacion_Viaje] FOREIGN KEY([IdViaje])
REFERENCES [FSOCIETY].[Viaje] ([Id])
GO

ALTER TABLE [FSOCIETY].[Facturacion] CHECK CONSTRAINT [FK_Facturacion_Viaje]
GO



----------------------------------------
--Rendicion
----------------------------------------
CREATE TABLE [FSOCIETY].[Rendicion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdChofer] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[ImporteTotal] [money] NOT NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [FSOCIETY].[Rendicion]  WITH CHECK ADD  CONSTRAINT [FK_Rendicion_Chofer] FOREIGN KEY([IdChofer])
REFERENCES [FSOCIETY].[Chofer] ([Id])
GO

ALTER TABLE [FSOCIETY].[Rendicion] CHECK CONSTRAINT [FK_Rendicion_Chofer]
GO

----------------------------------------
--Creo al admin
----------------------------------------
insert into FSOCIETY.Personas(Nombre,Apellido,DNI,Direccion,[Fecha de Nacimiento])
values('Admin','Admin','35323521','Salvigny 1821','1990/07/25')

GO

insert into FSOCIETY.Usuarios(Username,Password,IdPersona,Reintentos)
values('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1,0)

GO

INSERT INTO FSOCIETY.Roles (Descripcion, Habilitado)
VALUES ('Administrador', 1),
       ('Chofer', 1),
       ('Cliente', 1);

GO

INSERT INTO FSOCIETY.UsuariosRoles
VALUES(1,1),(1,2);

GO

INSERT INTO FSOCIETY.Funcionalidades(Descripcion,FormName,IdFuncionalidadPadre)
VALUES('Clientes',NULL,NULL),('Choferes',NULL,NULL),('Autos',NULL,NULL),
	  ('Alta Cliente','ABMCliente',1),('Baja Cliente',NULL,1),('Alta Chofer','ABMChofer',2),
	  ('Consultas Autos','Automovil',3),('Roles',NULL,NULL),('Abm Roles','AbmRol',8),
	  ('Viajes',NULL,NULL),('Registrar Viaje','Viaje',10);

GO

INSERT INTO FSOCIETY.RolFuncionalidades(IdRol,IdFuncionalidad)
SELECT 1, Id FROM FSOCIETY.Funcionalidades

GO

SET ANSI_PADDING OFF
GO

---------------------------------------
--Creo stores
---------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_hash_password')
DROP PROCEDURE FSOCIETY.sp_hash_password
GO

CREATE PROCEDURE [FSOCIETY].[sp_hash_password](@password VARCHAR(50),@hash NVARCHAR(65) OUTPUT)
AS
SELECT @hash = CONVERT(NVARCHAR(64),HashBytes('SHA2_256', @password),2)

GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_user')
DROP PROCEDURE FSOCIETY.sp_insert_user
GO

CREATE PROCEDURE [FSOCIETY].[sp_insert_user](@username VARCHAR(50),@idPersona int)
AS
	DECLARE @PASSWORD NVARCHAR(65)
	EXECUTE FSOCIETY.sp_hash_password @username,@PASSWORD output
	INSERT INTO FSOCIETY.Usuarios(Username,Password,IdPersona,Reintentos)
	VALUES (@username, @PASSWORD, @idPersona,0)


GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_create_user')
DROP PROCEDURE FSOCIETY.sp_create_user
GO

CREATE PROCEDURE [FSOCIETY].[sp_create_user](@idPersona int)
AS

DECLARE @ID int
DECLARE @USER VARCHAR(50)
DECLARE @usernameDefault varchar(50)
SET @usernameDefault = 'user'

	SELECT top 1 @ID=Id FROM FSOCIETY.Usuarios WHERE Username LIKE CONCAT(@usernameDefault,'%') ORDER BY Id DESC
IF	(@ID IS NULL)
	SET @USER = CONCAT(@usernameDefault,1)
ELSE
	SET @USER = CONCAT(@usernameDefault,@ID+1)

EXECUTE FSOCIETY.sp_insert_user @USER,@idPersona


GO

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
	INSERT INTO FSOCIETY.Roles (Id, Descripcion, Habilitado)
	VALUES (NEXT VALUE FOR Id, @nombre, @habilitado)
COMMIT TRANSACTION T1
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
COMMIT TRANSACTION T1
GO

----------------------------------
-- Store roles
----------------------------------
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_rol')
DROP PROCEDURE FSOCIETY.sp_insert_rol
GO

CREATE PROCEDURE FSOCIETY.sp_insert_rol (@nombre VARCHAR(50), @habilitado BIT) AS 
BEGIN TRANSACTION T1
	INSERT INTO FSOCIETY.Roles (Id, Descripcion, Habilitado)
	VALUES (NEXT VALUE FOR Id, @nombre, @habilitado)
COMMIT TRANSACTION T1
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
COMMIT TRANSACTION T1
GO

------------------------
--Store Clientes
------------------------
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

------------------------
--Store Choferes
------------------------

IF (OBJECT_ID ('FSOCIETY.sp_crear_chofer') IS NOT NULL)
	DROP PROCEDURE FSOCIETY.sp_crear_chofer
GO

CREATE PROCEDURE FSOCIETY.sp_crear_chofer (@telefono varchar(50), 
											@mail varchar(50),
											@idChofer int OUTPUT,
											@habilitado int)
AS BEGIN
    BEGIN TRANSACTION T1

	insert into FSOCIETY.Cliente(id, Telefono, Email, Habilitado)
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

	UPDATE FSOCIETY.Cliente
	set Telefono = @telefono, 
	Email = @mail, 
	Habilitado = @habilitado
	where Id = @idChofer

	if (@@ERROR !=0)
        ROLLBACK TRANSACTION T1;
	COMMIT TRANSACTION T1;
	
END
GO

----------------------------------
--Migracion Choferes
----------------------------------

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

DROP TABLE #choferes

GO

----------------------------------
--Migracion Clientes
----------------------------------

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

DROP TABLE #clientes

GO

---------------------------
--Migracion Autos
---------------------------
--Migro marcas
INSERT INTO FSOCIETY.Marcas(Description)
SELECT DISTINCT Auto_Marca FROM gd_esquema.Maestra

--Migro Modelos
INSERT INTO FSOCIETY.Modelos(Description,IdMarca)
SELECT DISTINCT Auto_Modelo,m.Id FROM gd_esquema.Maestra AS maestra
INNER JOIN FSOCIETY.Marcas AS m ON m.Description = maestra.Auto_Marca


-- Migro Turnos
INSERT INTO FSOCIETY.Turnos(Hora_De_Inicio, Hora_De_Finalizacion, Descripcion, Valor_Km, Precio_Base, Habilitado)
	SELECT DISTINCT Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base, 1 FROM gd_esquema.Maestra

-- Migro Autos
INSERT INTO FSOCIETY.Autos(Patente, IdModelo, IdChofer, Habilitado)
	SELECT DISTINCT	MAESTRA.Auto_Patente, MODELOS.Id, CHOFER.Id, 1 
		FROM gd_esquema.Maestra MAESTRA
			INNER JOIN FSOCIETY.Modelos MODELOS ON MAESTRA.Auto_Modelo = MODELOS.Description
			INNER JOIN FSOCIETY.Chofer CHOFER ON MAESTRA.Chofer_Telefono = CHOFER.Telefono

			-- Migro Autos con turnos
insert into FSOCIETY.AutosTurnos(IdAuto,IdTurno)
	Select distinct a.Id,t.Id FROM gd_esquema.Maestra m
		inner join FSOCIETY.Autos a on a.Patente = m.Auto_Patente
		inner join FSOCIETY.Turnos t on t.Descripcion = m.Turno_Descripcion
