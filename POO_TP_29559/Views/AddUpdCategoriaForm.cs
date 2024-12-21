/**
 * @file AddCategoriaForm.cs
 * @brief Formulário para adicionar ou atualizar uma categoria.
 *
 * Este formulário permite ao utilizador adicionar uma nova categoria ou atualizar uma existente, dependendo de um ID opcional fornecido.
 * Utiliza o `CategoriaController` para manipular as categorias.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class AddUpdCategoriaForm
     * @brief Formulário para a criação ou atualização de uma categoria.
     * 
     * Este formulário serve para criar uma nova categoria ou atualizar uma existente no sistema.
     * O utilizador preenche o nome e a descrição da categoria.
     */
    public partial class AddUpdCategoriaForm : MetroForm
    {
        private readonly CategoriaController _controller;  /**< Controlador responsável pela manipulação de categorias. */
        private readonly int? _categoriaId;  /**< ID opcional da categoria para atualização. */
        Categoria categoria;

        /**
         * @brief Construtor do `AddUpdCategoriaForm`.
         * 
         * Inicializa o controlador de categorias, que será utilizado para manipular as categorias.
         * Se um ID for fornecido, carrega os dados da categoria para edição.
         * 
         * @param categoriaId ID opcional da categoria. Se fornecido, o formulário será usado para atualizar a categoria correspondente.
         */
        public AddUpdCategoriaForm(int? categoriaId = null)
        {
            InitializeComponent();
            _controller = new CategoriaController();  /**< Inicializa o controlador de categorias. */
            _categoriaId = categoriaId;

            // Se um ID válido for fornecido, carrega os dados da categoria
            if (_categoriaId.HasValue)
            {
                LoadCategoriaData();
            }
        }

        /**
         * @brief Carrega os dados da categoria no formulário.
         * 
         * Preenche os campos do formulário com os dados da categoria correspondente ao ID fornecido.
         * Caso a categoria não seja encontrada, exibe uma mensagem de erro.
         */
        private void LoadCategoriaData()
        {
            try
            {
                // Busca a categoria pelo ID
                categoria = (Categoria)_controller.GetById(_categoriaId.Value);

                if (categoria == null)
                {
                    MessageBox.Show("Categoria não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Preenche os campos do formulário com os dados da categoria
                txtNome.Text = categoria.Nome;
                txtDescricao.Text = categoria.Descricao;
                this.Text = $"Editar Categoria: {categoria.Nome}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar ou atualizar a categoria.
         * Valida os campos do formulário e, caso todos os campos sejam válidos, cria ou atualiza a categoria no sistema.
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

            // Criação ou atualização da categoria
            if (_categoriaId.HasValue)
            {
                // Atualiza a categoria existente
                try
                {
                    if (categoria != null)
                    {
                        categoria.Nome = txtNome.Text;  /**< Atualiza o nome da categoria. */
                        categoria.Descricao = txtDescricao.Text;  /**< Atualiza a descrição da categoria. */

                        _controller.UpdateItem(categoria);  /**< Atualiza a categoria no sistema. */
                        MessageBox.Show("Categoria atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar a categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Cria uma nova categoria
                var novaCategoria = new Categoria
                {
                    Nome = txtNome.Text,  /**< Nome da categoria. */
                    Descricao = txtDescricao.Text,  /**< Descrição da categoria. */
                };

                try
                {
                    _controller.AddItem(novaCategoria);
                    MessageBox.Show("Categoria adicionada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao adicionar a categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Fecha o formulário após a operação
            this.Close();
        }
    }
}
