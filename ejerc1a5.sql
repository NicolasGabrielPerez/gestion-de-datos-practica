--Ejerc 1
select clie_codigo, clie_razon_social from dbo.Cliente
where clie_limite_credito >= 1000
order by clie_codigo desc
go

--Ejerc 2
select prod_codigo as Codigo, prod_detalle as Detalle from dbo.Producto, dbo.Item_Factura i, dbo.Factura f
where year(f.fact_fecha)=2012 
and f.fact_tipo=i.item_tipo 
and f.fact_sucursal=i.item_sucursal 
and f.fact_numero=i.item_numero 
and i.item_producto = prod_codigo
order by i.item_cantidad asc
go

--Ejerc 3
select prod_codigo as Codigo, prod_detalle as Detalle, stoc_cantidad as Stock 
from dbo.Producto, dbo.STOCK 
where stoc_producto = prod_codigo
order by prod_detalle asc
go

--Ejerc 4
select prod_codigo as Codigo, prod_detalle as Detalle, sum(isnull(comp_cantidad,0)) as CantidadComp 
from dbo.Producto left join dbo.Composicion on prod_codigo = comp_producto
group by prod_codigo, prod_detalle
having (select avg(stoc_cantidad) from dbo.STOCK where
		prod_codigo = stoc_producto) > 100
order by 3 desc
go

--Ejerc 5
select prod_codigo as Codigo, prod_detalle as Detalle, sum(i.item_cantidad) as Egresos from dbo.Producto p, dbo.Item_Factura i, dbo.Factura f
where year(f.fact_fecha)=2012 
and f.fact_tipo=i.item_tipo 
and f.fact_sucursal=i.item_sucursal 
and f.fact_numero=i.item_numero 
and prod_codigo=i.item_producto
group by prod_codigo, prod_detalle
having (select sum(item_cantidad)from dbo.Factura, dbo.Item_Factura where
 year(fact_fecha)= 2011
and fact_tipo=item_tipo 
and fact_sucursal=item_sucursal 
and fact_numero=item_numero 
and prod_codigo=item_producto
) < sum(i.item_cantidad)
go

