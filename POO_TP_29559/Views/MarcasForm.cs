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

namespace poo_tp_29559.Views
{
    public partial class MarcasForm : MetroForm
    {

        private readonly MarcaController _controller;

        public MarcasForm()
        {
            InitializeComponent();
            _controller = new MarcaController(this);
        }

        public void MostraMarcas(List<Marca> marcas)
        {
            // Cria um BindingSource para associar à DGV lista de produtos
            BindingSource bs = new BindingSource();
            bs.DataSource = marcas;
            dgvMarcas.DataSource = bs;

        }

        private void btnAddMarca_Click(object sender, EventArgs e)
        {
            var novaMarca = new Marca
            {
                Nome = "Marca",
                Descricao = "Descricao",
                PaisOrigem = "Portugal"
            };

            // Adiciona a nova marca através do controlador
            _controller.AddItem(novaMarca);
        }

        private void btnRemMarca_Click(object sender, EventArgs e)
        {
            // Tenta remover a marca selecionada, através do índice da linha selecionada
            try
            {
                int rowIndex = dgvMarcas.SelectedRows[0].Index;
                Marca produtoSelecionado = (Marca)dgvMarcas.Rows[rowIndex].DataBoundItem;
                _controller.RemoveItem(produtoSelecionado);
            }
            catch (IndexOutOfRangeException)
            {
                // Mensagem de erro se nenhuma marca estiver selecionada
                MessageBox.Show("Selecione uma marca para remover.");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção diferente
                MessageBox.Show($"Erro ao remover a marca: {ex.Message}");
            }
        }

        private void dgvMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Tenta obter a marca editada com base na linha e coluna alteradas
                Marca marcaAlterada = (Marca)dgvMarcas.Rows[e.RowIndex].DataBoundItem;
                _controller.UpdateItem(marcaAlterada);
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

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            var addMarcaForm = new AddMarcaForm(this);
            addMarcaForm.ShowDialog();
        }
    }
}
