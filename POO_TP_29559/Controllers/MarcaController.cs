using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class MarcaController : BaseController<Marca, MarcasForm>
{
    private readonly ProdutoRepo _produtoRepo;

    public MarcaController(MarcasForm view, ProdutoRepo produtoRepo) : base(view, "Data/marcas.json")
    {
        _produtoRepo = produtoRepo;
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
        var produtos = _produtoRepo.GetAll();

        // Check if the brand can be deleted
        if (item.PodeSerEliminada(produtos))
        {
            _repository.Remove(item);
            CarregaItens();
        }
        else
        {
            // Handle the case where the brand cannot be deleted
            MessageBox.Show("Esta marca não pode ser eliminada porque está associada a um ou mais produtos.");
        }
    }
}
