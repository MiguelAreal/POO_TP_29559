using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Campanha
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nome de Campanha")]
        public string? Nome { get; set; }

        [DisplayName("Percentagem de Desconto")]
        public string? PercentagemDesc { get; set; }

        [DisplayName("Data de Inicio")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data de Fim")]
        public DateTime DataFim { get; set; }

        // Associa a Campanha a uma Categoria
        [DisplayName("Categoria Aplicada")]
        public int CategoriaId { get; set; }


        //Propriedade de Navegação direta, para ter informações sobre a categoria através da campanha.
        public virtual Categoria? Categoria { get; set; }
    }
}
