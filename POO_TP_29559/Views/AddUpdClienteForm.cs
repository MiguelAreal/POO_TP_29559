using MetroFramework.Forms;
using poo_tp_29559.Models;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * <summary>Formulário para a criação ou edição de um cliente.</summary>
     * 
     * <remarks>Este formulário serve para adicionar um novo cliente ou editar um cliente existente no sistema. O utilizador deve preencher vários campos, como nome, contacto, NIF, morada e data de nascimento.
     * O sistema valida os campos para garantir que os dados inseridos sejam válidos e que não haja duplicados (como NIF ou contacto).</remarks>
     */
    public partial class AddUpdClienteForm : MetroForm
    {
        private readonly UtilizadorController _controller; /**< Controlador responsável pela manipulação de utilizadores. */
        private readonly int? _clienteId; /**< ID do cliente para edição, se aplicável. */
        Utilizador cliente;

        #region Construtors and Initialization

        /// <summary>
        /// Construtor do <see cref="AddUpdClienteForm"/>.
        /// </summary>
        /// <param name="clienteId">(Opcional) O ID do cliente a ser editado.</param>
        public AddUpdClienteForm(int? clienteId = null)
        {
            InitializeComponent();
            _controller = new UtilizadorController(); /**< Inicializa o controlador de utilizadores. */
            _clienteId = clienteId;

            if (_clienteId.HasValue)
            {
                CarregarCliente(_clienteId.Value); /**< Carrega os dados do cliente para edição. */
            }
        }

        #endregion

        #region Loading Methods

        /// <summary>
        /// Carrega os dados do cliente para edição.
        /// </summary>
        /// <param name="clienteId">ID do cliente a ser carregado.</param>
        /// <remarks>Obtém os dados do cliente pelo ID e preenche os campos do formulário.</remarks>
        private void CarregarCliente(int clienteId)
        {
            cliente = (Utilizador)_controller.GetById(clienteId);
            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNome.Text = cliente.Nome;
            txtMorada.Text = cliente.Morada;
            txtNIF.Text = cliente.Nif.ToString();
            chkAdmin.Checked = cliente.IsAdmin;
            if (!string.IsNullOrEmpty(cliente.DataNasc))
            {
                dtpNasc.Value = DateTime.Parse(cliente.DataNasc);
                dtpNasc.Checked = true;
            }

            // Separação do contacto em código de país e número
            if (!string.IsNullOrEmpty(cliente.Contacto))
            {
                if (cliente.Contacto.Contains(" "))
                {
                    var partes = cliente.Contacto.Split(' ');
                    txtContactoCodPais.Text = partes[0];
                    txtContacto.Text = partes.Length > 1 ? partes[1] : string.Empty;
                }
            }
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Evento de clique no botão de confirmação.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        /// <remarks>
        /// Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar ou atualizar o cliente.
        /// Valida os campos do formulário e, caso todos os campos sejam válidos, cria ou atualiza o cliente no sistema.
        /// </remarks>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool allValid = true;
            string contacto;

            // Validação de campos obrigatórios
            Control[] controls = { txtNome, txtContactoCodPais, txtContacto, txtMorada };
            Label[] labels = { lblNome, lblContacto, lblContacto, lblMorada };
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

            // Verifica duplicados para novos clientes
            if (!_clienteId.HasValue)
            {
                if (_controller.VerificarNIFExistente(Convert.ToInt32(txtNIF.Text)))
                {
                    MessageBox.Show("Este NIF já está a ser utilizado.");
                    return;
                }

                if (_controller.VerificarContactoExistente(contacto))
                {
                    MessageBox.Show("Este contacto já está a ser utilizado.");
                    return;
                }
            }

            // Criação ou atualização do cliente
            cliente = new Utilizador
            {
                Id = _clienteId ?? 0, /**< ID do cliente (0 para novos clientes). */
                Nome = txtNome.Text,
                Contacto = contacto,
                Morada = txtMorada.Text,
                DataNasc = dtpNasc.Checked ? dtpNasc.Value.ToString("dd-MM-yyyy HH:mm:ss") : null,
                Nif = Convert.ToInt32(txtNIF.Text),
                IsAdmin = chkAdmin.Checked,
                Password = txtNome.Text
            };

            if (_clienteId.HasValue)
            {
                _controller.UpdateItem(cliente);
            }
            else
            {
                _controller.AddItem(cliente);
            }

            this.Close();
        }

        #endregion
    }
}
