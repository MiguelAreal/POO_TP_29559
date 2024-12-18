/** @file AddProdutoForm.cs
* @brief Formulário para adicionar um novo produto.
*
* Este formulário permite ao utilizador adicionar um novo produto ao sistema. Ele solicita informações sobre o nome do produto,
* a categoria, a marca, o preço e a quantidade em stock. Utiliza o `ProdutoController` para adicionar o produto ao sistema,
* e os controladores `MarcaController` e `CategoriaController` para carregar as marcas e categorias disponíveis.
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
     * @class AddProdutoForm
     * @brief Formulário para a criação de um novo produto.
     * 
     * Este formulário serve para criar e adicionar um novo produto ao sistema. O utilizador preenche informações como o nome,
     * a categoria, a marca, o preço e a quantidade em stock do produto. O formulário também carrega as marcas e categorias disponíveis
     * através dos controladores correspondentes.
     */
    public partial class AddProdutoForm : MetroForm
    {
        private readonly ProdutoController _controller;  /**< Controlador responsável pela manipulação de produtos. */
        private MarcaController marcaController;  /**< Controlador responsável pela manipulação de marcas. */
        private CategoriaController categoriaController;  /**< Controlador responsável pela manipulação de categorias. */

        private List<Marca> _marcas;  /**< Lista de marcas disponíveis para o produto. */
        private List<Categoria> _categorias;  /**< Lista de categorias disponíveis para o produto. */

        /**
         * @brief Construtor do `AddProdutoForm`.
         * 
         * Inicializa os controladores de produtos, marcas e categorias.
         */
        public AddProdutoForm()
        {
            InitializeComponent();

            _controller = new ProdutoController();  /**< Inicializa o controlador de produtos. */
            marcaController = new MarcaController();  /**< Inicializa o controlador de marcas. */
            categoriaController = new CategoriaController();  /**< Inicializa o controlador de categorias. */
        }

        /**
         * @brief Evento de carregamento do formulário.
         * 
         * Este evento é disparado quando o formulário é carregado. Ele carrega as marcas e categorias disponíveis no sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void AddProdutoForm_Load(object sender, EventArgs e)
        {
            CarregaMarcas();  /**< Carrega as marcas disponíveis. */
            CarregaCategorias();  /**< Carrega as categorias disponíveis. */
        }

        /**
         * @brief Carrega as marcas disponíveis.
         * 
         * Este método busca todas as marcas através do controlador de marcas, ordena-as alfabeticamente e as exibe na `ComboBox`
         * para que o utilizador possa selecionar uma.
         */
        private void CarregaMarcas()
        {
            _marcas = (List<Marca>)marcaController.GetItems();  /**< Obtém a lista de marcas do controlador. */
            _marcas = _marcas.OrderBy(m => m.Nome).ToList();  /**< Ordena as marcas por nome. */

            if (_marcas != null)
            {
                cmbMarca.DataSource = _marcas;  /**< Define a fonte de dados da ComboBox para as marcas. */
                cmbMarca.DisplayMember = "Nome";  /**< Define o campo a ser exibido no combo box. */
                cmbMarca.ValueMember = "Id";  /**< Define o campo que será usado como valor no combo box. */
            }
        }

        /**
         * @brief Carrega as categorias disponíveis.
         * 
         * Este método busca todas as categorias através do controlador de categorias, ordena-as alfabeticamente e as exibe na 
         * `ComboBox` para que o utilizador possa selecionar uma.
         */
        private void CarregaCategorias()
        {
            _categorias = (List<Categoria>)categoriaController.GetItems();  /**< Obtém a lista de categorias do controlador. */
            _categorias = _categorias.OrderBy(m => m.Nome).ToList();  /**< Ordena as categorias por nome. */

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;  /**< Define a fonte de dados da ComboBox para as categorias. */
                cmbCategoria.DisplayMember = "Nome";  /**< Define o campo a ser exibido no combo box. */
                cmbCategoria.ValueMember = "Id";  /**< Define o campo que será usado como valor no combo box. */
            }
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar um novo produto.
         * Valida os campos do formulário e, caso todos os campos sejam válidos, cria um novo produto e o adiciona ao sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Array de controlos a serem validados
            Control[] controls = { txtNome, cmbCategoria, cmbMarca, nudPreco, nudStock };

            // Array de labels correspondentes aos controlos
            Label[] labels = { lblNome, lblCategoria, lblMarca, lblPreco, lblStock };

            // Valida os campos utilizando a biblioteca de validação
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Se algum campo for inválido, interrompe o processo
            if (!allValid)
            {
                return;
            }

            // Criação do novo produto com os dados fornecidos
            var categoriaSelecionada = cmbCategoria.SelectedItem as Categoria;  /**< Obtém a categoria selecionada. */
            var marcaSelecionada = cmbMarca.SelectedItem as Marca;  /**< Obtém a marca selecionada. */

            var novoProduto = new Produto
            {
                Nome = txtNome.Text,  /**< Nome do produto. */
                CategoriaID = categoriaSelecionada.Id,  /**< ID da categoria associada ao produto. */
                MarcaID = marcaSelecionada.Id,  /**< ID da marca associada ao produto. */
                Preco = nudPreco.Value,  /**< Preço do produto. */
                QuantidadeEmStock = Convert.ToInt32(nudStock.Value)  /**< Quantidade em stock do produto. */
            };

            // Adiciona o novo produto ao sistema
            _controller.AddItem(novoProduto);

            // Fecha o formulário após a adição do produto
            this.Close();
        }
    }
}
