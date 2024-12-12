using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddMarcaForm : MetroForm
    {
        private readonly MarcaController _controller;

        public AddMarcaForm()
        {
            InitializeComponent();
            _controller = new MarcaController();
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

            this.Close();
        }

      
       
    }
}
