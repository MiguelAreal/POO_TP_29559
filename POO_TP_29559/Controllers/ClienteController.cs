using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;

public class ClienteController : BaseController<Cliente, ChildForm>, IController<Cliente>
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


    public Cliente GetById(int id)
    {
        return _repository.GetById(id);
    }


    protected override void RemoveItem(Cliente item)
    {
        _repository.Remove(item);
    }


}
