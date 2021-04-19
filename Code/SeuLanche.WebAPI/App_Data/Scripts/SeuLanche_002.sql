
CREATE TABLE SeuLanche.PedidosSituacao(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Codigo INT NOT NULL,
	Nome VARCHAR(30) NOT NULL
)

CREATE UNIQUE CLUSTERED INDEX IX_PedidosSituacao_Codigo on SeuLanche.PedidosSituacao(Codigo);
CREATE UNIQUE NONCLUSTERED INDEX IX_PedidosSituacao_Nome on SeuLanche.PedidosSituacao(Nome);

GO
CREATE TABLE SeuLanche.Pedidos(
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial INT IDENTITY NOT NULL,
	Inicio DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	Situacao INT NOT NULL,
		CONSTRAINT FK_Pedidos_Situacao FOREIGN KEY(Situacao) REFERENCES SeuLanche.PedidosSituacao(Codigo),
	Conclusao DATETIME2 NULL
)

CREATE UNIQUE CLUSTERED INDEX IX_Pedidos_Sequencial on SeuLanche.Pedidos(Sequencial);
CREATE NONCLUSTERED INDEX IX_Pedidos_Situacao on SeuLanche.Pedidos(Situacao);
GO

CREATE TABLE SeuLanche.PedidosLanches (
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial INT IDENTITY NOT NULL,
	SequencialPedido INT NOT NULL,
		CONSTRAINT FK_PedidosLanches_Pedido FOREIGN KEY(SequencialPedido) REFERENCES SeuLanche.Pedidos(Sequencial),
	SequencialLanche SMALLINT NOT NULL,
		CONSTRAINT FK_PedidosLanches_SequencialLanche FOREIGN KEY(SequencialLanche) REFERENCES SeuLanche.Lanches(Sequencial)
)

CREATE UNIQUE CLUSTERED INDEX IX_PedidosLanches_Sequencial on SeuLanche.PedidosLanches(Sequencial);

GO

CREATE TABLE SeuLanche.PedidosLanchesItens (
	Id UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	Sequencial INT IDENTITY NOT NULL,
	SequencialPedidosLanches INT NOT NULL,
		CONSTRAINT FK_PedidosItens_Pedido FOREIGN KEY(SequencialPedidosLanches) REFERENCES SeuLanche.PedidosLanches(Sequencial),
	SequencialIngrediente SMALLINT NOT NULL,
		CONSTRAINT FK_PedidosItens_Ingrediente FOREIGN KEY(SequencialIngrediente) REFERENCES SeuLanche.Ingredientes(Sequencial),	
	Valor DECIMAL(13, 2) NOT NULL CHECK(Valor != 0)
)

CREATE UNIQUE CLUSTERED INDEX IX_PedidosLanchesItens_Sequencial on SeuLanche.PedidosLanchesItens(Sequencial);
CREATE NONCLUSTERED INDEX IX_PedidosLanchesItens_SequencialPedidoLanches on SeuLanche.PedidosLanchesItens(SequencialPedidosLanches);
CREATE NONCLUSTERED INDEX IX_PedidosLanchesItens_SequencialIngrediente on SeuLanche.PedidosLanchesItens(SequencialIngrediente);
