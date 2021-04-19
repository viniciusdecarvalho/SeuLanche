
CREATE OR ALTER PROCEDURE SeuLanche.PedidoCriar(@Sequencial INT OUTPUT)
AS
BEGIN
	SET XACT_ABORT ON;
	SET NOCOUNT ON;
	
	declare @pedido table(Sequencial INT)

	INSERT SeuLanche.Pedidos(
			Inicio,
			Situacao
		)
	OUTPUT INSERTED.Sequencial INTO @pedido
	SELECT SYSDATETIME(), Codigo from SeuLanche.PedidosSituacao where Nome = 'Aberto'

	select 
		@Sequencial = Sequencial
	from @pedido
END
GO

CREATE OR ALTER PROCEDURE SeuLanche.PedidoLimpar(@SequencialPedido INT)
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

	DELETE LP
	FROM SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches LP ON LP.SequencialPedido = P.Sequencial
	WHERE P.Situacao = 1
	  AND P.Sequencial = @SequencialPedido

END
