using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public class UtilizadorController : BaseController<Utilizador>, IEntityController
{
    protected new UtilizadorRepo _repository;

    public UtilizadorController() : base("Data/utilizadores.json")
    {
        _repository = new UtilizadorRepo();
    }

    public override object GetItems()
    {
        return _repository.GetAll();
    }

    protected override void RemoveItem(Utilizador item)
    {
        _repository.Remove(item);
    }

    protected override void UpdateItem(Utilizador item)
    {
        _repository.Update(item);
    }

    public new object GetById(int id)
    {
        return _repository.GetById(id);
    }

    public bool VerificarLogin(int nif, string password)
    {
        var user = ObterUtilizadorPorNIF(nif);
        return user != null && user.Password == password;
    }

    public bool VerificarNIFExistente(int nif)
    {
        var user = ObterUtilizadorPorNIF(nif); // Busca o utilizador com o NIF fornecido
        return user != null; // Retorna true se o utilizador foi encontrado, caso contrário, false
    }

    public bool VerificarContactoExistente(string contacto)
    {
        var user = ObterUtilizadorPorContacto(contacto);
        return user != null; // Retorna true se o utilizador foi encontrado, caso contrário, false
    }


    public Utilizador? ObterUtilizadorPorNIF(int nif)
    {
        return _repository.ObterPorNIF(nif);
    }

    public Utilizador? ObterUtilizadorPorContacto(string contacto)
    {
        return _repository.ObterPorContacto(contacto);
    }

    // Obtém todos os clientes não administradores
    public List<Utilizador> GetClientes()
    {
       var clientes = _repository.GetAllClientes();
       return clientes.OrderBy(c => c.Nome).ToList();

    }

    public Utilizador GetById(int? clienteID)
    {
        return _repository.GetById(clienteID);
    }
}
