using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Views;
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
    public partial class CategoriasForm : MetroForm
    {

        private readonly CategoriaController _controller;

        public CategoriasForm()
        {
            InitializeComponent();

            _controller = new CategoriaController(this);
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



        private void btnAddMarca_Click(object sender, EventArgs e)
        {

            // Abre form para adicionar nova categoria.
            var addCategoriaForm = new AddCategoriaForm(this);
            addCategoriaForm.ShowDialog();
        }
    }
}
