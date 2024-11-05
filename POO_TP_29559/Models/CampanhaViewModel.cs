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
    /// Através da classe original Campanha, esta é utilizada para exibir ao utilizador o nome da categoria a que a campanha se destina.
    /// 
    /// </summary>
    public class CampanhaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }
        [DisplayName("Data de Início")]
        public string? DataInicio { get; set; }
        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }
        [DisplayName("Categoria Aplicada")]
        public string? CategoriaNome { get; set; }

    }
}
