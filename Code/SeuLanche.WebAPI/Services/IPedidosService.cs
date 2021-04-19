using SeuLanche.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeuLanche.WebAPI.Services
{
    public interface IPedidosService
    {
        Task AdicionarIngrediente(int sequencialPedidoLanche, int sequencialIngrediente);

        Task<int> AdicionarLanche(int sequencialPedido, int sequencialLanche);

        Task AdicionarLancheIngrediente(int sequencialPedido);

        LancheDto Lanche(int sequencialPedidoLanche);

        Task<IEnumerable<PromocaoDto>> Promocoes(int sequencialPedido);

        Task RemoverIngrediente(int sequencialPedidoLanche, int sequencialIngrediente);

        Task RemoverLanche(int sequencialPedido, int sequencialLanche);
    }
}