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
    }
}
