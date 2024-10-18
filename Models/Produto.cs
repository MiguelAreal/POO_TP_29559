using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public string? Marca { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmStock { get; set; }
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
