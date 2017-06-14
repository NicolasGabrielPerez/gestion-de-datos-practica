CREATE TRIGGER TR_EJERCICIO_2
ON ITEM_FACTURA
INSTEAD OF INSERT
AS
BEGIN
	declare @item_tipo char(1);
	declare @item_sucursal char(4);
	declare @item_numero char(8);
	declare @item_producto char(8);
	declare @item_cantidad decimal(12,2);
	declare @item_precio decimal(12,2);
	select @item_producto = item_producto, @item_numero = item_numero,
			@item_numero = item_numero, @item_producto = item_producto,
			@item_cantidad = item_cantidad, @item_precio = item_precio
	from inserted;

	declare @familia char(3);
	select	@familia = prod_familia
	from	Producto
	where	prod_codigo = @item_producto

	if exists(	select item_producto 
				from Factura join Item_Factura on (fact_tipo = @item_tipo and fact_sucursal = @item_sucursal and fact_numero = @item_numero)
				where  item_producto not in (select prod_codigo
											 from	Producto
											 where prod_familia = @familia))					
		begin
			raiserror ('La factura posee 2 articulos con la misma familia, no se puede grabar',1,1)
			return;
		end;

	insert into Item_Factura values (@item_tipo, @item_sucursal, @item_numero, @item_producto, @item_cantidad, @item_precio)

end;	
	