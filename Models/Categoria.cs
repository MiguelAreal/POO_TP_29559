﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Categoria
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Nome de Categoria")]
        public string? Nome { get; set; }

        [DisplayName("Nome de Categoria")]
        public string? Descricao { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

    }
}
