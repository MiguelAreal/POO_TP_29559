using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class VendasForm : MetroForm
    {
        private readonly VendaController _vendaController;
        private BindingSource _bindingSource;

        public VendasForm()
        {
            InitializeComponent();
            _vendaController = new VendaController(new VendaRepo(new ClienteRepo()), new ClienteRepo());
            _bindingSource = new BindingSource();
            SetupDataGridView();
            LoadVendasData();
        }

        private void SetupDataGridView()
        {
            dgvVendas.AutoGenerateColumns = false;
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "ClienteName" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data da Venda", DataPropertyName = "DataVenda" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Preço Total", DataPropertyName = "PrecoTotal" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Método de Pagamento", DataPropertyName = "MetodoPagamento" });

            dgvVendas.DataSource = _bindingSource;

            // Set up event for row double-click to view details
            dgvVendas.CellDoubleClick += DataGridViewVendas_CellDoubleClick;
        }

        private void LoadVendasData()
        {
            var vendasList = _vendaController.GetVendasWithClientNames();
            _bindingSource.DataSource = vendasList;
        }

        private void DataGridViewVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedVenda = (VendaViewModel)dgvVendas.Rows[e.RowIndex].DataBoundItem;
                var vendaDetails = _vendaController.GetVendaDetails(selectedVenda.Id);

                /*// Open the details form with the selected sale details
                using (var detailsForm = new VendaDetailForm(vendaDetails))
                {
                    detailsForm.ShowDialog();
                }*/
            }
        }
    }
}
