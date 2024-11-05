using MetroFramework.Forms;
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
    public partial class AddClienteForm : MetroForm
    {
        private readonly ClienteController _controller;
        private readonly ChildForm _view;

        public AddClienteForm(ChildForm view)
        {
            InitializeComponent();
            _view = view;
            _controller = new ClienteController(_view);
            dtpNasc.Checked = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool allValid = false;

            Control[] controls = { txtNome, txtContacto1, txtMorada, txtNIF };
            Label[] labels = { lblNome, lblContacto, lblMorada, lblNIF };

            //Valida campos vazios
            allValid = FieldValidator.ValidateFields(controls, labels);

            //Valida número de telefone
            allValid = FieldValidator.ValidateContact(txtContacto.Text, lblContacto);

            //Valida data de nascimento, se registada
            if (dtpNasc.Checked)
            {
                allValid = FieldValidator.ValidateDate(dtpNasc, lblDataNasc);
            }

            if (!allValid)
            {
                return;
            }



            var novoCliente = new Cliente
            {
                Nome = txtNome.Text,
                Contacto = txtContacto1.Text + txtContacto.Text,
                Morada = txtMorada.Text,
                DataNasc = dtpNasc.Value.ToString(),
                Nif = txtNIF.Text,
            };


            _controller.AddItem(novoCliente);

            _controller.CarregaItens();

            this.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
