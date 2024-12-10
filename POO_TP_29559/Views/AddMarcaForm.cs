using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories; // Add this line for ProdutoRepo
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddMarcaForm : MetroForm
    {
        private readonly MarcaController _controller;
        private readonly ChildForm _view;

        public AddMarcaForm(ChildForm view)
        {
            InitializeComponent();
            _view = view;

            _controller = new MarcaController(_view);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, cmbPais };
            Label[] labels = { lblNome, lblPais };
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            var novaMarca = new Marca
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                PaisOrigem = cmbPais.Text
            };

            _controller.AddItem(novaMarca);

            _controller.CarregaItens();

            this.Close();
        }

      
       
    }
}
