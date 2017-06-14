--1

select c.clie_codigo,c.clie_razon_social 
from cliente c 
where c.clie_limite_credito > 1000
order by c.clie_codigo;


--2
select itemf.item_producto,p.prod_detalle, count(itemf.item_cantidad)
from Item_Factura itemf 
inner join Producto p on itemf.item_producto = p.prod_codigo
inner join Factura fac on itemf.item_numero = fac.fact_numero and YEAR(fac.fact_fecha)=2012
group by itemf.item_producto,p.prod_detalle 
order by count(itemf.item_cantidad);

--3
select c.prod_codigo,c.prod_detalle, sum(stock.stoc_cantidad) from Producto c
inner join STOCK stock on stock.stoc_producto = c.prod_codigo
group by c.prod_codigo,c.prod_detalle


--4
select p.prod_codigo, p.prod_detalle, count(produ.prod_codigo)
 from Producto p
 inner join Composicion comp on p.prod_codigo = comp.comp_producto
left join Producto produ on comp.comp_componente = produ.prod_codigo
group by p.prod_codigo, p.prod_detalle
having (select AVG(stoc.stoc_cantidad) from STOCK stoc 
where stoc.stoc_producto = p.prod_codigo
) > 100


--5
select pro.prod_codigo, pro.prod_detalle, sum(f.item_cantidad) from Item_Factura f
inner join Producto pro on f.item_producto = pro.prod_codigo
inner join Factura fac on fac.fact_numero = f.item_numero and fac.fact_tipo = f.item_tipo and fac.fact_sucursal = f.item_sucursal 
where YEAR(fac.fact_fecha) = 2012
group by pro.prod_codigo, pro.prod_detalle
having (select sum(f2.item_cantidad) from Item_Factura f2
inner join Producto pro2 on f2.item_producto = pro2.prod_codigo and pro.prod_codigo=pro2.prod_codigo
inner join Factura fac2 on fac2.fact_numero = f2.item_numero and fac2.fact_tipo = f2.item_tipo and fac2.fact_sucursal = f2.item_sucursal 
where YEAR(fac2.fact_fecha) = 2011) < sum(f.item_cantidad);

--6
select r.rubr_detalle, r.rubr_id, count(p.prod_codigo), sum(s.stoc_cantidad) from Producto p
inner join Rubro r on p.prod_rubro = r.rubr_id
inner join STOCK s on p.prod_codigo = s.stoc_producto
group by r.rubr_detalle, r.rubr_id
having  sum(s.stoc_cantidad) > (select p2.stoc_cantidad from STOCK p2
where p2.stoc_producto = '00000000' and p2.stoc_deposito = '00' )

--7
select p.prod_codigo, p.prod_detalle, max(ISNULL(f.item_precio,p.prod_precio)), min(ISNULL(f.item_precio,p.prod_precio)),  ( (max(ISNULL(f.item_precio,p.prod_precio)) - min(ISNULL(f.item_precio,p.prod_precio)))/max(ISNULL(f.item_precio,p.prod_precio)) )*100 
from Producto p
left join Item_Factura f on f.item_producto = p.prod_codigo
where  p.prod_precio <> 0 and exists(select 1 from STOCK s
where p.prod_codigo = s.stoc_producto and s.stoc_cantidad> 0 ) 
group by p.prod_codigo, p.prod_detalle


--8
select p.prod_codigo, max(s.stoc_cantidad),count(s.stoc_deposito)  from Producto p
inner join STOCK s on p.prod_codigo = s.stoc_producto
group by p.prod_codigo
having count(s.stoc_deposito) = (select count(1) from DEPOSITO)

--9
--select j.empl_codigo,  from Empleado j
--left join Empleado e on  








