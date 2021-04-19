using SeuLanche.ModelDto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeuLanche.WebAPI.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly SeuLancheContext db;

        public PedidosService(SeuLancheContext db)
        {
            this.db = db;
        }

        public async Task<int> AdicionarLanche(int sequencialPedido, int sequencialLanche)
        {
            if (sequencialPedido <= 0)
            {
                var paramSequencialPedido = new ObjectParameter("Sequencial", sequencialPedido);

                this.db.PedidoCriar(paramSequencialPedido);

                sequencialPedido = (int)paramSequencialPedido.Value;
            }

            var paramSequencialPedidoLanche = new ObjectParameter("SequencialPedidoLanche", sequencialPedido);

            this.db.PedidoAdicionarLanche(sequencialPedido, sequencialLanche, paramSequencialPedidoLanche);

            await this.db.SaveChangesAsync();

            return (int)paramSequencialPedidoLanche.Value;
        }

        public LancheDto Lanche(int sequencialPedidoLanche)
        {
            var lanches =
                from lanche in this.db.Lanches
                join pedidoLanches in this.db.PedidosLanches on lanche.Sequencial equals pedidoLanches.SequencialLanche
                where pedidoLanches.Sequencial == sequencialPedidoLanche
                orderby lanche.Nome
                select new LancheDto
                {
                    sequencialPedido = pedidoLanches.SequencialPedido,
                    SequencialPedidoLanche = pedidoLanches.Sequencial,
                    Sequencial = lanche.Sequencial,
                    Nome = lanche.Nome,
                    Ingredientes = (
                        from ingre in this.db.IngredientesLanche
                        where ingre.SequencialLanche == lanche.Sequencial
                        select new IngredienteDto
                        {
                            Sequencial = ingre.SequencialIngrediente,
                            Nome = ingre.Nome,
                            Valor = ingre.Valor
                        }).ToList()
                };

            return lanches.AsNoTracking().FirstOrDefault();
        }

        public async Task AdicionarIngrediente(int sequencialPedidoLanche, int sequencialIngrediente)
        {
            this.db.PedidoAdicionarIngrediente(sequencialPedidoLanche, sequencialIngrediente);

            await this.db.SaveChangesAsync();
        }

        public async Task RemoverIngrediente(int sequencialPedidoLanche, int sequencialIngrediente)
        {
            this.db.PedidoAlterarLanche(sequencialPedidoLanche, sequencialIngrediente, 0);

            await this.db.SaveChangesAsync();
        }

        public async Task AdicionarLancheIngrediente(int sequencialPedido)
        {
            this.db.PedidoEncerrar(sequencialPedido, foiConcluido: true);

            await this.db.SaveChangesAsync();
        }

        public async Task RemoverLanche(int sequencialPedido, int sequencialLanche)
        {
            this.db.PedidoRemoverLanche(sequencialPedido, sequencialLanche);

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PromocaoDto>> Promocoes(int sequencialPedido)
        {
            var promocoes =
                from p in this.db.PedidosPromocoes
                where p.SequencialPedido == sequencialPedido
                orderby p.Desconto descending
                select new PromocaoDto
                {
                    Descricao = p.Descricao,
                    Valor = p.Desconto.Value
                };

            return await promocoes.ToListAsync();
        }

        public async Task<IEnumerable<IngredienteDto>> Ingredientes()
        {
            var ingredientes =
                from ingre in this.db.Ingredientes
                join valor in this.db.IngredientesValorVigencia on ingre.Sequencial equals valor.SequencialIngrediente
                where valor.Fim == null
                orderby ingre.Nome
                select new IngredienteDto
                {
                    Sequencial = ingre.Sequencial,
                    Nome = ingre.Nome,
                    Valor = valor.Valor
                };

            return await ingredientes.ToListAsync();
        }

        public async Task<IEnumerable<LancheDto>> Lanches()
        {
            var lanches =
                from lanche in this.db.Lanches
                where lanche.Ativo
                orderby lanche.Nome
                select new LancheDto
                {
                    Sequencial = lanche.Sequencial,
                    Nome = lanche.Nome,
                    Ingredientes = (
                        from ingre in this.db.IngredientesLanche
                        where ingre.SequencialLanche == lanche.Sequencial
                        select new IngredienteDto
                        {
                            Sequencial = ingre.SequencialIngrediente,
                            Nome = ingre.Nome,
                            Valor = ingre.Valor
                        }).ToList()
                };

            return await lanches.ToListAsync();
        }
    }
}