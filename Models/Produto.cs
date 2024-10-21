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

        // Adiciona ao stock existente do produto.
        public void AdicionarStock(int quantidade)
        {
            QuantidadeEmStock += quantidade;
        }

        // Remove de stock a quantidade passada por parâmetro.
        // Apenas se esta for menor que a quantidade disponível (para não ficar negativo)
        public void RemoverStock(int quantidade)
        {
            if (QuantidadeEmStock >= quantidade)
                QuantidadeEmStock -= quantidade;
        }

        // Atualiza os detalhes sobre um produto
        public void AtualizarDetalhes(string nome, string categoria, string marca, decimal preco)
        {
            Nome = nome;
            Categoria = categoria;
            Marca = marca;
            Preco = preco;
        }

        // Método que calcula o desconto, consoante passado por parâmetro
        public decimal AplicarDesconto(decimal percentDisconto)
        {
            return Preco - (Preco * percentDisconto / 100);
        }
    }
}
