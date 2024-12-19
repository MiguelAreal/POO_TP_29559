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
     * @class AddUpdProdutoForm
     * @brief Formulário para a criação de um novo produto.
     * 
     * Este formulário serve para criar ou atualizar um produto ao sistema. O utilizador preenche informações como o nome,
     * a categoria, a marca, o preço e a quantidade em stock do produto. O formulário também carrega as marcas e categorias disponíveis
     * através dos controladores correspondentes.
     */
    public partial class AddUpdProdutoForm : MetroForm
    {
        private readonly ProdutoController _controller;  /**< Controlador responsável pela manipulação de produtos. */
        private MarcaController marcaController;  /**< Controlador responsável pela manipulação de marcas. */
        private CategoriaController categoriaController;  /**< Controlador responsável pela manipulação de categorias. */

        private int? _produtoId;  /**< ID do produto a ser editado (opcional). */
        private List<Marca> _marcas;  /**< Lista de marcas disponíveis para o produto. */
        private List<Categoria> _categorias;  /**< Lista de categorias disponíveis para o produto. */

        
        /**
         * @brief Construtor do `AddUpdProdutoForm`.
         * 
         * Inicializa os controladores de produtos, marcas e categorias. Aceita um ID de produto para edição (opcional).
         * 
         * @param produtoId ID do produto a ser editado (ou null para adicionar um novo produto).
         */
        public AddUpdProdutoForm(int? produtoId = null)
        {
            InitializeComponent();

            _controller = new ProdutoController();  /**< Inicializa o controlador de produtos. */
            marcaController = new MarcaController();  /**< Inicializa o controlador de marcas. */
            categoriaController = new CategoriaController();  /**< Inicializa o controlador de categorias. */
            _produtoId = produtoId;  /**< Armazena o ID do produto, se fornecido. */
        }

        /**
        * @brief Evento de carregamento do formulário.
        * 
        * Este evento é disparado quando o formulário é carregado. Ele carrega as marcas e categorias disponíveis no sistema.
        * Caso um ID de produto tenha sido fornecido, carrega os dados do produto para edição.
        * 
        * @param sender Objeto que disparou o evento.
        * @param e Dados do evento.
        */
        private void AddProdutoForm_Load(object sender, EventArgs e)
        {
            CarregaMarcas();
            CarregaCategorias();

            if (_produtoId.HasValue)
            {
                CarregaProdutoExistente();
            }
        }

        /**
         * @brief Carrega as marcas disponíveis.
         * 
         * Este método busca todas as marcas através do controlador de marcas, ordena-as alfabeticamente e as exibe na `ComboBox`
         * para que o utilizador possa selecionar uma.
         */
        private void CarregaMarcas()
        {
            _marcas = marcaController.GetItems().Cast<Marca>().ToList();  // Converte explicitamente para List<Marca>
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
            _categorias = categoriaController.GetItems().Cast<Categoria>().ToList();  /**< Obtém a lista de categorias do controlador. */
            _categorias = _categorias.OrderBy(m => m.Nome).ToList();  /**< Ordena as categorias por nome. */

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;  /**< Define a fonte de dados da ComboBox para as categorias. */
                cmbCategoria.DisplayMember = "Nome";  /**< Define o campo a ser exibido no combo box. */
                cmbCategoria.ValueMember = "Id";  /**< Define o campo que será usado como valor no combo box. */
            }
        }

        /**
        * @brief Carrega os dados de um produto existente.
        * 
        * Este método busca os dados de um produto existente pelo ID e preenche os campos do formulário para edição.
        * Caso o produto não seja encontrado, exibe uma mensagem de erro e fecha o formulário.
        */
        private void CarregaProdutoExistente()
        {
            Produto produto = (Produto)_controller.GetById(_produtoId.Value);

            if (produto != null)
            {
                // Preenche os campos do formulário com os dados do produto
                txtNome.Text = produto.Nome;
                cmbCategoria.SelectedValue = produto.CategoriaID;
                cmbMarca.SelectedValue = produto.MarcaID;
                nudPreco.Value = produto.Preco;
                nudStock.Value = produto.QuantidadeEmStock;

                // Atualiza o título do formulário
                this.Text = $"Editar Produto: {produto.Nome}";
            }
            else
            {
                MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /**
        * @brief Evento de clique no botão de confirmação.
        * 
        * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar ou atualizar um produto.
        * Valida os campos do formulário e, caso todos os campos sejam válidos, cria ou atualiza o produto no sistema.
        * 
        * @param sender Objeto que disparou o evento.
        * @param e Dados do evento.
        */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, cmbCategoria, cmbMarca, nudPreco, nudStock };
            Label[] labels = { lblNome, lblCategoria, lblMarca, lblPreco, lblStock };

            bool allValid = FieldValidator.ValidateFields(controls, labels);

            if (!allValid)
            {
                return;
            }

            var categoriaSelecionada = cmbCategoria.SelectedItem as Categoria;
            var marcaSelecionada = cmbMarca.SelectedItem as Marca;

            if (_produtoId.HasValue)
            {
                // Atualizar produto existente
                var produtoExistente = new Produto
                {
                    Id = _produtoId.Value,
                    Nome = txtNome.Text,
                    CategoriaID = categoriaSelecionada.Id,
                    MarcaID = marcaSelecionada.Id,
                    Preco = nudPreco.Value,
                    QuantidadeEmStock = Convert.ToInt32(nudStock.Value)
                };

                _controller.UpdateItem(produtoExistente);
                MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Adicionar novo produto
                var novoProduto = new Produto
                {
                    Nome = txtNome.Text,
                    CategoriaID = categoriaSelecionada.Id,
                    MarcaID = marcaSelecionada.Id,
                    Preco = nudPreco.Value,
                    QuantidadeEmStock = Convert.ToInt32(nudStock.Value)
                };

                _controller.AddItem(novoProduto);
                MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }
    }
}
