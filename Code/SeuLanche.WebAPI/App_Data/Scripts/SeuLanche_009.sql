
CREATE OR ALTER FUNCTION SeuLanche.Lanche(@nome varchar(50))
RETURNS INT
AS
BEGIN
	RETURN (select sequencial from SeuLanche.Lanches where Nome = @nome)
END
GO

CREATE OR ALTER FUNCTION SeuLanche.Ingrediente(@nome varchar(50))
RETURNS INT
AS
BEGIN
	RETURN (select sequencial from SeuLanche.Ingredientes where Nome = @nome)
END
GO