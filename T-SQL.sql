--eje 1
if OBJECT_ID('FN_estadoDelDeposito') IS NOT NULL
DROP function FN_estadoDelDeposito
GO
create function dbo.FN_estadoDelDeposito(@arrticulo CHAR(8) ,@deposito char(2))
returns char(50)
as
begin
DECLARE @Maximo int;
DECLARE @cantidad int;
select @Maximo = s.stoc_stock_maximo from dbo.STOCK s where s.stoc_deposito = @deposito and s.stoc_producto = @arrticulo;
select @cantidad = s.stoc_cantidad from dbo.STOCK s where s.stoc_deposito = @deposito and s.stoc_producto = @arrticulo;
declare @retorno  char(50);
if (@cantidad >= @Maximo) 
begin
	  set @retorno ='DEPOSITO COMPLETO';
	  RETURN @retorno;
	  end
	  Declare @Porcent char(5);
	  set @Porcent = (@cantidad*100/@Maximo);
	  set @retorno = 'OCUPACION DEL DEPOSITO %';
	  return @retorno + @porcent + '%'; 
end;
go

/*
-- eje 2
if OBJECT_ID('fn_Stock_by_fecha') IS NOT NULL
DROP function fn_Stock_by_fecha
go

create function dbo.fn_Stock_by_fecha(@articulo char(8), @fecha smalldatetime)
returns decimal(12,2)
as
begin
declare @total int;
select * from dbo.Producto
return 0;
end;
*/

--eje 3
if OBJECT_ID('sp_fn_gerente_general') is not null
drop procedure sp_fn_gerente_general
go
create procedure dbo.sp_fn_gerente_general

as
begin
declare @cant int;
select @cant=count(*) from dbo.Empleado e where e.empl_jefe is null 
if @cant > 1
	begin
	declare @jefe int;
	select top 1 @jefe = e1.empl_codigo from dbo.Empleado e1 where e1.empl_jefe is null order by e1.empl_ingreso desc, e1.empl_nacimiento asc;
	update dbo.Empleado set empl_jefe = @jefe where empl_jefe is null and empl_codigo <> @jefe;  
	return @cant;
	end;
else 
	begin
	return @cant;
	end;
end
go
--eje 4
/*
Create table dbo.Fact_table
( anio char(4),
mes char(2),
familia char(3),
rubro char(4),
zona char(3),
cliente char(6),
producto char(8),
cantidad decimal(12,2),
monto decimal(12,2)
)
go
Alter table dbo.Fact_table
Add constraint primary key (anio,mes,familia,rubro,zona,cliente,producto) 

if OBJECT_ID('sp_complete_fac_table') is not null
drop procedure dbo.sp_complete_fac_table
go
create procedure dbo.sp_complete_fac_table
as
begin -- hacer todo el insert con el select paja
insert into dbo.fact_table (anio, mes, familia , rubro , zona, cliente, producto, cantidad, monto)
select 
;
end
*/


-- eje 5


-- eje 14

create trigger dbo.salariomaximo
on dbo.Empleado INSTEAD of insert, update
as
begin
declare @empleado int;
declare @salario int
	if EXISTS (select i.empl_salario,  i.empl_codigo from inserted i)
	begin
	create table #salarios  (salario int, jefe int);
	insert into #salarios select sum(empl_salario) as salario, empl_jefe as jefe from Empleado where empl_jefe is not null group by empl_jefe;
	select * from Empleado where empl_codigo; 
end
else
commit TRANSACTION;
return
end; 
go	
