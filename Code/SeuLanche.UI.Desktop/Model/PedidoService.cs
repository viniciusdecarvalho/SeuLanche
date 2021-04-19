using Newtonsoft.Json;
using SeuLanche.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeuLanche.UI.Desktop
{
    internal class PedidoService : IPedidoService
    {
        private readonly HttpClient client;

        public PedidoService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<LancheDto>> Lanches()
        {
            var request = await client.GetAsync($"lanches");
            request.EnsureSuccessStatusCode();

            var content = await request.Content.ReadAsStringAsync();

            var lanches = JsonConvert.DeserializeObject<IEnumerable<LancheDto>>(content);

            return lanches;
        }

        public async Task<IEnumerable<IngredienteDto>> Ingredientes()
        {
            var request = await client.GetAsync($"ingredientes");
            request.EnsureSuccessStatusCode();

            var content = await request.Content.ReadAsStringAsync();

            var lanches = JsonConvert.DeserializeObject<IEnumerable<IngredienteDto>>(content);

            return lanches;
        }

        public async Task<LancheDto> IncluirLanche(PedidoController pedido, LancheDto lanche)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            if (lanche is null)
            {
                throw new ArgumentNullException(nameof(lanche));
            }

            var request = await client.PostAsync($"pedidos/{pedido.Sequencial}/lanche/{lanche.Sequencial}", new StringContent(string.Empty));
            request.EnsureSuccessStatusCode();

            var contentResult = await request.Content.ReadAsStringAsync();

            var lacheAlterado = JsonConvert.DeserializeObject<LancheDto>(contentResult);

            return lacheAlterado;
        }

        public async Task IncluirIngrediente(PedidoController pedido, LancheDto lanche, IngredienteDto ingrediente)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            if (lanche is null)
            {
                throw new ArgumentNullException(nameof(lanche));
            }

            if (ingrediente is null)
            {
                throw new ArgumentNullException(nameof(ingrediente));
            }

            var request = await client.PostAsync($"pedidos/{lanche.SequencialPedidoLanche}/ingrediente/{ingrediente.Sequencial}", new StringContent(string.Empty));
            request.EnsureSuccessStatusCode();
        }

        public async Task RemoverLanche(PedidoController pedido, LancheDto lanche)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            if (lanche is null)
            {
                throw new ArgumentNullException(nameof(lanche));
            }

            var request = await client.DeleteAsync($"pedidos/{pedido.Sequencial}/lanche/{lanche.Sequencial}");
            request.EnsureSuccessStatusCode();
        }

        public async Task RemoverIngrediente(PedidoController pedido, LancheDto lanche, IngredienteDto ingrediente)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            if (lanche is null)
            {
                throw new ArgumentNullException(nameof(lanche));
            }

            if (ingrediente is null)
            {
                throw new ArgumentNullException(nameof(ingrediente));
            }

            var request = await client.DeleteAsync($"pedidos/{lanche.SequencialPedidoLanche}/ingrediente/{ingrediente.Sequencial}");
            request.EnsureSuccessStatusCode();
        }

        public async Task EncerrarPedido(PedidoController pedido)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            var request = await client.PostAsync($"pedidos/{pedido.Sequencial}/encerrar", null);
            request.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PromocaoDto>> Promocoes(PedidoController pedido)
        {
            if (pedido is null)
            {
                throw new ArgumentNullException(nameof(pedido));
            }

            var request = await client.GetAsync($"pedidos/{pedido.Sequencial}/promocoes");
            request.EnsureSuccessStatusCode();

            var content = await request.Content.ReadAsStringAsync();

            var promocoes = JsonConvert.DeserializeObject<IEnumerable<PromocaoDto>>(content);

            return promocoes;
        }
    }
}
