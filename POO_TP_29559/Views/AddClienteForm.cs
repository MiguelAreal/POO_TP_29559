using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddClienteForm : MetroForm
    {
        private readonly UtilizadorController _controller;

        public AddClienteForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
            dtpNasc.Checked = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool allValid = true;

            // Validação de campos vazios
            Control[] controls = { txtNome, txtContactoCodPais, txtMorada };
            Label[] labels = { lblNome, lblContacto, lblMorada };
            allValid &= FieldValidator.ValidateFields(controls, labels);

            // Valida número de telefone
            allValid &= FieldValidator.ValidateNineDigits(txtContacto.Text, lblContacto);

            // Valida NIF
            allValid &= FieldValidator.ValidateNineDigits(txtNIF.Text, lblNIF);

            // Valida data de nascimento, se marcada
            if (dtpNasc.Checked)
            {
                allValid &= FieldValidator.ValidateDate(dtpNasc, lblDataNasc);
            }

            // Exibe erro e interrompe o fluxo, se inválido
            if (!allValid)
            {
                return;
            }

            // Garante que o contacto tem país e número, e não apenas um deles.
            if (string.IsNullOrWhiteSpace(txtContactoCodPais.Text) || string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                lblContacto.ForeColor = Color.Red;
                return;
            }

            var novoCliente = new Utilizador
            {
                Nome = txtNome.Text,
                Contacto = txtContactoCodPais.Text + txtContacto.Text,
                Morada = txtMorada.Text,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = txtNIF.Text,
            };

            // Adiciona e atualiza itens na view
            _controller.AddItem(novoCliente);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
