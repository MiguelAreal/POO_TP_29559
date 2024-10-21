using poo_tp_29559.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace poo_tp_29559.Repositories
{
    public class ProdutoRepo
    {
        private readonly string filePath = "Data/produtos.json";
        private List<Produto> produtos;

        // Construtor carrega produtos apenas uma vez
        public ProdutoRepo()
        {
            produtos = CarregarProdutos();
        }

        // Lê todos os produtos do ficheiro (só uma vez)
        private List<Produto> CarregarProdutos()
        {
            // Verifica se o ficheiro existe.
            // Se não existir, retorna uma lista vazia.
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Produto>>(json)!;
            }
            else
            {
                return new List<Produto>();
            }
        }

        // Retorna todos os produtos carregados
        public List<Produto> GetProdutos()
        {
            return produtos;
        }

        // Retorna o próximo ID disponível, para auxíliar em AddProduto
        private int GetProximoId()
        {
            if (produtos.Count == 0)
            {
                return 1;
            }
            return produtos[^1].Id + 1;
        }

        // Adiciona um novo produto à lista e depois guarda no ficheiro
        public void AddProduto(Produto produto)
        {
            produto.Id = GetProximoId();
            produtos.Add(produto);
            GuardarProdutos();
        }

        // Remove um produto à lista e depois guarda no ficheiro
        public void RemProduto(Produto produto)
        {
            produtos.Remove(produto);
            GuardarProdutos();
        }

        // Altera um produto e guarda no ficheiro
        public void UpdProduto(Produto produtoAlterado)
        {
            // Consulta LINQ com Expressão Lambda
            // Encontra o produto original pela ID do mesmo e substitui as suas propriedades
            Produto? produtoOriginal = produtos.FirstOrDefault(p => p.Id == produtoAlterado.Id);

            if (produtoOriginal != null)
            {
                produtoOriginal.Nome = produtoAlterado.Nome;
                produtoOriginal.Categoria = produtoAlterado.Categoria;
                produtoOriginal.Preco = produtoAlterado.Preco;
                produtoOriginal.QuantidadeEmStock = produtoAlterado.QuantidadeEmStock;
                produtoOriginal.Marca = produtoAlterado.Marca;

                GuardarProdutos();
            }
        }

        // Guarda a lista de produtos no ficheiro
        private void GuardarProdutos()
        {
            // Verifica se a pasta existe. Se não, cria-a.
            string? directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Se o ficheiro não existir, ele cria automaticamente.
            string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
