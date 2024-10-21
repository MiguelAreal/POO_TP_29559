using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Cliente
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nome de Cliente")]
        public string? Nome { get; set; }

        [DisplayName("Contacto")]
        public string? Contacto { get; set; }

        [DisplayName("Localização")]
        public string? Localizacao { get; set; }

        [DisplayName("País")]
        public string? Pais { get; set; }

        [DisplayName("NIF")]
        public string? Nif { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        // Construtor
        public Cliente()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
