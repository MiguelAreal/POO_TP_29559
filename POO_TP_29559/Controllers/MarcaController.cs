using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class MarcaController : BaseController<Marca, MarcasForm>
{
    public MarcaController(MarcasForm view) : base(view, "Data/marcas.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Marca> marcas)
    {
        _view.MostraMarcas(marcas);
    }

    public void FiltrarMarcas(string filtro)
    {
        FiltrarItens(filtro, marca => marca.Nome != null && marca.Nome.ToLower().Contains(filtro.ToLower()));
    }

    public void RemoveMarca(Marca item)
    {
        RemoveItem(item);
    }

    protected override void RemoveItem(Marca item)
    {
        _repository.Remove(item);
        CarregaItens();
    }
}
