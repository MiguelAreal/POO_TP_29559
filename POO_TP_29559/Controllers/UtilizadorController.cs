using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;

public class UtilizadorController : BaseController<Utilizador>, IEntityController
{
    public UtilizadorController() : base("Data/utilizadores.json") { }


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


    public new object GetById(int id){
        // Busca utilizador por ID e retorna como objeto
        return _repository.GetById(id);
    }

    public bool VerificarLogin(string username, string password)
    {
        var user = _repository.GetAll().FirstOrDefault(u => u.Nome == username);
        return user != null && user.Password == password;
    }




}
