using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CategoriaController : BaseController<Categoria, ChildForm>, IEntityController
{
    public CategoriaController(ChildForm view) : base(view, "Data/categorias.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Categoria> categorias)
    {
        _view.MostraItens(categorias);
    }

    protected override void RemoveItem(Categoria item)
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

    protected override void UpdateItem(Categoria item)
    {
        _repository.Remove(item);
    }

}
