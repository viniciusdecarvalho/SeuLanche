using SeuLanche.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeuLanche.UI.Desktop
{
    public interface IPedidoService
    {
        Task EncerrarPedido(PedidoController pedido);

        Task IncluirIngrediente(PedidoController pedido, LancheDto lanche, IngredienteDto ingrediente);

        Task<LancheDto> IncluirLanche(PedidoController pedido, LancheDto lanche);

        Task<IEnumerable<IngredienteDto>> Ingredientes();

        Task<IEnumerable<LancheDto>> Lanches();

        Task<IEnumerable<PromocaoDto>> Promocoes(PedidoController pedido);

        Task RemoverIngrediente(PedidoController pedido, LancheDto lanche, IngredienteDto ingrediente);

        Task RemoverLanche(PedidoController pedido, LancheDto lanche);
    }
}
