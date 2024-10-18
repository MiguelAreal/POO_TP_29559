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

        // Atualiza a UI com os dados do modelo
        public void MostraProdutos(List<Produto> produtos)
        {
            // Limpa o DataGridView antes de adicionar novos dados
            dgvProdutos.DataSource = null;
            dgvProdutos.Rows.Clear();

            // Define a fonte de dados como a lista de produtos
            dgvProdutos.DataSource = produtos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Criar um novo produto a partir dos dados dos controles
            var novoProduto = new Produto
            {
                Nome = "Produto",
                Categoria = "Categoria",
                Marca = "Marca",
                Preco = 0,
                QuantidadeEmStock = 0,
                GarantiaMeses = 1
            };

            // Adiciona o novo produto através do controlador
            _controller.AddProduto(novoProduto);

        }
    }
}
