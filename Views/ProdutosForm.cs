using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poo_tp_29559
{
    public partial class ProdutosForm : MetroForm
    {

        private readonly ProdutoController _controller;

        public ProdutosForm()
        {
            InitializeComponent();
            _controller = new ProdutoController(this);
        }

        public void MostraProdutos(List<Produto> produtos)
        {
            // Cria um BindingSource para associar à DGV lista de produtos
            BindingSource bs = new BindingSource();
            bs.DataSource = produtos;
            dgvProdutos.DataSource = bs;

        }


        private void btnSearchProduto_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtSearchProduto.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                // Obtém o índice
                int rowIndex = dgvProdutos.SelectedRows[0].Index;

                // Obtém o produto correspondente ao índice selecionado
                Produto produtoSelecionado = (Produto)dgvProdutos.Rows[rowIndex].DataBoundItem;

                // Remove o produto
                _controller.RemProduto(produtoSelecionado);
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover.");
            }
        }

        private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha editada é válida
            if (e.RowIndex >= 0)
            {
                // Obtém o produto editado
                Produto produtoAlterado = (Produto)dgvProdutos.Rows[e.RowIndex].DataBoundItem;

                // Chama a função no controlador para guardar as alterações
                _controller.UpdProduto(produtoAlterado);
            }
        }

        private void txtSearchProduto_TextChanged(object sender, EventArgs e)
        {
            // Obtém o texto que está a ser escrito no TextBox
            string textoPesquisa = txtSearchProduto.Text;

            // Chama o controlador para filtrar e mostrar os produtos em tempo real.
            _controller.FiltrarProdutos(textoPesquisa);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Criar um novo produto a partir dos dados dos controles
            var novoProduto = new Produto
            {
                Nome = "Produto",
                Categoria = "Categoria",
                Marca = "Marca",
                Preco = 0,
            };

            // Adiciona o novo produto através do controlador
            _controller.AddProduto(novoProduto);
        }
    }
}
