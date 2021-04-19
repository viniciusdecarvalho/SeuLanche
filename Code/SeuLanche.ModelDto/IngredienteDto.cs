namespace SeuLanche.ModelDto
{
    public class IngredienteDto
    {
        public short Sequencial { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}