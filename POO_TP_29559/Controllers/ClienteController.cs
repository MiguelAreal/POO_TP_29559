using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;

public class ClienteController : BaseController<Cliente, ClientesForm>
{
    public ClienteController(ClientesForm view)
        : base(view, "Data/clientes.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Cliente> clientes)
    {
        _view.MostraClientes(clientes);
    }


    public Cliente GetById(int id)
    {
        return _repository.GetById(id);
    }


    public void RemoveCliente(Cliente item)
    {
        RemoveItem(item);
    }

    protected override void RemoveItem(Cliente item)
    {
       /* if (item == null)
            throw new ArgumentNullException(nameof(item), "Produto não pode ser nulo.");*/

        _repository.Remove(item);
        CarregaItens();
    }


}
