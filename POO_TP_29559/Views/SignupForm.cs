using poo_tp_29559.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /// <summary>
    /// Formulário responsável pelo registo de novos utilizadores.
    /// </summary>
    public partial class SignupForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Controlador para manipulação dos utilizadores.
        /// </summary>
        private readonly UtilizadorController _controller;

        #endregion

        #region Construtors

        /// <summary>
        /// Construtor da classe `SignupForm`.
        /// </summary>
        /// <remarks>
        /// Inicializa os componentes visuais do formulário e configura o controlador.
        /// </remarks>
        public SignupForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
        }

        #endregion

        #region Methods


        /// <summary>
        /// Redireciona para a tela de login.
        /// </summary>
        private void GoToLogin()
        {
            new LoginForm().Show();
            this.Hide();
        }

      

        /// <summary>
        /// Valida os campos do formulário.
        /// </summary>
        /// <returns>Retorna verdadeiro se o formulário for válido, caso contrário falso.</returns>
        private bool ValidarFormulario()
        {
            var erros = new List<string>(); // Lista para acumular mensagens de erro

            // Validar campos obrigatórios
            if (!FieldValidator.ValidateFields(
                new[] { txtNome, txtPassword, txtContactoCodPais, txtMorada },
                new[] { imgUser, imgPwd, imgContacto, lblMorada },
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

        /// <summary>
        /// Valida se o contacto e o código do país foram corretamente preenchidos.
        /// </summary>
        /// <returns>Retorna verdadeiro se o contacto com código de país estiver correto, caso contrário falso.</returns>
        private bool ValidarContactoComCodigo()
        {
            bool valido = !string.IsNullOrWhiteSpace(txtContactoCodPais.Text) && !string.IsNullOrWhiteSpace(txtContacto.Text);
            imgContacto.ForeColor = valido ? Color.Black : Color.Red;
            return valido;
        }

        /// <summary>
        /// Obtém o número completo do contacto com código de país.
        /// </summary>
        /// <returns>Retorna o número de contacto completo com código de país.</returns>
        private string ObterContactoCompleto()
        {
            return $"{txtContactoCodPais.Text} {txtContacto.Text}";
        }

        #endregion
        #region Form Events
        /// <summary>
        /// Evento disparado ao clicar no link de redirecionamento para o login.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void lblLoginAqui_Click(object sender, EventArgs e)
        {
            GoToLogin();
        }

        /// <summary>
        /// Evento disparado ao clicar no botão de submissão do formulário.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
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

        /// <summary>
        /// Evento disparado ao clicar no botão "Sair".
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento disparado ao clicar no ícone de ocultar/mostrar a password.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
        #endregion
    }
}
