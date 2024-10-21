using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Marca
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nome da Marca")]
        public string? Nome { get; set; }

        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("País de Origem")]
        public string? PaisOrigem { get; set; }

        // Construtor
        public Marca()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
