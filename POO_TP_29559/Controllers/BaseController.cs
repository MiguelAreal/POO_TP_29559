using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace poo_tp_29559.Controllers
{

    //Nesta classe genérica de controlador, a lógica comum de adicionar, remover, filtrar e carregar itens
    //é centralizada. Os controladores específicos só precisarão implementar a lógica de como exibir
    //os itens na view.

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

        // New method to initialize and load items
        public void Initialize()
        {
            CarregaItens();
        }


        // Carrega os itens e exibe na view
        public void CarregaItens()
        {
            _items = _repository.GetAll();
            ExibeItensNaView(_items);
        }

        // Filtra os itens e atualiza a view
        public void FiltrarItens(string filtro, System.Func<T, bool> filtroFunc)
        {
            var itensFiltrados = _items.Where(filtroFunc).ToList();
            ExibeItensNaView(itensFiltrados);
        }

        // Adiciona novo item e atualiza a view
        public void AddItem(T item)
        {
            _repository.Add(item);  
            CarregaItens();  
        }

        // Método para atualizar um produto
        public void UpdateItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item não pode ser nulo.");

            _repository.Update(item);
            CarregaItens(); // Recarrega os itens para atualizar a view
        }


        protected abstract void RemoveItem(T item);
        // Método abstrato para exibir os itens na view, implementado pelos controladores específicos
        protected abstract void ExibeItensNaView(List<T> items);
    }
}
