using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * <summary>Formulário para criar ou atualizar uma marca.</summary>
     * 
     * <remarks>Este formulário serve para criar ou atualizar uma marca no sistema. O utilizador preenche o nome, a descrição e o país 
     * de origem da marca. O formulário inclui validação de campos e carrega os países disponíveis a partir de um ficheiro JSON.</remarks>
     */
    public partial class AddUpdMarcaForm : MetroForm
    {
        private readonly MarcaController _controller; /**< Controlador responsável pela manipulação de marcas. */
        private readonly int? _marcaId; /**< ID opcional da marca para atualização. */
        Marca marca;

        #region Construtors and Initialization

        /// <summary>
        /// Construtor do <see cref="AddUpdMarcaForm"/>.
        /// </summary>
        /// <param name="marcaId">(Opcional) O ID da marca a ser editada, se fornecido.</param>
        public AddUpdMarcaForm(int? marcaId = null)
        {
            InitializeComponent();
            _controller = new MarcaController(); /**< Inicializa o controlador de marcas. */
            _marcaId = marcaId;

            CarregaPaises(); /**< Carrega a lista de países. */

            if (_marcaId.HasValue)
            {
                CarregaDadosMarca(); /**< Carrega os dados da marca se um ID for fornecido. */
            }
        }

        #endregion

        #region Loading Methods

        /// <summary>
        /// Carrega os dados da marca no formulário.
        /// </summary>
        /// <remarks>
        /// Preenche os campos do formulário com os dados da marca correspondente ao ID fornecido.
        /// Caso a marca não seja encontrada, exibe uma mensagem de erro.
        /// </remarks>
        private void CarregaDadosMarca()
        {
            try
            {
                marca = (Marca)_controller.GetById(_marcaId.Value);

                if (marca == null)
                {
                    MessageBox.Show("Marca não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Preenche os campos do formulário com os dados da marca
                txtNome.Text = marca.Nome;
                txtDescricao.Text = marca.Descricao;
                cmbPais.SelectedIndex = cmbPais.FindStringExact(marca.PaisOrigem);
                this.Text = $"Editar Marca: {marca.Nome}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a marca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Carrega a lista de países disponíveis para seleção.
        /// </summary>
        /// <remarks>
        /// Preenche o combo box com os países obtidos do controlador e configura o modo de auto-completar.
        /// </remarks>
        private void CarregaPaises()
        {
            var paises = _controller.CarregaPaises();

            if (paises != null && paises.Count > 0)
            {
                cmbPais.DataSource = paises; /**< Define a fonte de dados da ComboBox. */
                cmbPais.AutoCompleteMode = AutoCompleteMode.SuggestAppend; /**< Configura o auto-completar. */
                cmbPais.AutoCompleteSource = AutoCompleteSource.CustomSource;

                var autoCompleteData = new AutoCompleteStringCollection();
                autoCompleteData.AddRange(paises.ToArray());
                cmbPais.AutoCompleteCustomSource = autoCompleteData;
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
        /// Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar ou atualizar uma marca.
        /// Valida os campos do formulário e, caso todos os campos sejam válidos, cria ou atualiza a marca no sistema.
        /// </remarks>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Array de controlos a serem validados
            Control[] controls = { txtNome, cmbPais };

            // Array de labels correspondentes aos controlos
            Label[] labels = { lblNome, lblPais };

            // Valida os campos utilizando a biblioteca de validação
            if (!FieldValidator.ValidateFields(controls, labels))
            {
                return;
            }

            try
            {
                if (_marcaId.HasValue)
                {
                    if (marca != null)
                    {
                        marca.Nome = txtNome.Text;
                        marca.Descricao = txtDescricao.Text;
                        marca.PaisOrigem = cmbPais.Text;

                        _controller.UpdateItem(marca);
                        MessageBox.Show("Marca atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Cria uma nova marca
                    var novaMarca = new Marca
                    {
                        Nome = txtNome.Text,
                        Descricao = txtDescricao.Text,
                        PaisOrigem = cmbPais.Text
                    };

                    _controller.AddItem(novaMarca);
                    MessageBox.Show("Marca adicionada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close(); /**< Fecha o formulário após a operação. */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a marca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
