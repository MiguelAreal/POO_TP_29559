using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CategoriaController : BaseController<Categoria>, IEntityController
{
    public CategoriaController() : base("Data/categorias.json") { }

    public override object GetItems()
    {
        return _repository.GetAll();
    }

    public override void RemoveItem(Categoria item)
    {
        var produtos = new ProdutoRepo().GetAll();

        if (item.PodeSerEliminada(produtos))
        {
            _repository.Remove(item);
        }
        else
        {
            MessageBox.Show("Esta categoria não pode ser eliminada porque está associada a um ou mais produtos.");
        }
    }


}
