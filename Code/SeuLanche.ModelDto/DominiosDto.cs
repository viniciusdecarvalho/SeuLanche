using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuLanche.ModelDto
{
    public class DominiosDto
    {
        public ICollection<LancheDto> Lanches { get; set; } = new List<LancheDto>();

        public ICollection<IngredienteDto> Ingredientes { get; set; } = new List<IngredienteDto>();
    }
}
