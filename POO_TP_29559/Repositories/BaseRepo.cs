using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using poo_tp_29559.Interfaces;


// Interface para ter a certeza que as classes possuem um campo Id
public interface IIdentifiable
{
    int Id { get; set; }
}

public class BaseRepo<T> : IRepo<T> where T : class, IIdentifiable
{
    protected readonly string filePath;
    protected List<T> items;

    public BaseRepo(string filePath)
    {
        this.filePath = filePath;
        items = LoadItems();
    }

    private List<T> LoadItems()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            
            var options = new JsonSerializerOptions
            {
                IncludeFields = true, // Inclui campos (não apenas propriedades) na desserialização
                PropertyNameCaseInsensitive = true // Permite nomes de propriedades insensíveis a maiúsculas/minúsculas
            };

            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();

        }
        else
        {
            return new List<T>();
        }
    }

    public List<T> GetAll()
    {
        items = LoadItems();
        return items;
    }

    public virtual void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item não pode ser null.");

        SetId(item);
        items.Add(item);
        SaveChanges();
    }

    public virtual void Remove(T item)
    {
        items.Remove(item);
        SaveChanges();
    }

    public virtual void Update(T itemAlterado)
    {
        // Buscar item real através do ID a ser atualizado e altera a partir daí 
        if (itemAlterado == null)
            throw new ArgumentNullException(nameof(itemAlterado), "Item não pode ser null.");

        var index = items.FindIndex(item => item.Id == itemAlterado.Id);

        if (index != -1)
        {
            items[index] = itemAlterado;
            SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Item não encontrado.");
        }
    }

    protected int GetId(T item)
    {
        return item.Id;
    }

    protected void SetId(T item)
    {
        item.Id = GetProximoId();
    }

    private int GetProximoId()
    {
        if (items.Count == 0)
        {
            return 1;
        }
        return items.Max(item => item.Id) + 1;
    }

    /// <summary>
    /// Devolve um item através do ID.
    /// </summary>
    /// <param name="id">O ID do item para pesquisar.</param>
    /// <returns>O item se encontrado; caso contrário, null.</returns>
    public virtual T GetById(int? id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }


    protected void SaveChanges()
    {
        string? directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

}