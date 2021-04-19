
IF OBJECT_ID('SeuLanche.PedidosPromocoes') IS NOT NULL DROP VIEW SeuLanche.PedidosPromocoes
go
CREATE VIEW SeuLanche.PedidosPromocoes
AS
WITH
CTE_Pedido as (

	select 
		p.Sequencial,
		ValorTotal = SUM(PLI.Valor)
	from SeuLanche.Pedidos P
	JOIN SeuLanche.PedidosLanches PL ON PL.SequencialPedido = P.Sequencial
	JOIN SeuLanche.PedidosLanchesItens PLI ON PLI.SequencialPedidosLanches = PL.Sequencial
	GROUP BY
		P.Sequencial
)
, CTE_Promocao as (

	select 
		Codigo,
		Nome,
		Descricao
	FROM SeuLanche.Promocoes P
	WHERE SYSDATETIME() BETWEEN InicioVigencia AND FimVigencia
)

, CTE_Itens AS (
	
	select 
		SequencialPedido,
		SequencialIngrediente,
		Valor
	from SeuLanche.PedidosLanches PL
	JOIN SeuLanche.PedidosLanchesItens PLI ON PLI.SequencialPedidosLanches = PL.Sequencial 
)

select 
	SequencialPedido = P.Sequencial,
	PM.Codigo,
	PM.Nome,
	PM.Descricao,
	Desconto = ValorTotal * 0.1
FROM CTE_Pedido P
CROSS JOIN CTE_Promocao PM
where PM.Codigo = 1
  and exists(select 1 from CTE_Itens where SequencialPedido = P.Sequencial and SequencialIngrediente = 1)
  and not exists(select 1 from CTE_Itens where SequencialPedido = P.Sequencial and SequencialIngrediente = 2)
union all
select 
	SequencialPedido = P.Sequencial,
	PM.Codigo,
	PM.Nome,
	PM.Descricao,
	Desconto = Regra.Valor
FROM CTE_Pedido P
JOIN (
	select 
		SequencialPedido,
		Valor = sum(Valor) / 3
	from CTE_Itens 
	where SequencialIngrediente = 3
	  and Valor > 0
	group by
		SequencialPedido
	having count(1) > 3
) Regra ON Regra.SequencialPedido = P.Sequencial
CROSS JOIN CTE_Promocao PM
where PM.Codigo = 2
union all
select 
	SequencialPedido = P.Sequencial,
	PM.Codigo,
	PM.Nome,
	PM.Descricao,
	Desconto = Regra.Valor
FROM CTE_Pedido P
JOIN (
	select 
		SequencialPedido,
		Valor = sum(Valor) / 3
	from CTE_Itens
	where SequencialIngrediente = 5
	  and Valor > 0
	group by
		SequencialPedido
	having count(1) > 3
) Regra ON Regra.SequencialPedido = P.Sequencial
CROSS JOIN CTE_Promocao PM
where PM.Codigo = 3

