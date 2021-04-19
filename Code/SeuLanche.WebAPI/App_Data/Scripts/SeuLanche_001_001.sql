SET XACT_ABORT ON;
BEGIN TRAN;

IF OBJECT_ID('TEMPDB..#Ingredientes') IS NOT NULL DROP TABLE #Ingredientes
SELECT * 
INTO #Ingredientes
FROM (VALUES
	('Alface', 0.40),
	('Bacon', 2.00),
	('Hambúrguer de carne', 3.00),
	('Ovo', 0.80),
	('Queijo', 1.50)
)T(Nome, Valor)

INSERT SeuLanche.Ingredientes(
	Nome
)
select Nome from #Ingredientes

INSERT SeuLanche.IngredientesValor(
	SequencialIngrediente,
	InicioVigencia,
	Valor
)
select 
	SequencialIngrediente = I.Sequencial,
	InicioVigencia = GETDATE(),
	Valor = V.Valor * 1.60 
from SeuLanche.Ingredientes I
JOIN #Ingredientes V ON V.Nome = I.Nome


INSERT SeuLanche.Lanches(
	Nome
)
SELECT * FROM (VALUES
	('X-Bacon'),
	('X-Burger'),
	('X-Egg'),
	('X-Egg Bacon')
) T(Nome)

INSERT SeuLanche.LanchesIngredientes(
	SequencialLanche,
	SequencialIngrediente,
	Quantidade
)
SELECT 
	L.Sequencial,
	i.Sequencial,
	1
FROM SeuLanche.Lanches L
CROSS JOIN SeuLanche.Ingredientes I
WHERE L.Nome = 'X-Bacon'
  AND I.Nome IN('Bacon', 'Hambúrguer de carne', 'Queijo')
UNION ALL
SELECT 
	L.Sequencial,
	i.Sequencial,
	1
FROM SeuLanche.Lanches L
CROSS JOIN SeuLanche.Ingredientes I
WHERE L.Nome = 'X-Burger'
  AND I.Nome IN('Hambúrguer de carne', 'Queijo')
UNION ALL
SELECT 
	L.Sequencial,
	i.Sequencial,
	1
FROM SeuLanche.Lanches L
CROSS JOIN SeuLanche.Ingredientes I
WHERE L.Nome = 'X-Egg'
  AND I.Nome IN('Ovo', 'Hambúrguer de carne', 'Queijo')
UNION ALL
SELECT 
	L.Sequencial,
	i.Sequencial,
	1
FROM SeuLanche.Lanches L
CROSS JOIN SeuLanche.Ingredientes I
WHERE L.Nome = 'X-Egg Bacon'
  AND I.Nome IN('Ovo', 'Bacon', 'Hambúrguer de carne', 'Queijo')

INSERT SeuLanche.Promocoes(
	Codigo, Nome, Descricao, InicioVigencia, FimVigencia
)
SELECT 
	Codigo, Nome, Descricao, GETDATE(), DATEADD(MONTH, 1, GETDATE())
FROM (VALUES
	(1, 'Light', 'Se o lanche tem alface e não tem bacon, ganha 10% de desconto.'),
	(2, 'Muita carne', 'A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...'),
	(3, 'Muito queijo', 'A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...')
) T(Codigo, Nome, Descricao)

COMMIT;