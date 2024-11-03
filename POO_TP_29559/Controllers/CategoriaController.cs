using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CategoriaController : BaseController<Categoria, CategoriasForm>
{
    private readonly ProdutoRepo _produtoRepo;

    public CategoriaController(CategoriasForm view, ProdutoRepo produtoRepo) : base(view, "Data/categorias.json")
    {
        _produtoRepo = produtoRepo;
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

    public void RemoveCategoria(Categoria item)
    {
        RemoveItem(item);
    }

    protected override void RemoveItem(Categoria item)
    {
        var produtos = _produtoRepo.GetAll();

        if (item.PodeSerEliminada(produtos))
        {
            _repository.Remove(item);
            CarregaItens();
        }
        else
        {
            MessageBox.Show("Esta categoria não pode ser eliminada porque está associada a um ou mais produtos.");
        }
    }


}
