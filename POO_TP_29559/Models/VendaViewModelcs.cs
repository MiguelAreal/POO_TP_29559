using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class VendaViewModel
    {
        public int Id { get; set; }

        [DisplayName("Cliente")]
        public string? ClienteNome { get; set; }

        [DisplayName("NIF")]
        public string? NIF { get; set; }

        [DisplayName("Data de Venda")]
        public string? DataVenda { get; set; }

        [DisplayName("Preço Total")]
        public decimal PrecoTotal { get; set; }

        [DisplayName("Método de Pagamento")]
        public string? MetodoPagamento { get; set; }

        [DisplayName("Meses de Garantia")]
        public int GarantiaMeses { get; set; }

        [DisplayName("Meses Restantes de Garantia")]
        public int GarantiaRestanteMeses { get; set; }
    }

}
