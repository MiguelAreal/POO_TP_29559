using MetroFramework.Forms;
using poo_tp_29559.Models;
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
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddCampanhaForm : MetroForm
    {
        private readonly CampanhaController _controller;
        private CategoriaController categoriaController;
        private List<Categoria> _categorias;

        public AddCampanhaForm()
        {
            InitializeComponent();

            _controller = new CampanhaController();
            categoriaController = new CategoriaController();

            CarregaCategorias();

            
            // Data de início é a data atual
            // Data de fim é o dia após a data atual.
            dtpFim.Value = DateTime.Today.AddDays(1);
        }

        private void CarregaCategorias()
        {
            _categorias = (List<Categoria>)categoriaController.GetItems();
            _categorias = _categorias.OrderBy(m => m.Nome).ToList();

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, nudPercentagemDesc, dtpIni,dtpFim,cmbCategoria};
            Label[] labels = { lblNome, lblDesconto,lblDataIni,lblDataFim,lblCategoria};
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Valida os campos antes de adicionar a Campanha
            if (!allValid)
            {
                return;
            }

            var novaCampanha = new Campanha
            {
                Nome = txtNome.Text,
                PercentagemDesc = Convert.ToDecimal(nudPercentagemDesc.Value),
                DataInicio = dtpIni.Value.ToString(),
                DataFim = dtpFim.Value.ToString(),
                CategoriaId = Convert.ToInt32(cmbCategoria.SelectedValue),
            };

            _controller.AddItem(novaCampanha);



            this.Close();
        }

    }
}
