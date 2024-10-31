using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CategoriaController : BaseController<Categoria, CategoriasForm>
{
    public CategoriaController(CategoriasForm view) : base(view, "Data/categorias.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Categoria> categorias)
    {
        _view.MostraCategorias(categorias);
    }

    public void FiltrarCategorias(string filtro)
    {
        FiltrarItens(filtro, Categoria => Categoria.Nome != null && Categoria.Nome.ToLower().Contains(filtro.ToLower()));
    }

    protected override void RemoveItem(Categoria item)
    {
        _repository.Remove(item);
        CarregaItens();
    }


}
