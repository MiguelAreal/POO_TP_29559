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

        /**
         * @brief Fecha a aplicação.
         * 
         * Evento acionado quando o botão "Sair" é clicado.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * @brief Alterna a visibilidade da palavra-passe.
         * 
         * Evento acionado para ocultar ou mostrar os caracteres no campo da palavra-passe.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        /**
         * @brief Direciona o utilizador para o formulário de login.
         * 
         * Esconde o formulário atual e exibe o formulário de login.
         */
        private void GoToLogin()
        {
            new LoginForm().Show();
            this.Hide();
        }


        /**
         * @brief Valida e cria um novo utilizador.
         * 
         * Realiza validações de campos obrigatórios, duplicação de dados
         * (NIF e contacto) e cria um novo utilizador no sistema.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
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
                Morada = null,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = Convert.ToInt32(txtNIF.Text),
                Password = txtPassword.Text,
                IsAdmin = rdbAdmin.Checked
            };

            _controller.AddItem(novoUtilizador);
            GoToLogin();
        }

        /**
         * @brief Valida os campos do formulário.
         * 
         * Valida os campos obrigatórios, duplicação de NIF e contacto, 
         * e a seleção do tipo de utilizador.
         * 
         * @return `true` se todos os campos forem válidos; caso contrário, `false`.
         */
        private bool ValidarFormulario()
        {
            bool allValid = true;

            // Validação de campos vazios
            Control[] controls = { txtNome, txtPassword, txtContactoCodPais };
            Label[] labels = { imgUser, imgPwd, imgContacto };
            allValid &= FieldValidator.ValidateFields(controls, labels, Color.FromArgb(9, 171, 219));

            // Validação de NIF
            allValid &= FieldValidator.ValidateNineDigits(txtNIF.Text, imgNIF, Color.FromArgb(9, 171, 219));
            allValid &= ValidarDuplicacao(_controller.VerificarNIFExistente, Convert.ToInt32(txtNIF.Text), "Este NIF já está a ser utilizado.");

            // Validação de contacto
            allValid &= FieldValidator.ValidateNineDigits(txtContacto.Text, imgContacto, Color.FromArgb(9, 171, 219));
            allValid &= ValidarContactoComCodigo();

            // Validação de data de nascimento
            if (dtpNasc.Checked)
            {
                allValid &= FieldValidator.ValidateDate(dtpNasc, imgDataNasc);
            }

            // Validação do tipo de utilizador
            bool tipoValido = rdbAdmin.Checked || rdbCliente.Checked;
            imgTipoUser.ForeColor = tipoValido ? Color.Black : Color.Red;
            allValid &= tipoValido;

            return allValid;
        }

        /**
         * @brief Valida a duplicação de valores no sistema.
         * 
         * @param verificacao Método de verificação que retorna `true` se o valor existir.
         * @param valor Valor a ser verificado.
         * @param mensagemErro Mensagem de erro a ser exibida se duplicado.
         * @return `true` se o valor não existir; caso contrário, `false`.
         */
        private bool ValidarDuplicacao(Func<int, bool> verificacao, int valor, string mensagemErro)
        {
            if (verificacao(valor))
            {
                MessageBox.Show(mensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /**
         * @brief Valida o contacto composto por código de país e número.
         * 
         * Verifica se ambos os campos estão preenchidos corretamente.
         * 
         * @return `true` se válido; caso contrário, `false`.
         */
        private bool ValidarContactoComCodigo()
        {
            bool valido = !string.IsNullOrWhiteSpace(txtContactoCodPais.Text) && !string.IsNullOrWhiteSpace(txtContacto.Text);
            imgContacto.ForeColor = valido ? Color.Black : Color.Red;
            return valido;
        }

        /**
         * @brief Obtém o contacto completo com código de país.
         * 
         * Concatena o código do país com o número de contacto.
         * 
         * @return String representando o contacto completo.
         */
        private string ObterContactoCompleto()
        {
            return $"{txtContactoCodPais.Text} {txtContacto.Text}";
        }

        /**
         * @brief Direciona o utilizador para o formulário de login.
         * 
         * Evento acionado ao clicar no rótulo "Login Aqui".
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void lblLoginAqui_Click(object sender, EventArgs e)
        {
            GoToLogin();
        }
    }
}
