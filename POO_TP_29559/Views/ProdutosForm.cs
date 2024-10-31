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
            _controller = new ProdutoController(this, new CategoriaRepo(), new MarcaRepo());
        }

        /// <summary>
        /// Exibe a lista de produtos na DataGridView.
        /// </summary>
        /// <param name="produtos">A lista de produtos a ser exibida.</param>
        public void MostraProdutos(List<ProdutoViewModel> produtos)
        {
            BindingSource bs = new BindingSource
            {
                DataSource = produtos
            };
            dgvProdutos.DataSource = bs;
            dgvProdutos.Refresh();

            // Hide ID columns
            dgvProdutos.Columns["Id"].Visible = false;
        }




        /// <summary>
        /// Evento acionado quando o valor de uma célula na DataGridView é alterado.
        /// Atualiza a propriedade do produto correspondente na lista.
        /// </summary>
        /*private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
        }*/

        /// <summary>
        /// Evento acionado quando o texto na caixa de pesquisa é alterado.
        /// Filtra e exibe por nome de produto em tempo real com base na pesquisa.
        /// </summary>
        private void txtSearchProduto_TextChanged(object sender, EventArgs e)
        {
            _controller.FiltrarProdutos(txtSearchProduto.Text);
        }

        /// <summary>
        /// Evento acionado ao clicar no botão para adicionar um novo produto.
        /// Abre um sub-form para adicionar um novo produto.
        /// </summary>
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            //Abre form para adicionar novo produto.
            using (var addProdutoForm = new AddProdutoForm(this))
            {
                addProdutoForm.ShowDialog();
               
            }

            //Recarrega itens após fechar janela de adição de produto.
            _controller.CarregaItens();


        }


        /// <summary>
        /// Evento acionado ao clicar no botão para remover um produto.
        /// Remove o produto selecionado através da DataGridView.
        /// </summary>
        private void btnRemProduto_Click(object sender, EventArgs e)
        {
           
                if (dgvProdutos.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvProdutos.SelectedRows[0].Index; // Get the selected row index
                    ProdutoViewModel produtoSelecionado = (ProdutoViewModel)dgvProdutos.Rows[rowIndex].DataBoundItem; // Get the selected `ProdutoViewModel`

                    // Use the controller to get the actual `Produto` by ID
                    var produto = _controller.GetById(produtoSelecionado.Id); // Fetch `Produto` using its ID

                    _controller.RemoveProduto(produto); // Call the controller's remove method
                    _controller.CarregaItens(); // Refresh the list after deletion
                }
                else
                {
                    MessageBox.Show("Selecione um produto para remover.");
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
