using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class ItemVenda
    {
        [DisplayName("Produto")]
        public Produto Produto { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        public ItemVenda(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
    }
}
