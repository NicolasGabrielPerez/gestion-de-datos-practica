CREATE TRIGGER ej2 ON dbo.Factura FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @factura AS TABLE (tipo AS char(1), sucursal AS char(4), numero AS char(8), cliente AS char(6));
	DECLARE @cliente AS char(6), @monto AS numeric(12,2), @montoMax AS decimal(12,2), @puedeFacturar AS binary = 0;
	INSERT @factura SELECT TOP 1 fact_tipo, fact_sucursal, fact_numero, fact_cliente FROM inserted ORDER BY fact_fecha DESC;
	SET @cliente = (SELECT cliente FROM @factura);
	SET @monto = (SELECT TOP 1 fact_total FROM inserted WHERE fact_cliente = @cliente ORDER BY fact_fecha DESC);
	SET @montoMax = (SELECT clie_limite_credito FROM Cliente WHERE clie_codigo = @cliente);
	IF (@montoMax < @monto)
		SET @puedeFacturar = 1;
	ELSE
	BEGIN	
		DECLARE @sumaMontos AS numeric(12,2);
		SET @sumaMontos = (SELECT SUM(fact_total) FROM inserted 
			WHERE fact_cliente = @cliente AND MONTH(fact_fecha) = (SELECT MONTH(GETDATE())));
		IF(@sumaMontos > @montoMax)
			SET @puedeFacturar = 1;
	END
	IF (@puedeFacturar = 1)
	BEGIN
		DELETE FROM Factura WHERE fact_tipo = (SELECT tipo FROM @factura) AND fact_sucursal = (SELECT sucursal FROM @factura) 
		AND fact_numero = (SELECT numero FROM @factura) AND fact_cliente = @cliente AND fact_total = @monto;
		PRINT 'No puede generar esta factura';
	END
END