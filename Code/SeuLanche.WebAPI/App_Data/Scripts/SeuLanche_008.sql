
CREATE OR ALTER PROCEDURE SeuLanche.PedidoAlterarLanche(
	@SequencialPedidoLanche INT,
	@SequencialIngrediente INT,
	@Quantidade INT	
) 
AS
BEGIN

	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	if object_ID('tempdb..#Pedido') IS NOT NULL DROP TABLE #Pedido
	select 
		P.*
	into #Pedido
	from SeuLanche.Pedidos P
	join SeuLanche.PedidosLanches PL ON PL.SequencialPedido = P.Sequencial
	where PL.Sequencial = @SequencialPedidoLanche

	if not exists(select 1 from #Pedido)
	BEGIN 		
		THROW 60000, 'pedido informado nao existe', 1
	END

	if exists(select 1 from #Pedido where Situacao != 1)
	BEGIN
		THROW 60000, 'pedido encerrado', 1
	END

	declare @Valor decimal(13, 2) = (
		select Valor 
		from SeuLanche.IngredientesValorVigencia V
		where V.SequencialIngrediente = @SequencialIngrediente
		  and Fim IS NULL
	)

	if @Valor IS NULL
	BEGIN 		
		THROW 60000, 'ingrediente informado nao existe', 1
	END

	declare @ValorIncremento decimal(5,2) = @Valor * @Quantidade
	
	if exists(
		select 1 
		from SeuLanche.PedidosLanchesItens PLI
		where PLI.SequencialPedidosLanches = @SequencialPedidoLanche
		  and PLI.SequencialIngrediente = @SequencialIngrediente
		group by
			SequencialPedidosLanches,
			SequencialIngrediente
		having sum(PLI.Valor) + @ValorIncremento < 0
	)
	BEGIN 		
		THROW 60000, 'saldo do ingrediente nao pode ficar negativo', 1
	END

	INSERT SeuLanche.PedidosLanchesItens(
		SequencialPedidosLanches, SequencialIngrediente, Valor)  
	SELECT 
		@SequencialPedidoLanche, @SequencialIngrediente, @ValorIncremento	
END
GO

CREATE OR ALTER PROCEDURE SeuLanche.PedidoAdicionarIngrediente(
	@SequencialPedidoLanche INT,
	@SequencialIngrediente INT
) 
AS
BEGIN	
	exec SeuLanche.PedidoAlterarLanche @SequencialPedidoLanche, @SequencialIngrediente, 1
END
GO

CREATE OR ALTER PROCEDURE SeuLanche.PedidoDiminuirIngrediente(
	@SequencialPedidoLanche INT,
	@SequencialIngrediente INT
) 
AS
BEGIN	
	exec SeuLanche.PedidoAlterarLanche @SequencialPedidoLanche, @SequencialIngrediente, -1
END
GO