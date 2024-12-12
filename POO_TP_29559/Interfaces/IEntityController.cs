using System.Collections.Generic;


public interface IEntityController
{
    void FiltrarItens(string searchText, string activeColumn);
    object GetById(int id);
    void DeleteItem(object item);
    void UpdateItem(object item);
    object GetItems();
}
