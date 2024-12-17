/**
 * @file AddClienteForm.cs
 * @brief Formulário para adicionar um novo cliente.
 *
 * Este formulário permite ao utilizador adicionar um novo cliente ao sistema, fornecendo informações como nome, contacto, morada, NIF, data de nascimento e outros.
 * Utiliza o `UtilizadorController` para manipular os dados do cliente e garantir que não existam duplicados.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using MetroFramework.Forms;
using System;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class AddClienteForm
     * @brief Formulário para a criação de um novo cliente.
     * 
     * Este formulário serve para adicionar um novo cliente ao sistema. O utilizador deve preencher vários campos, como nome, contacto, NIF, morada e data de nascimento.
     * Além disso, o sistema valida os campos para garantir que os dados inseridos sejam válidos e que não haja duplicados (como NIF ou contacto).
     */
    public partial class AddClienteForm : MetroForm
    {
        private readonly UtilizadorController _controller;  /**< Controlador responsável pela manipulação de utilizadores. */

        /**
         * @brief Construtor do `AddClienteForm`.
         * 
         * Inicializa o controlador de utilizadores e define o estado inicial do formulário.
         */
        public AddClienteForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();  /**< Inicializa o controlador de utilizadores. */
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar o cliente. Valida os campos do formulário e, caso todos os campos sejam válidos, cria um novo cliente e o adiciona ao sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool allValid = true;  /**< Variável para armazenar o estado da validação dos campos. */
            string contacto;

            // Validação de campos obrigatórios
            Control[] controls = { txtNome, txtContactoCodPais, txtMorada };
            Label[] labels = { lblNome, lblContacto, lblMorada };
            allValid &= FieldValidator.ValidateFields(controls, labels);

            // Validação do número de telefone (deve ter 9 dígitos)
            allValid &= FieldValidator.ValidateNineDigits(txtContacto.Text, lblContacto);

            // Validação do NIF (deve ter 9 dígitos)
            allValid &= FieldValidator.ValidateNineDigits(txtNIF.Text, lblNIF);

            // Validação da data de nascimento, se selecionada
            if (dtpNasc.Checked)
            {
                allValid &= FieldValidator.ValidateDate(dtpNasc, lblDataNasc);
            }

            // Se algum campo for inválido, interrompe o processo
            if (!allValid)
            {
                return;
            }

            // Garante que o contacto tem o código de país e número preenchidos
            if (string.IsNullOrWhiteSpace(txtContactoCodPais.Text) || string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                lblContacto.ForeColor = Color.Red;
                return;
            }

            // Formata o contacto com código de país e número
            contacto = $"{txtContactoCodPais.Text} {txtContacto.Text}";

            // Verifica se o NIF já existe no sistema
            if (_controller.VerificarNIFExistente(Convert.ToInt32(txtNIF.Text)))
            {
                allValid &= false;
                MessageBox.Show("Este NIF já está a ser utilizado.");
            }

            // Verifica se o contacto já existe no sistema
            if (_controller.VerificarContactoExistente(contacto))
            {
                allValid &= false;
                MessageBox.Show("Este contacto já está a ser utilizado.");
            }

            // Criação do novo cliente com os dados fornecidos
            var novoCliente = new Utilizador
            {
                Nome = txtNome.Text,  /**< Nome do cliente. */
                Contacto = contacto,  /**< Contacto do cliente, incluindo código de país. */
                Morada = txtMorada.Text,  /**< Morada do cliente. */
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,  /**< Data de nascimento do cliente, se fornecida. */
                Nif = Convert.ToInt32(txtNIF.Text),  /**< NIF do cliente. */
                IsAdmin = false,  /**< Define que o cliente não é um administrador. */
                Password = txtNome.Text  /**< Definindo a senha do cliente como o nome. */
            };

            // Adiciona o novo cliente ao sistema através do controlador
            _controller.AddItem(novoCliente);

            // Fecha o formulário após a adição do cliente
            this.Close();
        }

       
    }
}
