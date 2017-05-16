//ej1
select c.clie_codigo,c.clie_razon_social from Cliente c where c.clie_limite_credito >= 1000;

//ej2

select pro.prod_codigo, pro.prod_detalle from Producto pro inner join Item_Factura itemfac on pro.prod_codigo = itemfac.item_producto inner join Factura fac on fac.fact_tipo = itemfac.item_tipo and fac.fact_numero =itemfac.item_numero and fac.fact_sucursal = itemfac.item_sucursal

where fac.fact_fecha BETWEEN '20120101' and '20121231'
order by fac.fact_fecha
;

//ej3

select pro.prod_codigo,pro.prod_detalle,st.stoc_cantidad from Producto pro inner join Composicion co on co.comp_producto = pro.prod_codigo inner join STOCK st on st.stoc_producto = co.comp_producto

order by pro.prod_detalle asc;
//no me gusta

//ej4


