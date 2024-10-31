using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Classe que tem como objetivo ser a que é exibida ao utilizador.
    /// Através da classe original Produto, esta é utilizada para exibir ao utilizador o nome da categoria e marca.
    /// 
    /// </summary>
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        [DisplayName("Stock")]
        public int QuantidadeEmStock { get; set; }
        [DisplayName("Categoria")]
        public string? CategoriaNome { get; set; }
        [DisplayName("Marca")]
        public string? MarcaNome { get; set; }
        [DisplayName("Data de Adição")]
        public string? DataAdicao { get; set; }
    }
}
