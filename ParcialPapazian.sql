--Lila Papazian, parcial 06/06/2017
--Ejercicio 1
SELECT YEAR(fact_fecha) as Año, 
	   zona_codigo as CodigoDeZona, 
	   zona_detalle as DetalleDeZona, 
	   (SELECT COUNT(depo_codigo) FROM DEPOSITO WHERE depo_zona=zona_codigo) as CantidadDepositosEnZona,
	   (SELECT COUNT(empl_codigo) FROM Empleado JOIN Departamento ON depa_codigo=empl_departamento  WHERE depa_zona=zona_codigo) as							CantidadEmpleadosDepartamentosEnZona,
	   (SELECT TOP 1 e.empl_codigo FROM Empleado e, Factura f WHERE e.empl_codigo IN (SELECT empl_codigo FROM Empleado JOIN Departamento ON																							empl_departamento=depa_codigo WHERE depa_zona=zona_codigo)
																				  AND YEAR(f.fact_fecha)=YEAR(fact_fecha)
		GROUP BY e.empl_codigo
		ORDER BY SUM(f.fact_total) DESC) as EmpleadoQueMasVendio,
		(SELECT SUM(f.fact_total)
		FROM Empleado e, Factura f WHERE e.empl_codigo IN (SELECT empl_codigo FROM Empleado JOIN Departamento ON																							empl_departamento=depa_codigo WHERE depa_zona=zona_codigo)
														AND YEAR(f.fact_fecha)=YEAR(fact_fecha)
		) as MontoTotalVentaZona
FROM Factura, Zona
GROUP BY year(fact_fecha), zona_codigo, zona_detalle
ORDER BY YEAR(fact_fecha), 	(SELECT SUM(f.fact_total) FROM Empleado e, Factura f WHERE e.empl_codigo IN (SELECT empl_codigo FROM Empleado JOIN								Departamento ON	empl_departamento=depa_codigo WHERE depa_zona=zona_codigo) AND YEAR(f.fact_fecha)=YEAR(fact_fecha)) DESC

--Ejercicio 2
--

/*
Ejercicio 3)a) VERDADERO

1.a) Los niveles de aislamiento son read uncommited, read commited, repeteable read, snapshot y serializable.
El nivel read uncommited ve los insert, update y delete commiteados y no commiteados, lo que puede llevar a lecturas sucias y eventualmente generar datos erróneos o fantasma. Este nivel no permite lecturas repetibles, el select no produce bloqueo sobre las tablas en las cuales trabaja.
El nivel read commited ve sólo los insert, update y delete commiteados; al leer sólo información confirmada no se producen lecturas sucias. El select aplica bloque de update y delete sobre su rango, lo cual permite lecturas no repetibles.
El nivel repeteable read ve sólo los insert commiteados, lo cual impide lecturas sucias. El select bloquea las tablas sobre las cuales trabaja, pero permite hacer inserts, con lo cual si otras transacciones insertaron filas nuevas, al repetir la transacción actual se recuperarán filas nuevas, dando como resultado lecturas fantasma.
El nivel snapshot ve los update commiteados, no hay lecturas sucias. Todas las queries ven la misma versión de la base de datos al momento de iniciar la transaccion.
El nivel serializable transforma un modelo concurrente en un modelo serial (monousuario). Permite lecturas repetibles ya que el select aplica un bloque total sobre las tablas sobre las cuales trabaja.

b) Un DW  es una gran base de dattos que almacena datos históricos y redundantes para una empresa para un posterior análisis. La principal función de un DW es servir como input para herramientas como OLAP o DM (Data Mining), que convierten los datos almacenados en información relevante para la toma de decisiones. Si el modelo de la base de datos es multidimensional, la misma se divide en una tabla de hechos (Fact Table) y varias tablas de dimensiones (Dimension Table).
La Fact Table contiene la información que corresponde a un proceso particular (es decir, contiene un hecho y un conjunto de indicadores). Cada fila representa un sólo evento asociado con ese proceso y contiene los indicadores asociados al mismo. La información contenida en una Fact Table es generalmente de tipo numérico y suele ser fácilmente manipulable.
Las Dimension Table contienen un conjunto de atributos que la definen, lo cual corresponde a detalles de cada instancia de los eventos de la Fact Table.
Ambas tables están relacionadas entre sí, la Fact Table contiene foreign keys que referencian a la Dimension Table, donde cada entrada corresponde a una primary key en la tabla.