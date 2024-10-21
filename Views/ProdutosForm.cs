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


            // Verifica se a coluna de botão já foi adicionada para evitar duplicação
            if (dgvProdutos.Columns["btnEliminar"] == null)
            {
                // Cria uma coluna de botões
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "btnEliminar";
                btnEliminar.HeaderText = " "; // Título da coluna
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true; // Faz com que o texto seja sempre o mesmo

                // Adiciona a coluna ao DataGridView
                dgvProdutos.Columns.Add(btnEliminar);
            }
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

        private void btnSearchProduto_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtSearchProduto.Text);
        }

    }
}
