using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Produto
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nome do Produto")]
        public string? Nome { get; set; }

        [DisplayName("Categoria")]
        public string? Categoria { get; set; }

        [DisplayName("Marca")]
        public string? Marca { get; set; }

        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [DisplayName("Stock")]
        public int QuantidadeEmStock { get; set; }

        [DisplayName("Meses de Garantia")]
        public int GarantiaMeses { get; set; }

        // Construtor
        public Produto()
        {
            // Por defeito, a garantia de um produto é de 3 anos
            GarantiaMeses = 36;
            QuantidadeEmStock = 0;
        }

    }
}
