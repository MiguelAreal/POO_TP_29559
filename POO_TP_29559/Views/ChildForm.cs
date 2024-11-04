using MetroFramework.Forms;
using poo_tp_29559.Repositories.Enumerators;
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
    public partial class ChildForm : MetroForm
    {
        public FormTypes _formtype;
        public ChildForm(FormTypes formtype)
        {
            InitializeComponent();
            _formtype = formtype;
        }


    }
}
