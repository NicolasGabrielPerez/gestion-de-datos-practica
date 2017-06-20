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

-- Ejerc 7

select p.prod_codigo,p.prod_detalle,max(i.item_precio) maximo, min(i.item_precio) minimo,
	((max(i.item_precio) - min(i.item_precio))*100/min(i.item_precio))as delta 
	from dbo.Producto p inner join dbo.Item_Factura i on
	p.prod_codigo = i.item_producto
 group by p.prod_codigo,p.prod_detalle

 go

 -- Ejerc 8

 select p.prod_detalle , max(s.stoc_cantidad) as maximo_stock
	from dbo.Producto p inner join dbo.STOCK s on s.stoc_producto = p.prod_codigo
	group by p.prod_detalle, s.stoc_deposito
	having count(s.stoc_deposito) = (select count(*) from dbo.DEPOSITO )

-- Ejerc 9

select e.empl_codigo as empleado, j.empl_codigo as jefe ,j.empl_nombre as nombre_jefe,
	(select count(dep.depo_codigo) from dbo.Departamento d inner join dbo.DEPOSITO dep on 
		dep.depo_zona = d.depa_zona where d.depa_codigo =e.empl_departamento or d.depa_codigo = j.empl_departamento) as cantidad_de_depositos
	from dbo.Empleado e inner join dbo.Empleado j on j.empl_codigo=e.empl_jefe


-- Ejerc 10

select top 10 sum(i.item_cantidad)as cantidad,i.item_producto ,
	(
	select  top 1 fac.fact_cliente from Factura fac inner join dbo.Item_Factura i2 on
	 i2.item_numero=fac.fact_numero and i2.item_sucursal =fac.fact_sucursal and i2.item_tipo=fac.fact_tipo
	 where i2.item_producto=i.item_producto
	 group by i2.item_producto,fac.fact_cliente
	 order by sum(i2.item_cantidad) desc
	)as cliente
	from dbo.Factura f inner join dbo.Item_Factura i on
	 i.item_numero=f.fact_numero and i.item_sucursal =f.fact_sucursal and i.item_tipo=f.fact_tipo
	group by i.item_producto
	order by cantidad desc

select top 10 sum(i.item_cantidad)as cantidad,i.item_producto,(
	select  top 1 fac.fact_cliente from Factura fac inner join dbo.Item_Factura i2 on
	 i2.item_numero=fac.fact_numero and i2.item_sucursal =fac.fact_sucursal and i2.item_tipo=fac.fact_tipo
	 where i2.item_producto=i.item_producto
	 group by i2.item_producto,fac.fact_cliente
	 order by sum(i2.item_cantidad) desc
	) as cliente
from dbo.Factura f inner join dbo.Item_Factura i on
	 i.item_numero=f.fact_numero and i.item_sucursal =f.fact_sucursal and i.item_tipo=f.fact_tipo
	group by i.item_producto
	order by cantidad asc



-- ejerc 11 incompleta
select f.fami_detalle, count(p.prod_codigo)  from dbo.Producto p inner join dbo.Familia f on f.fami_id = p.prod_familia

	
	group by p.prod_familia,f.fami_detalle

select *  from dbo.Producto p inner join dbo.Familia f on f.fami_id = p.prod_familia






