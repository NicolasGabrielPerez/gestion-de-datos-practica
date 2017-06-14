-- Nota: falta d), f), g)

select		year(fact_fecha) as Año, fami_id, count(prod_rubro) "Cantidad de rubros", count(distinct fact_numero) "cantidad de facturas"
from		familia join Producto on (fami_id = prod_familia) join Item_Factura on (prod_codigo = item_producto)
				join Factura on (fact_tipo = item_tipo and fact_sucursal = item_sucursal and fact_numero = item_numero)
--where		prod_codigo = comp_producto 
group by	year(fact_fecha), fami_id
order by	year(fact_fecha), fami_id

-- Punto b) Se puede ver la cantidad vendida total de cada familia de cada año

select		year(fact_fecha), prod_familia, sum(item_cantidad * item_precio) "Cantidad vendida"
from		Producto join Item_Factura on (prod_codigo = item_producto) join Factura on 
				(fact_tipo = item_tipo and fact_sucursal = item_sucursal and fact_numero = item_numero)
group by	year(fact_fecha), prod_familia
order by	year(fact_fecha), sum(item_cantidad * item_precio) desc
