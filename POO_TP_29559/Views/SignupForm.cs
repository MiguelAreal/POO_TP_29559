using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class SignupForm : Form
    {
        private readonly UtilizadorController _controller;

        public SignupForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
            dtpNasc.Checked = true;
        }

        private void lblLoginAqui_Click(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool allValid = true;
            string contacto;
            int NIF;

            // Validação de campos vazios
            Control[] controls = { txtNome, txtPassword,txtContactoCodPais};
            Label[] labels = { imgUser, imgPwd,imgContacto };
            allValid &= FieldValidator.ValidateFields(controls, labels, Color.FromArgb(9, 171, 219));

            // Valida número de telefone
            allValid &= FieldValidator.ValidateNineDigits(txtContacto.Text, imgContacto, Color.FromArgb(9, 171, 219));

            // Valida NIF
            allValid &= FieldValidator.ValidateNineDigits(txtNIF.Text, imgNIF, Color.FromArgb(9, 171, 219));

            // Valida data de nascimento, se marcada
            if (dtpNasc.Checked)
            {
                allValid &= FieldValidator.ValidateDate(dtpNasc, imgDataNasc);
            }

            // Garante que o contacto tem país e número, e não apenas um deles.
            if (string.IsNullOrWhiteSpace(txtContactoCodPais.Text) || string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                imgContacto.ForeColor = Color.Red;
                allValid &= false;
            }
            contacto = $"{txtContactoCodPais.Text} {txtContacto.Text}";

            if (!rdbAdmin.Checked && !rdbCliente.Checked)
            {
                imgTipoUser.ForeColor = Color.Red;
                allValid &= false;
            }


            //Verificar se NIF já existe
            if (_controller.VerificarNIFExistente(Convert.ToInt32(txtNIF.Text)))
            {
                allValid &= false;
                MessageBox.Show("Este NIF já está a ser utilizado.");
            }

            //Verificar se contacto já existe.
            if (_controller.VerificarContactoExistente(contacto)) {
                allValid &= false;
                MessageBox.Show("Este contacto já está a ser utilizado.");
            }

            // Exibe erro e interrompe o fluxo, se inválido
            if (!allValid)
            {
                return;
            }

            var novoUtilizador = new Utilizador
            {
                Nome = txtNome.Text,
                Contacto = contacto,
                Morada = null,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = Convert.ToInt32(txtNIF.Text),
                Password = txtPassword.Text,
                IsAdmin = rdbAdmin.Checked

            };

            // Adiciona e atualiza itens na view
            _controller.AddItem(novoUtilizador);

            GoToLogin();


        }

        public void GoToLogin()
        {
            // Create an instance of the registration form
            LoginForm FormLogin = new LoginForm();
            FormLogin.Show();
            this.Hide();
        }
    }
}
