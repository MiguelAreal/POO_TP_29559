using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class MarcaController : BaseController<Marca>, IEntityController
{
    public MarcaController() : base("Data/marcas.json") { }

    public override object GetItems()
    {
        return _repository.GetAll();
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

    protected override void UpdateItem(Marca item)
    {
        _repository.Update(item);
    }

   
}
