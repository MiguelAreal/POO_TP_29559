using System.Collections.Generic;

public interface IController<T> where T : class, IIdentifiable
{
    void Initialize();
    void AddItem(T item);
    void DeleteItem(T item);
    T GetById(int id);
    void FiltrarItens(string filtro, Func<T, bool> filtroFunc);
}

