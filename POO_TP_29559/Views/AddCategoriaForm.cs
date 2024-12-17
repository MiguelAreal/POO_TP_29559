/**
 * @file AddCategoriaForm.cs
 * @brief Formulário para adicionar uma nova categoria.
 *
 * Este formulário permite ao utilizador adicionar uma nova categoria ao sistema, fornecendo um nome e uma descrição para a categoria.
 * Utiliza o `CategoriaController` para manipular as categorias e adicionar a nova categoria ao sistema.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class AddCategoriaForm
     * @brief Formulário para a criação de uma nova categoria.
     * 
     * Este formulário serve para criar e adicionar uma nova categoria ao sistema. O utilizador preenche o nome e a descrição da categoria.
     */
    public partial class AddCategoriaForm : MetroForm
    {
        private readonly CategoriaController _controller;  /**< Controlador responsável pela manipulação de categorias. */

        /**
         * @brief Construtor do `AddCategoriaForm`.
         * 
         * Inicializa o controlador de categorias, que será utilizado para adicionar a nova categoria.
         */
        public AddCategoriaForm()
        {
            InitializeComponent();
            _controller = new CategoriaController();  /**< Inicializa o controlador de categorias. */
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar a categoria.
         * Valida os campos do formulário e, caso todos os campos sejam válidos, cria uma nova categoria e a adiciona ao sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Array de controles a serem validados
            Control[] controls = { txtNome };

            // Array de labels correspondentes aos controles
            Label[] labels = { lblNome };

            // Valida os campos utilizando a biblioteca de validação
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Se algum campo for inválido, interrompe o processo
            if (!allValid)
            {
                return;
            }

            // Criação da nova categoria com os dados fornecidos
            var novaCategoria = new Categoria
            {
                Nome = txtNome.Text,  /**< Nome da categoria. */
                Descricao = txtDescricao.Text,  /**< Descrição da categoria. */
            };

            // Adiciona a nova categoria ao sistema
            _controller.AddItem(novaCategoria);

            // Fecha o formulário após a adição da categoria
            this.Close();
        }
    }
}
