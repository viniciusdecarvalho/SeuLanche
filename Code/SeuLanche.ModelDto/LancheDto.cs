using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuLanche.ModelDto
{
    public class LancheDto
    {
        public int sequencialPedido { get; set; }

        public int SequencialPedidoLanche { get; set; }

        public int Sequencial { get; set; }

        public string Nome { get; set; }

        public ICollection<IngredienteDto> Ingredientes { get; set; }

        public decimal Valor => this.Ingredientes?.Sum(i => i.Valor) ?? decimal.Zero;        

        public override string ToString()
        {
            return this.Nome;
        }

        public void AdicionarIngrediente(LancheDto lanche)
        {

        }

        public void RemoverIngrediente(LancheDto lanche)
        {

        }
    }
}
