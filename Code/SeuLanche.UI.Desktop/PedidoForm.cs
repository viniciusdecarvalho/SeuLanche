using SeuLanche.ModelDto;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SeuLanche.UI.Desktop
{
    internal partial class PedidoForm : Form
    {
        private PedidoController pedido;
        private TimeSpan time = TimeSpan.Zero;

        public PedidoForm(PedidoController pedido)
        {
            this.pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));
            InitializeComponent();
        }

        private async void Pedido_Load(object sender, EventArgs e)
        {
            await this.pedido.CarregarLanches();
            await this.pedido.CarregarIngredientes();

            this.pedido.OnChangeHandler += (src, evt) =>
            {
                AtualizarLabelPreco();
                AtualizaComponentes();
            };

            cmbLanchesAddItem.Items.AddRange(pedido.Dominios.Lanches.ToArray());
            cmbIngredientesAddItem.Items.AddRange(pedido.Dominios.Ingredientes.ToArray());

            dgvLanches.DataSource = pedido.Lanches;
            dgvIngredientes.DataSource = pedido.Ingredientes;
            dgvPromocoes.DataSource = pedido.Promocoes;
            dgvLanches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromocoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var contador = new Timer();
            contador.Interval = 1000;
            contador.Tick += (sv, ev) => 
            {
                this.time = time.Add(TimeSpan.FromSeconds(1));
                lblTempoPedido.Text = this.time.ToString();
            };
            contador.Start();
//#if DEBUG
//contador.Stop();
//#endif
        }

        private async void blnLancheAddItem_Click(object sender, EventArgs e)
        {
            var lanche = cmbLanchesAddItem.SelectedItem as LancheDto;

            if (lanche == null)
            {
                cmbLanchesAddItem.Focus();
                MessageBox.Show(this, "selecione o lanche", "Adicionar Lanche", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           await pedido.AdicionarLanche(lanche);            
        }

        private void AtualizarLabelPreco()
        {
            lblPrecoPedido.Text = pedido.Saldo.ToString("C", new CultureInfo("pt-BR"));            
        }

        private void AtualizaComponentes()
        {
            dgvLanches.Refresh();
            dgvIngredientes.Refresh();
            Refresh();
        }

        private async void dgvLanches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const int BtnRemover = 1;
            bool remover = e.ColumnIndex == BtnRemover;

            if (e.RowIndex == -1) return;

            var lanche = this.pedido.Lanches.ElementAt(e.RowIndex);

            if (remover)
            {
                var result = MessageBox.Show(this, "Deseja remover o lanche?", "Alterar pedido", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    await this.pedido.RemoverLanche(lanche);                    
                    return;
                }
            }
        }

        private async void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Deseja concluir o pedido?", "Terminar pedido", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                await this.pedido.Encerrar();

                Cursor.Current = Cursors.Default;

                Close();
            }
        }

        private async void btnIngredienteAddItem_Click(object sender, EventArgs e)
        {
            var selecionada = dgvLanches.SelectedRows[0];

            if (selecionada == null || selecionada.DataBoundItem == null)
            {
                return;
            }

            var lanche = this.pedido.Lanches.ElementAt(selecionada.Index);

            if (lanche == null)
            {
                cmbLanchesAddItem.Focus();
                MessageBox.Show(this, "selecione um lanche adicionado para incluir ou remover um ingrediente", "Alterar Lanche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ingrediente = cmbIngredientesAddItem.SelectedItem as IngredienteDto;

            if (ingrediente == null)
            {
                cmbIngredientesAddItem.Focus();
                MessageBox.Show(this, "selecione o ingrediente", "Adicionar ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await this.pedido.IncluirIngrediente(lanche, ingrediente);
        }

        private async void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const int BtnRemover = 1;
            bool remover = e.ColumnIndex == BtnRemover;

            if (e.RowIndex == -1)
                return;

            if (dgvLanches.SelectedRows.Count == 0)
                return;

            var selecionada = dgvLanches.SelectedRows[0];

            if (selecionada == null)
            {
                return;
            }

            var lanche = this.pedido.Lanches.ElementAt(selecionada.Index);

            if (remover)
            {
                var result = MessageBox.Show(this, "Deseja remover o ingrediente?", "Alterar lanche", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.OK)
                {
                    await this.pedido.RemoverLanche(lanche);                    

                    return;
                }
            }
        }

        private async void dgvLanches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var lanche = this.pedido.Lanches.ElementAt(e.RowIndex);

            await this.pedido.SelecionarLanche(lanche);
        }
    }
}
