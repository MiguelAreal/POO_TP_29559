using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;

namespace poo_tp_29559
{
    public partial class CategoriasForm : MetroForm
    {

        private readonly CategoriaController _controller;

        public CategoriasForm()
        {
            InitializeComponent();

            //_controller = new CategoriaController(this, new ProdutoRepo());
        }


        public void MostraCategorias(List<Categoria> categorias)
        {
            // Cria um BindingSource para associar à DGV lista de marcas
            // Esconde a coluna ID
            BindingSource bs = new BindingSource
            {
                DataSource = categorias
            };
            dgvCategorias.DataSource = bs;
            dgvCategorias.Refresh();

            dgvCategorias.Columns["Id"].Visible = false;
        }


        private void dgvCategorias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Tenta obter a marca editada com base na linha e coluna alteradas
            try
            {

                Categoria categoriaAlterada = (Categoria)dgvCategorias.Rows[e.RowIndex].DataBoundItem;
                //_controller.UpdateItem(categoriaAlterada);
            }
            // Trata o caso em que a linha ou coluna não é válida
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Selecione uma célula válida para editar.");
            }
            // Trata o caso em que a conversão do valor não é válida
            catch (InvalidCastException)
            {
                MessageBox.Show("Erro ao tentar atualizar a categoria. Verifique os dados.");
            }
        }


        private void btnRemCategoria_Click(object sender, EventArgs e)
        {
            // Tenta remover a categoria selecionada, através do índice da linha selecionada
            try
            {
                int rowIndex = dgvCategorias.SelectedRows[0].Index;
                Categoria categoriaSelecionada = (Categoria)dgvCategorias.Rows[rowIndex].DataBoundItem;
                //_controller.RemoveCategoria(categoriaSelecionada);
            }
            // Mensagem de erro se nenhuma categoria estiver selecionada
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Selecione uma categoria para remover.");
            }
            // Exibe uma mensagem de erro caso ocorra uma exceção diferente
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover a categoria: {ex.Message}");
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {

            // Abre form para adicionar nova categoria.
            var addCategoriaForm = new AddCategoriaForm(this);
            addCategoriaForm.ShowDialog();
        }
    }
}
