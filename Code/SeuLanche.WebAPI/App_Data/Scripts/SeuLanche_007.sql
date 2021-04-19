
CREATE OR ALTER PROCEDURE SeuLanche.PedidoAdicionarLanche(
	@SequencialPedido INT,
	@SequencialLanche INT,
	@SequencialPedidoLanche INT OUTPUT
) 
AS
BEGIN

	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	if object_ID('tempdb..#Pedido') IS NOT NULL DROP TABLE #Pedido
	select *	
	into #Pedido
	from Pedidos P
	where Sequencial = @SequencialPedido

	if not exists(select 1 from #Pedido)
	BEGIN 		
		THROW 60000, 'pedido informado nao existe', 1
	END

	if exists(select 1 from #Pedido where Situacao != 1)
	BEGIN
		THROW 60000, 'pedido encerrado', 1
	END

	if not exists(select 1 from SeuLanche.Lanches where Sequencial = @SequencialLanche and Ativo = 1)
	BEGIN
		THROW 60000, 'lanche informado nao existe ou nao esta ativo', 1
	END
	
	insert SeuLanche.PedidosLanches(
		SequencialPedido, SequencialLanche
	)
	select @SequencialPedido, @SequencialLanche

	SET @SequencialPedidoLanche = SCOPE_IDENTITY()

	INSERT SeuLanche.PedidosLanchesItens(
		SequencialPedidosLanches,
		SequencialIngrediente,
		Valor
	)
	SELECT 
		@SequencialPedidoLanche,
		LI.SequencialIngrediente,
		IV.Valor
	FROM SeuLanche.Lanches L
	JOIN SeuLanche.LanchesIngredientes LI ON LI.SequencialLanche = L.Sequencial	
	JOIN SeuLanche.IngredientesValorVigencia IV ON IV.SequencialIngrediente = LI.SequencialIngrediente and IV.Fim IS NULL
	WHERE L.Sequencial = @SequencialLanche	  

END
GO

CREATE OR ALTER PROCEDURE SeuLanche.PedidoRemoverLanche(
	@SequencialPedido INT,
	@SequencialLanche INT
) 
AS
BEGIN
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	DELETE PLI
	FROM SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches LP ON LP.SequencialPedido = P.Sequencial
	JOIN SeuLanche.PedidosLanchesItens PLI ON PLI.SequencialPedidosLanches = LP.Sequencial
	WHERE P.Situacao = 1
	  AND P.Sequencial = @SequencialPedido
	  AND LP.SequencialLanche = @SequencialLanche

	DELETE LP
	FROM SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches LP ON LP.SequencialPedido = P.Sequencial
	WHERE P.Situacao = 1
	  AND P.Sequencial = @SequencialPedido
	  AND LP.SequencialLanche = @SequencialLanche
END
GO