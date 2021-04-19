using SeuLanche.ModelDto;
using SeuLanche.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeuLanche.WebAPI.Controllers
{
    public class PedidosController : ApiController
    {
        private PedidosService service = new PedidosService(new SeuLancheContext());

        [Route("api/pedidos/{sequencialPedido}/lanche/{sequencialLanche}")]
        [HttpPost]
        public async Task<HttpResponseMessage> AdicionarLanche(int sequencialPedido, int sequencialLanche)
        {
            try
            {
                int sequencialPedidoLanche = await this.service.AdicionarLanche(sequencialPedido, sequencialLanche);

                var lanche = this.service.Lanche(sequencialPedidoLanche);

                return Request.CreateResponse(HttpStatusCode.OK, lanche);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }

        }

        [Route("api/pedidos/{sequencialPedidoLanche}/ingrediente/{sequencialIngrediente}")]
        [HttpPost]
        public async Task<HttpResponseMessage> AdicionarIngrediente(int sequencialPedidoLanche, int sequencialIngrediente)
        {
            try
            { 
                await this.service.AdicionarIngrediente(sequencialPedidoLanche, sequencialIngrediente);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

        [Route("api/pedidos/{sequencialPedidoLanche}/ingrediente/{sequencialIngrediente}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> RemoverIngrediente(int sequencialPedidoLanche, int sequencialIngrediente)
        {
            try
            { 
                await this.service.RemoverIngrediente(sequencialPedidoLanche, sequencialIngrediente);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

        [Route("api/pedidos/{sequencialPedido}/encerrar")]
        [HttpPost]
        public async Task<HttpResponseMessage> AdicionarLancheIngrediente(int sequencialPedido)
        {
            try
            { 
                await this.service.AdicionarLancheIngrediente(sequencialPedido);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

        [Route("api/pedidos/{sequencialPedido}/lanche/{sequencialLanche}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> RemoverLanche(int sequencialPedido, int sequencialLanche)
        {
            try
            { 
                await this.service.RemoverLanche(sequencialPedido, sequencialLanche);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

        [Route("api/pedidos/{sequencialPedido}/promocoes")]
        [HttpGet]
        public async Task<HttpResponseMessage> Promocoes(int sequencialPedido)
        {
            try
            {           
                var promocoes = await this.service.Promocoes(sequencialPedido);

                return Request.CreateResponse(HttpStatusCode.OK, promocoes);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }
    }
}