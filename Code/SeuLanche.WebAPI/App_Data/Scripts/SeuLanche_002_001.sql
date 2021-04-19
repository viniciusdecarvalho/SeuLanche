SET XACT_ABORT ON;
BEGIN TRAN;

INSERT SeuLanche.PedidosSituacao(
	Codigo, Nome
)
SELECT * FROM (VALUES
	(1, 'Aberto'),
	(2, 'Concluido'),
	(3, 'Desistencia')
) T(Codigo, Nome)

COMMIT;
GO