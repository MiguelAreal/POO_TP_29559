/**
 * @file SignupForm.cs
 * @brief Formulário de Registo da aplicação.
 *
 * Esta classe representa o formulário de registo, responsável por permitir
 * a criação de novos utilizadores com validações de campos e controlo de duplicações.
 * Integra-se com a lógica de negócio através da classe `UtilizadorController`.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class SignupForm
     * @brief View responsável pelo formulário de registo.
     * 
     * A View `SignupForm` permite ao utilizador criar uma nova conta, validando 
     * todos os campos necessários, como NIF, contacto e data de nascimento.
     * Possui também integração com o controlador de utilizadores para verificar
     * se os dados fornecidos são únicos.
     */
    public partial class SignupForm : Form
    {
        /// @brief Controlador para manipulação dos utilizadores.
        private readonly UtilizadorController _controller;

        /**
         * @brief Construtor da classe `SignupForm`.
         * 
         * Inicializa os componentes visuais do formulário e configura o controlador.
         */
        public SignupForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void GoToLogin()
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            var novoUtilizador = new Utilizador
            {
                Nome = txtNome.Text,
                Contacto = ObterContactoCompleto(),
                Morada = txtMorada.Text,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = Convert.ToInt32(txtNIF.Text),
                Password = txtPassword.Text,
                IsAdmin = rdbAdmin.Checked
            };

            _controller.AddItem(novoUtilizador);
            GoToLogin();
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>(); // Lista para acumular mensagens de erro

            // Validar campos obrigatórios
            if (!FieldValidator.ValidateFields(
                new[] { txtNome, txtPassword, txtContactoCodPais,txtMorada },
                new[] { imgUser, imgPwd, imgContacto,lblMorada },
                Color.FromArgb(9, 171, 219)))
            {
                erros.Add("Por favor, preencha todos os campos obrigatórios.");
            }

            // Validar NIF
            if (!FieldValidator.ValidateNineDigits(txtNIF.Text, imgNIF, Color.FromArgb(9, 171, 219)))
            {
                erros.Add("O NIF deve conter exatamente 9 dígitos.");
            }
            else if (_controller.VerificarNIFExistente(Convert.ToInt32(txtNIF.Text)))
            {
                erros.Add("Este NIF já está a ser utilizado.");
            }

            // Validar contacto
            if (!FieldValidator.ValidateNineDigits(txtContacto.Text, imgContacto, Color.FromArgb(9, 171, 219)))
            {
                erros.Add("O contacto deve conter exatamente 9 dígitos.");
            }

            if (!ValidarContactoComCodigo())
            {
                erros.Add("Por favor, insira o código do país e o contacto.");
            }

            // Validar data de nascimento
            if (dtpNasc.Checked && !FieldValidator.ValidateDate(dtpNasc, imgDataNasc))
            {
                erros.Add("A data de nascimento é inválida.");
            }

            // Validar tipo de utilizador
            if (!rdbAdmin.Checked && !rdbCliente.Checked)
            {
                imgTipoUser.ForeColor = Color.Red;
                erros.Add("Por favor, selecione um tipo de utilizador.");
            }

            // Exibir mensagens acumuladas, caso existam
            if (erros.Count > 0)
            {
                MessageBox.Show(string.Join("\n", erros), "Erros de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private bool ValidarContactoComCodigo()
        {
            bool valido = !string.IsNullOrWhiteSpace(txtContactoCodPais.Text) && !string.IsNullOrWhiteSpace(txtContacto.Text);
            imgContacto.ForeColor = valido ? Color.Black : Color.Red;
            return valido;
        }

        private string ObterContactoCompleto()
        {
            return $"{txtContactoCodPais.Text} {txtContacto.Text}";
        }

        private void lblLoginAqui_Click(object sender, EventArgs e)
        {
            GoToLogin();
        }
    }
}
