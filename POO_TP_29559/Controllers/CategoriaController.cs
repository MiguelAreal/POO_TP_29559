using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CategoriaController : BaseController<Categoria, ChildForm>, IController<Categoria>
{
    public CategoriaController(ChildForm view) : base(view, "Data/categorias.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Categoria> categorias)
    {
        _view.MostraItens(categorias);
    }

    public void FiltrarItens(string filtro)
    {
        FiltrarItens(filtro, Categoria => Categoria.Nome != null && Categoria.Nome.ToLower().Contains(filtro.ToLower()));
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


}
