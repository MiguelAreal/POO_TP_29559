using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
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
    public partial class AddMarcaForm : MetroForm
    {
        private readonly MarcaController _controller;
        private readonly MarcasForm _view;

        public AddMarcaForm(MarcasForm view)
        {
            InitializeComponent();
            _view = view;
            _controller = new MarcaController(_view);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            Control[] controls = { txtNome, cmbPais};
            Label[] labels = { lblNome, lblPais};
            bool allValid = FieldValidator.ValidateFields(controls, labels);


            // Valida os campos antes de adicionar o produto
            if (!allValid)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            var novaMarca = new Marca
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                PaisOrigem = cmbPais.Text,
            };

            // Adiciona o novo produto através do controlador
            _controller.AddItem(novaMarca);

            // Atualiza a DataGridView no form principal
            _controller.CarregaItens();



            this.Close();
        }
    }
}
