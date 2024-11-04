using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
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
           // _controller = new MarcaController(this, new ProdutoRepo());
        }

        public void MostraMarcas(List<Marca> marcas)
        {
            // Cria um BindingSource para associar à DGV lista de marcas
            // Esconde a coluna ID
            BindingSource bs = new BindingSource
            {
                DataSource = marcas
            };
            dgvMarcas.DataSource = bs;
            dgvMarcas.Refresh();

            dgvMarcas.Columns["Id"].Visible = false;
        }


        private void btnRemMarca_Click(object sender, EventArgs e)
        {
            // Tenta remover a marca selecionada, através do índice da linha selecionada
            try
            {
                int rowIndex = dgvMarcas.SelectedRows[0].Index;
                Marca produtoSelecionado = (Marca)dgvMarcas.Rows[rowIndex].DataBoundItem;
                _controller.DeleteItem(produtoSelecionado);
            }
            // Mensagem de erro se nenhuma marca estiver selecionada
            catch (IndexOutOfRangeException)
            {

                MessageBox.Show("Selecione uma marca para remover.");
            }
            // Exibe uma mensagem de erro caso ocorra uma exceção diferente
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao remover a marca: {ex.Message}");
            }
        }

        private void dgvMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Tenta obter a marca editada com base na linha e coluna alteradas
            try
            {

                Marca marcaAlterada = (Marca)dgvMarcas.Rows[e.RowIndex].DataBoundItem;
                //_controller.UpdateItem(marcaAlterada);
            }
            // Trata o caso em que a linha ou coluna não é válida
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Selecione uma célula válida para editar.");
            }
            // Trata o caso em que a conversão do valor não é válida
            catch (InvalidCastException)
            {
                MessageBox.Show("Erro ao tentar atualizar o produto. Verifique os dados.");
            }
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            // Abre form para adicionar nova categoria.
            /*var addMarcaForm = new AddMarcaForm(this);
            addMarcaForm.ShowDialog();*/
        }

        
    }
}
