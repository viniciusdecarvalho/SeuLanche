using System;
using System.Configuration;
using System.Net.Http;
using System.Windows.Forms;

namespace SeuLanche.UI.Desktop
{
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            MostrarFormularioPedidoAsync();

            Cursor.Current = Cursors.Default;
        }

        private void MostrarFormularioPedidoAsync()
        {
            string root = ConfigurationManager.AppSettings["api_pedidos"] ?? "http://localhost:49676/api/";

            var client = new HttpClient
            {
                BaseAddress = new Uri($"{root}")
            };

            var pedidoService = new PedidoService(client);
            var pedidoController = new PedidoController(pedidoService);
            var pedido = new PedidoForm(pedidoController);

            pedido.Show(this);            
        }
    }
}
