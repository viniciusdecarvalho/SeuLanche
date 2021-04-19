using SeuLanche.ModelDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuLanche.UI.Desktop
{
    public class PedidoController
    {
        private readonly IPedidoService pedidoService;

        public event EventHandler<PedidoController> OnChangeHandler = (srv, evt) => { };

        public int Sequencial { get; set; }

        public BindingList<LancheDto> Lanches { get; } = new BindingList<LancheDto>();

        public BindingList<IngredienteDto> Ingredientes { get; } = new BindingList<IngredienteDto>();

        public BindingList<PromocaoDto> Promocoes { get; } = new BindingList<PromocaoDto>();

        public DominiosDto Dominios { get; } = new DominiosDto();

        public decimal Saldo =>
            this.Lanches.SelectMany(l => l.Ingredientes).Sum(i => i.Valor) + this.Promocoes.Sum(p => p.Valor);       

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;

            this.Lanches.ListChanged += async (sender, e) =>
            {
                if (e.ListChangedType == ListChangedType.ItemAdded ||
                    e.ListChangedType == ListChangedType.ItemDeleted ||
                    e.ListChangedType == ListChangedType.Reset)
                {
                    var promocoes = await this.pedidoService.Promocoes(this);

                    this.Promocoes.Clear();
                    promocoes.ToList().ForEach(p => this.Promocoes.Add(p));
                }
            };
        }

        private void AplicarEventHandler()
        {
            List<Exception> erros = new List<Exception>();

            var eventos = this.OnChangeHandler?.GetInvocationList();

            foreach (var evento in eventos)
            {
                try
                {
                    evento.DynamicInvoke(this, this);
                }
                catch(Exception e)
                {
                    erros.Add(e);
                }
            }

            if (erros.Any())
            {
                throw new AggregateException(erros);
            }
        }

        public async Task CarregarLanches()
        {

            var lanches = await this.pedidoService.Lanches();
            lanches.ToList().ForEach(l => this.Dominios.Lanches.Add(l));
        }

        public async Task CarregarIngredientes()
        {
            var ingredientes = await this.pedidoService.Ingredientes();
            ingredientes.ToList().ForEach(l => this.Dominios.Ingredientes.Add(l));
        }

        public async Task AdicionarLanche(LancheDto lanche)
        {
            var lancheCreado = await this.pedidoService.IncluirLanche(this, lanche);
            
            if (this.Sequencial == 0 )
                this.Sequencial = lancheCreado.sequencialPedido;

            this.Lanches.Add(lancheCreado);

            await this.AtualizarListaIngredientes(lancheCreado);

            this.AplicarEventHandler();
        }

        public async Task AtualizarListaIngredientes(LancheDto lanche)
        {
            this.Ingredientes.Clear();

            if (lanche != null && lanche.Sequencial > 0)
            {
                lanche.Ingredientes.ToList().ForEach(i => this.Ingredientes.Add(i));
            }

            await Task.Run(() => { });
        }

        public async Task RemoverLanche(LancheDto lanche)
        {
            await this.pedidoService.RemoverLanche(this, lanche);

            this.Lanches.Remove(lanche);

            await AtualizarListaIngredientes(null);

            this.AplicarEventHandler();
        }

        public async Task IncluirIngrediente(LancheDto lanche, IngredienteDto ingrediente)
        {
            await this.pedidoService.IncluirIngrediente(this, lanche, ingrediente);

            lanche.Ingredientes.Add(ingrediente);

            await AtualizarListaIngredientes(lanche);

            this.AplicarEventHandler();
        }

        public async Task RemoverIngrediente(LancheDto lanche, IngredienteDto ingrediente)
        {
            await this.pedidoService.RemoverIngrediente(this, lanche, ingrediente);

            this.Lanches.Remove(lanche);

            this.AplicarEventHandler();
        }

        public async Task Encerrar()
        {
            await this.pedidoService.EncerrarPedido(this);
        }

        public async Task SelecionarLanche(LancheDto lanche)
        {
            if (lanche == null || lanche.Sequencial == 0)
                return;

            await AtualizarListaIngredientes(lanche);

            this.AplicarEventHandler();
        }
    }
}
