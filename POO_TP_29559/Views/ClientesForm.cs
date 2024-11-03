using MetroFramework.Forms;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class ClientesForm : MetroForm
    {
        private readonly ClienteController _controller;

        public ClientesForm()
        {
            InitializeComponent();
            _controller = new ClienteController(this);
        }

        public void MostraClientes(List<Cliente> clientes)
        {
            // Cria um BindingSource para associar à DGV lista de clientes
            // Esconde a coluna ID
            BindingSource bs = new BindingSource
            {
                DataSource = clientes
            };
            dgvClientes.DataSource = bs;
            dgvClientes.Refresh();

            dgvClientes.Columns["Id"].Visible = false;
            dgvClientes.Columns["IsParticular"].Visible = false;
        }
    }
}
