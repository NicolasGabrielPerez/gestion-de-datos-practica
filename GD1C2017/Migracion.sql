--Migro marcas
INSERT INTO FSOCIETY.Marcas(Description)
SELECT DISTINCT Auto_Marca FROM gd_esquema.Maestra

--Migro Modelos
INSERT INTO FSOCIETY.Modelos(Description,IdMarca)
SELECT DISTINCT Auto_Modelo,m.Id FROM gd_esquema.Maestra AS maestra
INNER JOIN FSOCIETY.Marcas AS m ON m.Description = maestra.Auto_Marca

--Ingreso Personas de choferes
INSERT INTO FSOCIETY.Personas(DNI,Nombre,Apellido,Direccion,[Fecha de Nacimiento])
SELECT DISTINCT Chofer_Dni,Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Fecha_Nac FROM gd_esquema.Maestra

--Ingreso Personas de clientes
INSERT INTO FSOCIETY.Personas(DNI,Nombre,Apellido,Direccion,[Fecha de Nacimiento])
SELECT DISTINCT Cliente_Dni,Cliente_Nombre,Cliente_Apellido,Cliente_Direccion,Cliente_Fecha_Nac FROM gd_esquema.Maestra

-- Migro Turnos
INSERT INTO FSOCIETY.Turnos(Hora_De_Inicio, Hora_De_Finalizacion, Descripcion, Valor_Km, Precio_Base, Habilitado)
	SELECT DISTINCT Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base, 1 FROM gd_esquema.Maestra

-- Migro Autos
INSERT INTO FSOCIETY.Autos(Patente, IdModelo, IdTurno, IdChofer, Habilitado)
	SELECT DISTINCT	MAESTRA.Auto_Patente, MODELOS.Id, TURNOS.Id, CHOFER.Id, 1 
		FROM gd_esquema.Maestra MAESTRA
			INNER JOIN FSOCIETY.Modelos MODELOS ON MAESTRA.Auto_Modelo = MODELOS.Description
			INNER JOIN FSOCIETY.Turnos TURNOS ON MAESTRA.Turno_Descripcion = TURNOS.Descripcion
			INNER JOIN FSOCIETY.Chofer CHOFER ON MAESTRA.Chofer_Telefono = CHOFER.Telefono