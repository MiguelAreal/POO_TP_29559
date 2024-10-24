using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Venda
    {
            [Browsable(false)]
            public int Id { get; set; }

            [DisplayName("Cliente")]
            public Cliente? Cliente { get; set; }

            [DisplayName("Produtos Vendidos")]
            public List<Produto>? Produtos { get; set; }

            [DisplayName("Quantidade Total de Produtos")]
            public int Quantidade { get; set; }

            [DisplayName("Percentagem Descontada")]
            public int Percentagem { get; set; }

            [DisplayName("Preço Total")]
            public decimal PrecoTotal { get; set; }

            [DisplayName("Data da Venda")]
            public DateTime DataVenda { get; set; }

            [DisplayName("Método de Pagamento")]
            public string? MetodoPagamento { get; set; }

            // Construtor
            public Venda()
            {
                Percentagem = 0;
                DataVenda = DateTime.Now;
            }

    }
}
