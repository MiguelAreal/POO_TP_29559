using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;

public class ClienteController : BaseController<Cliente, ChildForm>, IEntityController
{
    public ClienteController(ChildForm view)
        : base(view, "Data/clientes.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Cliente> clientes)
    {
        _view.MostraItens(clientes);
    }

    protected override void RemoveItem(Cliente item)
    {
        _repository.Remove(item);
    }

    // Implement the GetById method from IEntityController
    public object GetById(int id)
    {
        // Get the Cliente by its ID and return it as an object
        return _repository.GetById(id); // Ensure your BaseRepo<T>.GetById returns a Cliente
    }




}
