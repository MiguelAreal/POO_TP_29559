using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System.Collections.Generic;
using System.Linq;

public class UtilizadorController : BaseController<Utilizador>, IEntityController
{
    #region Fields

    /// <summary>
    /// Repositório específico para a gestão de utilizadores.
    /// </summary>
    protected new UtilizadorRepo _repository;

    #endregion

    #region Constructor

    /// <summary>
    /// Construtor da classe <see cref="UtilizadorController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde os utilizadores são armazenados.
    /// </summary>
    public UtilizadorController() : base("Data/utilizadores.json")
    {
        _repository = new UtilizadorRepo();
    }

    #endregion

    #region Get Items

    /// <summary>
    /// Obtém todos os utilizadores armazenados.
    /// </summary>
    /// <returns>Uma lista de objetos representando os utilizadores armazenados.</returns>
    public override List<object> GetItems()
    {
        _items = _repository.GetAll();
        return _items.Cast<object>().ToList();
    }

    #endregion

    #region Verifications

    /// <summary>
    /// Verifica se o login do utilizador é válido com base no NIF e na palavra-passe fornecidos.
    /// </summary>
    /// <param name="nif">O NIF do utilizador.</param>
    /// <param name="password">A palavra-passe do utilizador.</param>
    /// <returns><c>true</c> se o login for válido; caso contrário, <c>false</c>.</returns>
    public bool VerificarLogin(int nif, string password)
    {
        var user = ObterUtilizadorPorNIF(nif);
        return user != null && user.Password == password;
    }

    /// <summary>
    /// Verifica se o NIF fornecido já está registado.
    /// </summary>
    /// <param name="nif">O NIF do utilizador.</param>
    /// <returns><c>true</c> se o NIF já estiver registado; caso contrário, <c>false</c>.</returns>
    public bool VerificarNIFExistente(int nif)
    {
        var user = ObterUtilizadorPorNIF(nif);
        return user != null;
    }

    /// <summary>
    /// Verifica se o contacto fornecido já está registado.
    /// </summary>
    /// <param name="contacto">O contacto do utilizador.</param>
    /// <returns><c>true</c> se o contacto já estiver registado; caso contrário, <c>false</c>.</returns>
    public bool VerificarContactoExistente(string contacto)
    {
        var user = ObterUtilizadorPorContacto(contacto);
        return user != null;
    }

    #endregion

    #region Get Specific User

    /// <summary>
    /// Obtém um utilizador específico pelo seu NIF.
    /// </summary>
    /// <param name="nif">O NIF do utilizador a ser recuperado.</param>
    /// <returns>O utilizador correspondente ao NIF fornecido, ou <c>null</c> se não encontrado.</returns>
    public Utilizador? ObterUtilizadorPorNIF(int nif)
    {
        return _repository.ObterPorNIF(nif);
    }

    /// <summary>
    /// Obtém um utilizador específico pelo seu contacto.
    /// </summary>
    /// <param name="contacto">O contacto do utilizador a ser recuperado.</param>
    /// <returns>O utilizador correspondente ao contacto fornecido, ou <c>null</c> se não encontrado.</returns>
    public Utilizador? ObterUtilizadorPorContacto(string contacto)
    {
        return _repository.ObterPorContacto(contacto);
    }

    #endregion

    #region Get Clients

    /// <summary>
    /// Obtém todos os utilizadores que são clientes (não administradores), ordenados por nome.
    /// </summary>
    /// <returns>Uma lista de utilizadores clientes.</returns>
    public List<Utilizador> GetClientes()
    {
        var clientes = _repository.GetAllClientes();
        return clientes.OrderBy(c => c.Nome).ToList();
    }

    #endregion
}
