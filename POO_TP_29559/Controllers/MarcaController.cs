using poo_tp_29559.Controllers;
using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class MarcaController : BaseController<Marca, ChildForm>, IController<Marca>
{
    public MarcaController(ChildForm view) : base(view, "Data/marcas.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Marca> marcas)
    {
        _view.MostraItens(marcas);
    }

    public void FiltrarItem(string filtro)
    {
        FiltrarItens(filtro, marca => marca.Nome != null && marca.Nome.ToLower().Contains(filtro.ToLower()));
    }

    //Verifica se a marca pode ser eliminada antes de o fazer.
    protected override void RemoveItem(Marca item)
    {
        var produtos = new ProdutoRepo().GetAll();

        if (item.PodeSerEliminada(produtos))
        {
            _repository.Remove(item);
        }
        else
        {
            MessageBox.Show("Esta marca não pode ser eliminada porque está associada a um ou mais produtos.");
        }
    }
}
