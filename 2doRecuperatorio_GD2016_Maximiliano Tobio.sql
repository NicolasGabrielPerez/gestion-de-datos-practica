-- Teoria Aprobada --

-- Ejercicio 2
CREATE TRIGGER compraAPrecioMenor
ON Factura
FOR INSERT AS
Begin
	Declare @total as float, @numero as char(8), @tipo as char(1), @sucursal as char(4), @cliente char(6), @precio as float
	Declare COMPRA cursor for select f.fact_numero, f.fact_sucursal, f.fact_tipo, f.fact_fecha from Factura f
		inner join inserted i on (f.fact_tipo=i.fact_tipo and f.fact_numero=i.fact_numero and f.fact_sucursal =i.fact_sucursal)
		inner join Cliente c on (c.clie_codigo=i.fact_cliente)
		where f.fact_numero=i.fact_numero and f.fact_sucursal=i.fact_sucursal and f.fact_tipo=i.fact_tipo

	open COMPRAS

	Fetch next from COMPRAS into @numero, @sucursal, @tipo, @cliente, @fecha
	while @@FETCH_STATUS = 0
	begin

		declare ITEMS cursor for select fi.item_producto, fi.item_precio, fi.item_cantidad from Item_Factura fi
		where fi.item_tipo=@tipo and fi.item_numero=@numero and fi.item_sucursal =@sucursal

		open ITEMS
		fetch next from ITEMS into @producto, @precio, @cantidad
		While @@FETCH_STATUS = 0
		Begin
			declare @valorProd = select SUM(item_cantidad*item_precio) from Item_Factura where item_producto= @producto)


			if (@valorProd > @precio)

			begin
			PRINT @cliente
			PRINT @fecha 
			PRINT @valorProd 
			PRINT @producto

			fetch next from ITEMS into @producto, @precio, @cantidad

		end

		if (@precio < @valorProd/2)
		rollback transaction
		End
		
		close ITEMS
		deallocate ITEMS
		
		Fetch next from compra into @numero, @sucursal, @tipo, @cliente, @fecha
		End
		
		close COMPRAS
		deallocate COMPRAS
End
go



-- Ejercicio 1

SELECT	clie_codigo,
		COUNT(year(fact_fecha)) cantAniosAlMenosUnaFactMal,
		COUNT(fact_numero) cantFactMalRealizadas

FROM	Cliente, Factura, Item_Factura
WHERE	clie_codigo = fact_cliente
			AND item_tipo = fact_tipo
			AND fact_sucursal = item_sucursal
			AND fact_numero = item_numero
GROUP BY	clie_codigo, fact_total, fact_total_impuestos
HAVING	(fact_total - fact_total_impuestos) > (SUM(item_cantidad*item_precio) + 1)
ORDER BY clie_codigo

