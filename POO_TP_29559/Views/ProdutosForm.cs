using MetroFramework.Forms;  
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace poo_tp_29559
{
    /// <summary>
    /// Classe responsável pela interface de produtos, herda de <see cref="MetroForm"/>.
    /// Gere a exibição, adição, remoção e atualização de produtos na interface.
    /// </summary>
    public partial class ProdutosForm : MetroForm
    {
        private readonly ProdutoController _controller; // Controlador associado à interface

        /// <summary>
        /// Construtor da classe <see cref="ProdutosForm"/> que inicializa os componentes e o controlador.
        /// </summary>
        public ProdutosForm()
        {
            InitializeComponent();
            _controller = new ProdutoController(this);
        }

        /// <summary>
        /// Exibe a lista de produtos na DataGridView.
        /// </summary>
        /// <param name="produtos">A lista de produtos a ser exibida.</param>
        public void MostraProdutos(List<Produto> produtos)
        {
            BindingSource bs = new BindingSource
            {
                DataSource = produtos
            };
            dgvProdutos.DataSource = bs;
            dgvProdutos.Refresh();
        }




        /// <summary>
        /// Evento acionado quando o valor de uma célula na DataGridView é alterado.
        /// Atualiza a propriedade do produto correspondente na lista.
        /// </summary>
        private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Tenta obter o produto editado com base na linha e coluna alteradas
                Produto produtoAlterado = (Produto)dgvProdutos.Rows[e.RowIndex].DataBoundItem;
                _controller.UpdateItem(produtoAlterado);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Trata o caso em que a linha ou coluna não é válida
                MessageBox.Show("Selecione uma célula válida para editar.");
            }
            catch (InvalidCastException)
            {
                // Trata o caso em que a conversão do valor não é válida
                MessageBox.Show("Erro ao tentar atualizar o produto. Verifique os dados.");
            }
        }

        /// <summary>
        /// Evento acionado quando o texto na caixa de pesquisa é alterado.
        /// Filtra e exibe por nome de produto em tempo real com base na pesquisa.
        /// </summary>
        private void txtSearchProduto_TextChanged(object sender, EventArgs e)
        {
            string textoPesquisa = txtSearchProduto.Text;
            _controller.FiltrarProdutos(textoPesquisa);
        }

        /// <summary>
        /// Evento acionado ao clicar no botão para adicionar um novo produto.
        /// Abre um sub-form para adicionar um novo produto.
        /// </summary>
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            var addProdutoForm = new AddProdutoForm(this);
            addProdutoForm.ShowDialog();

        }


        /// <summary>
        /// Evento acionado ao clicar no botão para remover um produto.
        /// Remove o produto selecionado através da DataGridView.
        /// </summary>
        private void btnRemProduto_Click(object sender, EventArgs e)
        {

            // Tenta remover o produto selecionado
            try
            {
                int rowIndex = dgvProdutos.SelectedRows[0].Index; // Obtém o índice da linha selecionada
                Produto produtoSelecionado = (Produto)dgvProdutos.Rows[rowIndex].DataBoundItem; // Obtém o produto correspondente ao índice selecionado

                _controller.RemoveItem(produtoSelecionado); // Remove o produto usando o controlador
            }
            catch (ArgumentOutOfRangeException)
            {
                // Mensagem de erro se nenhum produto estiver selecionado
                MessageBox.Show("Selecione um produto para remover.");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção diferente
                MessageBox.Show($"Erro ao remover o produto: {ex.Message}");
            }
        }

        private void btnAddProduto_Enter(object sender, EventArgs e)
        {
            btnAddProduto.BackColor = Color.FromArgb(89, 209, 247);
        }

        private void btnAddProduto_Leave(object sender, EventArgs e)
        {
            btnAddProduto.BackColor = Color.FromArgb(13,170,220);
        }
    }
}
