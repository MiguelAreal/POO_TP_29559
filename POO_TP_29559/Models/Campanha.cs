using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Campanha : IIdentifiable
    {
        public int Id { get; set; }

        [DisplayName("Nome de Campanha")]
        public string? Nome { get; set; }

        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }

        [DisplayName("Data de Inicio")]
        public string? DataInicio { get; set; }

        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }

        // Associa a Campanha a uma Categoria Específica
        [DisplayName("Categoria Aplicada")]
        public int CategoriaId { get; set; }

    }
}
