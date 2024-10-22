using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using poo_tp_29559.Repositories.Interfaces;

public abstract class BaseRepo<T> : IRepo<T> where T : class
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
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        else
        {
            return new List<T>();
        }
    }

    public List<T> GetAll()
    {
        return items;
    }

    public virtual void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");

        SetId(item);
        items.Add(item);
        SaveChanges();
    }

    public virtual void Remove(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");

        items.Remove(item);
        SaveChanges();
    }

    public virtual void Update(T itemAlterado)
    {
        if (itemAlterado == null)
            throw new ArgumentNullException(nameof(itemAlterado), "Item não pode ser null.");

        var originalItem = FindById(GetId(itemAlterado));

        if (originalItem != null)
        {
            UpdateProperties(originalItem, itemAlterado);
            SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Item não encontrado.");
        }
    }

    protected abstract void SetId(T item);
    protected abstract int GetId(T item);
    protected abstract void UpdateProperties(T original, T updated);

    protected void SaveChanges()
    {
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    private T FindById(int id)
    {
        return items.FirstOrDefault(item => GetId(item) == id);
    }
}
