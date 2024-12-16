public abstract class BaseController<T> where T : class, IIdentifiable
{
    protected readonly BaseRepo<T> _repository;
    protected List<T> _items;

    public BaseController(string filePath) => _repository = new BaseRepo<T>(filePath);

    public void FiltrarItens(string filtro, string coluna)
    {
        var itensFiltrados = _items.Where(model =>
        {
            if (string.IsNullOrEmpty(coluna)) return false;

            var prop = model.GetType().GetProperty(coluna);
            if (prop != null)
            {
                var value = prop.GetValue(model)?.ToString() ?? string.Empty;
                return value.Contains(filtro, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }).ToList();
    }

    public void AddItem(T item)
    {
        _repository.Add(item);
        GetItems();
    }

    public void DeleteItem(object item)
    {
        if (item is T specificItem)
        {
            RemoveItem(specificItem);
            GetItems();
        }
        else
        {
            throw new InvalidOperationException("Invalid item type for deletion.");
        }
    }

    public void UpdateItem(object item)
    {
        if (item is T specificItem)
        {
            UpdateItem(specificItem);
            GetItems();
        }
        else
        {
            throw new InvalidOperationException("Invalid item type for deletion.");
        }
    }

    public object GetById(int id)
    {
        return _repository.GetById(id);
    }

    protected abstract void RemoveItem(T item);
    protected abstract void UpdateItem(T item);
    public abstract object GetItems();
}
