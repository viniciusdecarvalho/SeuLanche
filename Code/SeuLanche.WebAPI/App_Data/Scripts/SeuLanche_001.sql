
CREATE TABLE SeuLanche.Ingredientes(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial SMALLINT IDENTITY NOT NULL,
	Nome VARCHAR(100) NOT NULL
)

CREATE UNIQUE CLUSTERED INDEX IX_Ingredientes_Sequencial on SeuLanche.Ingredientes(Sequencial);
CREATE UNIQUE NONCLUSTERED INDEX IX_Ingredientes_Nome on SeuLanche.Ingredientes(Nome);
GO

CREATE TABLE SeuLanche.IngredientesValor(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial INT IDENTITY NOT NULL,
	SequencialIngrediente SMALLINT NOT NULL,
	InicioVigencia DATETIME2 NOT NULL,
	Valor DECIMAL(5,2) NOT NULL CHECK(Valor > 0)
)

CREATE UNIQUE CLUSTERED INDEX IX_Lanches_Sequencial on SeuLanche.IngredientesValor(Sequencial);
CREATE UNIQUE NONCLUSTERED INDEX IX_Lanches_SequencialIngrediente on SeuLanche.IngredientesValor(SequencialIngrediente, InicioVigencia);
GO

CREATE OR ALTER VIEW SeuLanche.IngredientesValorVigencia AS
select 
	SequencialIngrediente,
	Valor,
	Inicio = InicioVigencia,
	Fim = LEAD(InicioVigencia) OVER(PARTITION BY SequencialIngrediente ORDER BY InicioVigencia)	
from SeuLanche.IngredientesValor
GO

CREATE TABLE SeuLanche.Lanches(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial SMALLINT IDENTITY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Ativo BIT NOT NULL DEFAULT 1
)

CREATE UNIQUE CLUSTERED INDEX IX_Lanches_Sequencial on SeuLanche.Lanches(Sequencial);
CREATE UNIQUE NONCLUSTERED INDEX IX_Lanches_Nome on SeuLanche.Lanches(Nome);
GO

CREATE TABLE SeuLanche.LanchesIngredientes(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial INT IDENTITY NOT NULL,
	SequencialLanche SMALLINT NOT NULL,
	SequencialIngrediente SMALLINT NOT NULL,
	Quantidade SMALLINT NOT NULL CHECK(Quantidade > 0)
)

CREATE UNIQUE CLUSTERED INDEX IX_LanchesIngredientes_Sequencial on SeuLanche.LanchesIngredientes(Sequencial);
CREATE UNIQUE NONCLUSTERED INDEX IX_LanchesIngredientes_SequencialLancheIngrediente on SeuLanche.LanchesIngredientes(SequencialLanche, SequencialIngrediente);
CREATE NONCLUSTERED INDEX IX_LanchesIngredientes_SequencialIngrediente on SeuLanche.LanchesIngredientes(SequencialIngrediente);
GO

CREATE OR ALTER VIEW SeuLanche.IngredientesLanche AS
select
	LI.SequencialLanche,
	LI.SequencialIngrediente,
    I.Nome,
    IVV.Valor
from SeuLanche.Lanches L
join SeuLanche.LanchesIngredientes LI on LI.SequencialLanche = L.Sequencial
join SeuLanche.IngredientesValorVigencia IVV on IVV.SequencialIngrediente = LI.SequencialIngrediente and IVV.Fim is null
join SeuLanche.Ingredientes I on I.Sequencial = IVV.SequencialIngrediente
GO

CREATE OR ALTER VIEW SeuLanche.LanchesPreco
AS
select 
	SequencialLanche = L.Sequencial,
	Valor = sum(IVV.Valor)
from SeuLanche.Lanches L
join SeuLanche.LanchesIngredientes LI ON LI.SequencialLanche = L.Sequencial
join SeuLanche.IngredientesValorVigencia IVV ON IVV.SequencialIngrediente = LI.SequencialIngrediente and IVV.Fim IS NULL
group by
	L.Sequencial
	
GO

CREATE TABLE SeuLanche.Promocoes(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Codigo INT NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(8000) NOT NULL,
	InicioVigencia DATETIME2 NOT NULL 
		CHECK(InicioVigencia IS NOT NULL),
	FimVigencia DATETIME2 NOT NULL 
		CHECK(FimVigencia >= SYSDATETIME()),
		CHECK(FimVigencia > InicioVigencia),
	Ativo BIT DEFAULT 1
)

CREATE UNIQUE CLUSTERED INDEX IX_Promocoes_Codigo on SeuLanche.Promocoes(Codigo);
CREATE NONCLUSTERED INDEX IX_Promocoes_Vigencia on SeuLanche.Promocoes(InicioVigencia, FimVigencia);
