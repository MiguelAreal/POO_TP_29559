using poo_tp_29559.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace poo_tp_29559.Repositories
{
    public class MarcaRepo
    {
        private readonly string filePath = "Data/marcas.json";
        private List<Marca> marcas;

        // Construtor carrega produtos apenas uma vez
        public MarcaRepo()
        {
            marcas = CarregarMarcas();
        }

        // Lê todos os produtos do ficheiro (só uma vez)
        private List<Marca> CarregarMarcas()
        {
            // Verifica se o ficheiro existe.
            // Se não existir, retorna uma lista vazia.
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Marca>>(json)!;
            }
            else
            {
                return new List<Marca>();
            }
        }

        // Retorna todos as marcas carregados
        public List<Marca> GetMarcas()
        {
            return marcas;
        }

        // Retorna o próximo ID disponível, para auxíliar em AddMarca
        private int GetProximoId()
        {
            if (marcas.Count == 0)
            {
                return 1;
            }
            return marcas[^1].Id + 1;
        }

        // Adiciona uma nova marca à lista e depois guarda no ficheiro
        public void AddMarca(Marca marca)
        {
            marca.Id = GetProximoId();
            marcas.Add(marca);
            GuardarMarcas();
        }

        // Remove uma marca à lista e depois guarda no ficheiro
        public void RemMarca(Marca marca)
        {
            marcas.Remove(marca);
            GuardarMarcas();
        }

        // Altera uma marca e guarda no ficheiro
        public void UpdMarca(Marca marcaAlterada)
        {
            // Consulta LINQ com Expressão Lambda
            // Encontra a marca original pela ID do mesmo e substitui as suas propriedades
            Marca? marcaOriginal = marcas.FirstOrDefault(p => p.Id == marcaAlterada.Id);

            if (marcaOriginal != null)
            {
                marcaOriginal.Nome = marcaOriginal.Nome;
                marcaOriginal.Descricao = marcaOriginal.Descricao;
                marcaOriginal.PaisOrigem = marcaOriginal.PaisOrigem;

                GuardarMarcas();
            }
        }

        // Guarda a lista de marcas no ficheiro
        private void GuardarMarcas()
        {
            // Verifica se a pasta existe. Se não, cria-a.
            string? directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Se o ficheiro não existir, ele cria automaticamente.
            string json = JsonSerializer.Serialize(marcas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
