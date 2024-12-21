/**
 * @file AddCampanhaForm.cs
 * @brief Formulário para adicionar ou atualizar uma campanha.
 *
 * Este formulário permite ao utilizador adicionar uma nova campanha ou atualizar uma existente, dependendo de um ID opcional fornecido.
 * Utiliza o `CampanhaController` para manipular campanhas e o `CategoriaController` para carregar as categorias disponíveis.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class AddUpdCampanhaForm
     * @brief Formulário para a criação ou atualização de uma campanha.
     * 
     * Este formulário serve para criar uma nova campanha ou atualizar uma existente no sistema. O utilizador preenche o nome,
     * a percentagem de desconto, as datas de início e fim, e a categoria associada.
     */
    public partial class AddUpdCampanhaForm : MetroForm
    {
        private readonly CampanhaController _controller;  /**< Controlador responsável pela manipulação de campanhas. */
        private readonly CategoriaController _categoriaController;  /**< Controlador responsável pela manipulação de categorias. */
        private readonly int? _campanhaId;  /**< ID opcional da campanha para atualização. */
        private List<Categoria> _categorias;  /**< Lista de categorias disponíveis. */
        private Campanha _campanha;  /**< Instância da campanha em edição, se aplicável. */

        /**
         * @brief Construtor do `AddUpdCampanhaForm`.
         * 
         * Inicializa os controladores e carrega as categorias disponíveis.
         * Se um ID for fornecido, carrega os dados da campanha para edição.
         * 
         * @param campanhaId ID opcional da campanha. Se fornecido, o formulário será usado para atualizar a campanha correspondente.
         */
        public AddUpdCampanhaForm(int? campanhaId = null)
        {
            InitializeComponent();

            _controller = new CampanhaController();
            _categoriaController = new CategoriaController();
            _campanhaId = campanhaId;

            CarregaCategorias();

            if (_campanhaId.HasValue)
            {
                LoadCampanhaData();
            }
            else
            {
                dtpFim.Value = DateTime.Today.AddDays(1);  // Data de fim padrão
            }
        }

        /**
         * @brief Carrega os dados da campanha no formulário.
         * 
         * Preenche os campos do formulário com os dados da campanha correspondente ao ID fornecido.
         * Caso a campanha não seja encontrada, exibe uma mensagem de erro.
         */
        private void LoadCampanhaData()
        {
            try
            {
                _campanha = (Campanha)_controller.GetById(_campanhaId.Value);

                if (_campanha == null)
                {
                    MessageBox.Show("Campanha não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtNome.Text = _campanha.Nome;
                nudPercentagemDesc.Value = Convert.ToDecimal(_campanha.PercentagemDesc);
                dtpIni.Value = DateTime.Parse(_campanha.DataInicio);
                dtpFim.Value = DateTime.Parse(_campanha.DataFim);
                cmbCategoria.SelectedValue = _campanha.CategoriaId;
                this.Text = $"Editar Campanha: {_campanha.Nome}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a campanha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /**
         * @brief Carrega as categorias disponíveis no combo box.
         */
        private void CarregaCategorias()
        {
            _categorias = _categoriaController.GetItems().Cast<Categoria>().ToList();
            _categorias = _categorias.OrderBy(c => c.Nome).ToList();

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";
            }
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Valida os campos do formulário e cria ou atualiza a campanha no sistema.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, nudPercentagemDesc, dtpIni, dtpFim, cmbCategoria };
            Label[] labels = { lblNome, lblDesconto, lblDataIni, lblDataFim, lblCategoria };

            bool allValid = FieldValidator.ValidateFields(controls, labels);

            if (!allValid) return;

            try
            {
                if (_campanhaId.HasValue)
                {
                    // Atualiza a campanha existente
                    if (_campanha != null)
                    {
                        _campanha.Nome = txtNome.Text;
                        _campanha.PercentagemDesc = nudPercentagemDesc.Value;
                        _campanha.DataInicio = dtpIni.Value.ToString();
                        _campanha.DataFim = dtpFim.Value.ToString();
                        _campanha.CategoriaId = Convert.ToInt32(cmbCategoria.SelectedValue);

                        _controller.UpdateItem(_campanha);
                        MessageBox.Show("Campanha atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Cria uma nova campanha
                    var novaCampanha = new Campanha
                    {
                        Nome = txtNome.Text,
                        PercentagemDesc = nudPercentagemDesc.Value,
                        DataInicio = dtpIni.Value.ToString(),
                        DataFim = dtpFim.Value.ToString(),
                        CategoriaId = Convert.ToInt32(cmbCategoria.SelectedValue),
                    };

                    _controller.AddItem(novaCampanha);
                    MessageBox.Show("Campanha adicionada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a campanha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
