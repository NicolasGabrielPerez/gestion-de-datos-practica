-- ejercicio 1
select top 12 p.prod_codigo as producto ,CASE
when sum(i.item_cantidad) > SUM(iv.item_cantidad) then 'MAS VENTAS'
when sum(i.item_cantidad) = SUM(iv.item_cantidad) then 'empatados'
when sum(i.item_cantidad) < SUM(iv.item_cantidad) then 'MENOS VENTAS' 
end

as comparacion_anio_ant  ,e.enva_detalle as envase from Producto p 
		inner join Envases e on e.enva_codigo = p.prod_envase 
		inner join Item_Factura i on i.item_producto = p.prod_codigo
		inner join Factura f on i.item_sucursal = f.fact_sucursal and f.fact_numero = i.item_numero and f.fact_tipo = i.item_tipo
		inner join Item_Factura iv on iv.item_producto = p.prod_codigo
		inner join Factura fv on iv.item_sucursal = fv.fact_sucursal and fv.fact_numero = iv.item_numero and fv.fact_tipo = iv.item_tipo
		where YEAR(getdate()) = YEAR(f.fact_fecha) and YEAR(getdate())-1 = YEAR(fv.fact_fecha)
		group by i.item_cantidad, p.prod_codigo,e.enva_detalle,p.prod_detalle
		order by comparacion_anio_ant desc,p.prod_detalle desc

UNION

select top 12 p2.prod_codigo as producto , CASE
when sum(i2.item_cantidad) > SUM(iv2.item_cantidad) then 'MAS VENTAS'
when sum(i2.item_cantidad) = SUM(iv2.item_cantidad) then 'empatados'
when sum(i2.item_cantidad) < SUM(iv2.item_cantidad) then 'MENOS VENTAS' 
end

as comparacion_anio_ant ,e2.enva_detalle as envase from Producto p2 
		inner join Envases e2 on e2.enva_codigo = p2.prod_envase 
		inner join Item_Factura i2 on i2.item_producto = p2.prod_codigo
		inner join Factura f2 on i2.item_sucursal = f2.fact_sucursal and f2.fact_numero = i2.item_numero and f2.fact_tipo = i2.item_tipo
		inner join Item_Factura iv2 on iv2.item_producto = p2.prod_codigo
		inner join Factura fv2 on iv2.item_sucursal = fv2.fact_sucursal and fv2.fact_numero = iv2.item_numero and fv2.fact_tipo = iv2.item_tipo
		where YEAR(getdate()) = YEAR(f2.fact_fecha) and YEAR(getdate())-1 = YEAR(fv2.fact_fecha)
		group by i2.item_cantidad, p2.prod_codigo,e2.enva_detalle,p2.prod_detalle
		order by comparacion_anio_ant asc ,p2.prod_detalle desc

;



-- ejercicio 2

create trigger dbo.insertarEmpleado
on Empleado INSTEAD OF
insert
as
begin
if ((select count(*) from inserted) = 1) 
	declare @depto int
	select @depto = i.empl_departamento from inserted i
	if ((select COUNT(*) from Empleado e where e.empl_departamento = @depto) >60)
		
end
go

create trigger dbo.updateEmpleado
on Empleado INSTEAD OF
update
as
begin
if ((select count(*) from inserted) = 1) 
	declare @depto1 int
	select @depto1 = i.empl_departamento from inserted i
	if ((select COUNT(*) from Empleado e where e.empl_departamento = @depto1) >60)
		
end