
using poo_tp_29559.Models;
using System.ComponentModel;

namespace poo_tp_29559.Controllers
{
    public abstract class BaseController<T, TView> where T : class, IIdentifiable
    {
        protected readonly TView _view;
        protected readonly BaseRepo<T> _repository;
        protected List<T> _items;

        public BaseController(TView view, string filePath)
        {
            _view = view;
            _repository = new BaseRepo<T>(filePath);
        }

        public void Initialize()
        {
            CarregaItens();
        }

        public void CarregaItens()
        {
            _items = _repository.GetAll();
            ExibeItensNaView(_items);
        }

        // Filtra itens com consulta LINQ dado texto a pesquisar e propriedade (filtro) a usar.
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

            ExibeItensNaView(itensFiltrados);
        }

        public void AddItem(T item)
        {
            _repository.Add(item);
            CarregaItens();
        }

        // Implementation of DeleteItem directly within the BaseController
        public void DeleteItem(object item)
        {
            if (item is T specificItem)
            {
                RemoveItem(specificItem);
                CarregaItens();
            }
            else
            {
                throw new InvalidOperationException("Invalid item type for deletion.");
            }
        }

        // Implementation of UpdateItem directly within the BaseController
        public void UpdateItem(object item)
        {
            if (item is T specificItem)
            {
                UpdateItem(specificItem);
                CarregaItens();
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

        // Mapeia DisplayName a PropertyName para modelo (Traduz)
        public Dictionary<string, string> GetColumnPropertyMappings()
        {
            var mappings = new Dictionary<string, string>();

            foreach (var prop in typeof(T).GetProperties())
            {
                var displayNameAttr = (DisplayNameAttribute?)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));
                string displayName = displayNameAttr != null ? displayNameAttr.DisplayName : prop.Name;
                mappings[displayName] = prop.Name;
            }

            return mappings;
        }



        protected abstract void RemoveItem(T item);
        protected abstract void UpdateItem(T item);
        protected abstract void ExibeItensNaView(List<T> items);
    }
}