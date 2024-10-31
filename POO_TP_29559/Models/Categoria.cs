

using poo_tp_29559.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Categoria : IIdentifiable
    {

        public int Id { get; set; }

        [DisplayName("Nome")]
        public string? Nome { get; set; }

        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }


        // Método para verificar se a categoria pode ser eliminada
        // Só pode ser eliminada se a categoria não tiver em nenhum produto.
        public bool PodeSerEliminada(List<Produto> produtos)
        {
            return !produtos.Any(p => p.CategoriaID == this.Id);
        }

    }


}
