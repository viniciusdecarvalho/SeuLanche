
IF OBJECT_ID('SeuLanche.PedidosSaldo') IS NOT NULL DROP VIEW SeuLanche.PedidosSaldo
go
CREATE VIEW SeuLanche.PedidosSaldo
AS
WITH
CTE_Lanche as (

	select 
		SequencialPedido = P.Sequencial,
		SequencialLanche = PL.Sequencial,
		ItemId = PL.Id,
		Nivel = 1,
		SequencialItem = PL.Sequencial,
		Descricao = L.Nome,
		Valor = LP.Valor
	from SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches PL ON PL.SequencialPedido = P.Sequencial
	JOIN SeuLanche.LanchesPreco LP ON LP.SequencialLanche = PL.SequencialLanche
	JOIN SeuLanche.Lanches L ON L.Sequencial = PL.SequencialLanche	
)
, CTE_LancheIngredientes as (
	
	select 
		SequencialPedido = P.Sequencial,
		SequencialLanche = PL.Sequencial,
		ItemId = PLI.Id,
		Nivel = 2,
		SequencialItem = PLI.Sequencial,
		Descricao = I.Nome,
		Valor = PLI.Valor
	from SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches PL ON PL.SequencialPedido = P.Sequencial
	JOIN SeuLanche.PedidosLanchesItens PLI ON PLI.SequencialPedidosLanches = PL.Sequencial
	JOIN SeuLanche.Ingredientes I ON I.Sequencial = PLI.SequencialIngrediente
)
, CTE_Promocao as (
	
	select 
		PP.SequencialPedido,
		SequencialLanche = NULL,
		ItemId = NULL,
		Nivel = 3,
		SequencialItem = PP.Codigo,
		Descricao = CONCAT('Promoção ', PP.Nome, ' - ', PP.Descricao),
		Valor = -PP.Desconto
	from SeuLanche.PedidosPromocoes PP
	WHERE PP.Desconto > 0
)
, CTE_Saldo as (
	
	select * from CTE_LancheIngredientes
	UNION ALL
	select * from CTE_Promocao
)

select 
	SequencialPedido,
	SequencialLanche,
	ItemId,
	Nivel,
	Ordem = ROW_NUMBER() OVER(
		PARTITION BY
			SequencialPedido
		ORDER BY	
			Nivel, SequencialItem
	),
	Descricao,
	Valor,
	Saldo = SUM(Valor) OVER(
		PARTITION BY
			SequencialPedido
		ORDER BY	
			Nivel, SequencialItem
	)
from CTE_Saldo
