using SeuLanche.ModelDto;
using SeuLanche.WebAPI.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeuLanche.WebAPI.Controllers
{
    [Route("api/lanches")]
    public class LanchesController : ApiController
    {
        private PedidosService service = new PedidosService(new SeuLancheContext());

        public async Task<IEnumerable<LancheDto>> Get()
        {
            var lanches = await this.service.Lanches();

            return lanches;
        }
    }
}