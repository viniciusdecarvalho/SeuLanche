
SET XACT_ABORT ON;

BEGIN TRAN

declare @SequencialPedido INT;
declare @SequencialPedidoLanche INT;

exec SeuLanche.PedidoCriar @SequencialPedido OUTPUT

declare @SequencialLancheXBacon INT = SeuLanche.Lanche('X-Bacon');
exec SeuLanche.PedidoAdicionarLanche @SequencialPedido, @SequencialLancheXBacon, @SequencialPedidoLanche OUTPUT

declare @SequencialAlface INT = SeuLanche.Ingrediente('Alface')
exec SeuLanche.PedidoAlterarLanche @SequencialPedidoLanche, @SequencialAlface, 2

declare @SequencialCarne INT = SeuLanche.Ingrediente('Hambúrguer de carne')
exec SeuLanche.PedidoAdicionarIngrediente @SequencialPedidoLanche, @SequencialCarne
exec SeuLanche.PedidoDiminuirIngrediente @SequencialPedidoLanche, @SequencialCarne
exec SeuLanche.PedidoDiminuirIngrediente @SequencialPedidoLanche, @SequencialCarne
--exec SeuLanche.PedidoDiminuirIngrediente @SequencialPedidoLanche, @SequencialCarne
--exec SeuLanche.PedidoDiminuirIngrediente @SequencialPedidoLanche, @SequencialCarne

SELECT * FROM SeuLanche.PedidosSaldo
where SequencialPedido = @SequencialPedido

ROLLBACK
--COMMIT

select @@VERSION

select * from SeuLanche.PedidosSaldo
select * from SeuLanche.PedidosPromocoes
where SequencialPedido = 87

SELECT 
    [Project1].[SequencialPedido] AS [SequencialPedido], 
    [Project1].[Descricao] AS [Descricao], 
    [Project1].[Desconto] AS [Desconto]
    FROM ( SELECT 
        [Extent1].[SequencialPedido] AS [SequencialPedido], 
        [Extent1].[Descricao] AS [Descricao], 
        [Extent1].[Desconto] AS [Desconto]
        FROM (SELECT 
    [PedidosPromocoes].[SequencialPedido] AS [SequencialPedido], 
    [PedidosPromocoes].[Codigo] AS [Codigo], 
    [PedidosPromocoes].[Nome] AS [Nome], 
    [PedidosPromocoes].[Descricao] AS [Descricao], 
    [PedidosPromocoes].[Desconto] AS [Desconto]
    FROM [SeuLanche].[PedidosPromocoes] AS [PedidosPromocoes]) AS [Extent1]
        WHERE [Extent1].[SequencialPedido] = 87
    )  AS [Project1]
    ORDER BY [Project1].[Desconto] DESC