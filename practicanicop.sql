select d.depo_detalle, r.rubr_detalle,
	(select sum(itef.item_cantidad) as cant from dbo.Item_Factura itef where itef.item_producto=p.prod_codigo 
group by itef.item_cantidad order by cant
)
from dbo.DEPOSITO d inner join
 dbo.STOCK s on s.stoc_deposito=d.depo_codigo
 inner join dbo.Producto p on p.prod_codigo=s.stoc_producto
  inner join dbo.Rubro r on p.prod_rubro=r.rubr_id
		



-- ej 2

create table dbo.Candidato
(candidato_id int primary key not nul,
montoVendido money	null)
go 
create procedure dbo.sp_bono_anual
declare @codempleado int
declare @total int
set @total = (select sum(f.fact_total) as monto from dbo.Factura f where Year(f.fact_fecha) = year(SYSDATETIME())and @codempleado
=f.fact_cliente and f.fact_total is not null group by f.fact_total )
IF(@total > 1.3*
(select sum(f2.fact_total) as monto2 from dbo.Factura f2  where @codempleado = f2.fact_cliente and Year(f2.fact_fecha) = (year(SYSDATETIME())-1)and f2.fact_total is not null
 group by f2.fact_total))
 begin
 insert into dbo.Candidato (candidato_id,montoVendido)
 values (@codempleado,@total)
 end
