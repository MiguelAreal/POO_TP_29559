using MetroFramework.Forms;
using System;
using System.Diagnostics.Contracts;
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
            string contacto;

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

            contacto = $"{txtContactoCodPais.Text} {txtContacto.Text}";

            //Verificar se NIF já existe
            if (_controller.VerificarNIFExistente(Convert.ToInt32(txtNIF.Text)))
            {
                allValid &= false;
                MessageBox.Show("Este NIF já está a ser utilizado.");
            }

            //Verificar se contacto já existe.
            if (_controller.VerificarContactoExistente(contacto))
            {
                allValid &= false;
                MessageBox.Show("Este contacto já está a ser utilizado.");
            }



            var novoCliente = new Utilizador
            {
                Nome = txtNome.Text,
                Contacto = contacto,
                Morada = txtMorada.Text,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = Convert.ToInt32(txtNIF),
                IsAdmin = false,
                Password = txtNome.Text
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
