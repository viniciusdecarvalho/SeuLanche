using SeuLanche.ModelDto;
using SeuLanche.WebAPI.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeuLanche.WebAPI.Controllers
{
    [Route("api/ingredientes")]
    public class IngredientesController : ApiController
    {
        private PedidosService service = new PedidosService(new SeuLancheContext());

        public async Task<IEnumerable<IngredienteDto>> Get()
        {
            var ingredientes = await this.service.Ingredientes();

            return ingredientes;
        }
    }
}