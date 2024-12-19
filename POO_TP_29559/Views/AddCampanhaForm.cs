/**
 * @file AddCampanhaForm.cs
 * @brief Formulário para adicionar uma nova campanha.
 *
 * Este formulário permite ao utilizador adicionar uma nova campanha ao sistema. Ele solicita informações sobre o nome da campanha,
 * a percentagem de desconto, a data de início e fim da campanha, e a categoria associada.
 * 
 * Utiliza o `CampanhaController` para adicionar a campanha e o `CategoriaController` para carregar as categorias disponíveis.
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
     * @class AddCampanhaForm
     * @brief Formulário para a criação de uma nova campanha.
     * 
     * Este formulário serve para criar e adicionar uma nova campanha ao sistema. O utilizador preenche o nome da campanha,
     * a percentagem de desconto, as datas de início e fim, e a categoria associada.
     */
    public partial class AddCampanhaForm : MetroForm
    {
        private readonly CampanhaController _controller;  /**< Controlador responsável pela manipulação de campanhas. */
        private CategoriaController categoriaController;  /**< Controlador responsável pela manipulação de categorias. */
        private List<Categoria> _categorias;  /**< Lista de categorias disponíveis para a campanha. */

        /**
         * @brief Construtor do `AddCampanhaForm`.
         * 
         * Inicializa o controlador de campanhas e de categorias, carrega as categorias disponíveis e define as datas predefinidas para
         * início e fim da campanha.
         */
        public AddCampanhaForm()
        {
            InitializeComponent();

            _controller = new CampanhaController();  /**< Inicializa o controlador de campanhas. */
            categoriaController = new CategoriaController();  /**< Inicializa o controlador de categorias. */

            CarregaCategorias();  /**< Carrega as categorias disponíveis no combo box. */

            // Define a data de fim como o dia seguinte ao atual.
            dtpFim.Value = DateTime.Today.AddDays(1);
        }

        /**
         * @brief Carrega as categorias disponíveis no combo box.
         * 
         * Este método busca todas as categorias através do controlador de categorias, ordena-as alfabeticamente e as exibe no 
         * combo box para que o utilizador possa selecionar uma.
         */
        private void CarregaCategorias()
        {
            _categorias = categoriaController.GetItems().Cast<Categoria>().ToList();  /**< Obtém a lista de categorias do controlador. */
            _categorias = _categorias.OrderBy(m => m.Nome).ToList();  /**< Ordena as categorias por nome. */

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;  /**< Define a fonte de dados do combo box. */
                cmbCategoria.DisplayMember = "Nome";  /**< Define o campo a ser exibido no combo box. */
                cmbCategoria.ValueMember = "Id";  /**< Define o campo que será usado como valor no combo box. */
            }
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar a campanha.
         * Valida os campos do formulário e, caso todos os campos sejam válidos, cria uma nova campanha e a adiciona ao sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Array de controlos a serem validados
            Control[] controls = { txtNome, nudPercentagemDesc, dtpIni, dtpFim, cmbCategoria };

            // Array de labels correspondentes aos controlos
            Label[] labels = { lblNome, lblDesconto, lblDataIni, lblDataFim, lblCategoria };

            // Valida os campos utilizando a biblioteca de validação
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Se algum campo for inválido, interrompe o processo
            if (!allValid)
            {
                return;
            }

            // Criação da nova campanha com os dados fornecidos
            var novaCampanha = new Campanha
            {
                Nome = txtNome.Text,  /**< Nome da campanha. */
                PercentagemDesc = Convert.ToDecimal(nudPercentagemDesc.Value),  /**< Percentagem de desconto. */
                DataInicio = dtpIni.Value.ToString(),  /**< Data de início da campanha. */
                DataFim = dtpFim.Value.ToString(),  /**< Data de fim da campanha. */
                CategoriaId = Convert.ToInt32(cmbCategoria.SelectedValue),  /**< Categoria associada à campanha. */
            };

            // Adiciona a nova campanha ao sistema
            _controller.AddItem(novaCampanha);

            // Fecha o formulário após a adição da campanha
            this.Close();
        }
    }
}
