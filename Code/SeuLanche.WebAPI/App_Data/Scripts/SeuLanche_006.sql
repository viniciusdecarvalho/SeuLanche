
CREATE OR ALTER PROCEDURE SeuLanche.PedidoEncerrar(
	@SequencialPedido INT, 
	@FoiConcluido BIT = 1
)
AS
BEGIN
	SET XACT_ABORT ON;
	SET NOCOUNT ON;
	
	UPDATE P SET
		Conclusao = GETDATE(),
		Situacao = IIF(@FoiConcluido = 0, 3, 2)
	FROM SeuLanche.Pedidos P
	WHERE Sequencial = @SequencialPedido
END
GO
