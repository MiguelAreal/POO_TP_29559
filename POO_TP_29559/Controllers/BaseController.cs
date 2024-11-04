
namespace poo_tp_29559.Controllers
{
    public abstract class BaseController<T, TView> : IController<T> where T : class, IIdentifiable
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

        public void FiltrarItens(string filtro, System.Func<T, bool> filtroFunc)
        {
            var itensFiltrados = _items.Where(filtroFunc).ToList();
            ExibeItensNaView(itensFiltrados);
        }

        public void AddItem(T item)
        {
            _repository.Add(item);
            CarregaItens();
        }

        public void DeleteItem(T item)
        {
            RemoveItem(item);
            CarregaItens();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        protected abstract void RemoveItem(T item);
        protected abstract void ExibeItensNaView(List<T> items);
    }
}