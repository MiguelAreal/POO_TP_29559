using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

/**
 * @class UtilizadorController
 * @brief Controlador para a gestão dos utilizadores.
 * 
 * A classe `UtilizadorController` é responsável pela gestão dos utilizadores, incluindo operações de verificação de login, NIF, e contacto. Herda de `BaseController<Utilizador>` e implementa a interface `IEntityController`, oferecendo funcionalidades específicas para o trabalho com utilizadores.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class UtilizadorController : BaseController<Utilizador>, IEntityController
{
    protected new UtilizadorRepo _repository; /**< Repositório específico para a gestão de utilizadores */

    /**
     * @brief Construtor da classe `UtilizadorController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde os utilizadores são armazenados.
     */
    public UtilizadorController() : base("Data/utilizadores.json")
    {
        _repository = new UtilizadorRepo();
    }

    /**
     * @brief Verifica se o login do utilizador é válido.
     * 
     * Este método verifica se o NIF e a palavra-passe fornecida correspondem a um utilizador existente no sistema.
     * 
     * @param nif O NIF do utilizador.
     * @param password A palavra-passe do utilizador.
     * @return `true` se o login for válido, caso contrário, `false`.
     */
    public bool VerificarLogin(int nif, string password)
    {
        var user = ObterUtilizadorPorNIF(nif);
        return user != null && user.Password == password;
    }

    /**
     * @brief Verifica se o NIF fornecido já está registado.
     * 
     * Este método verifica se o NIF já está associado a um utilizador existente no sistema.
     * 
     * @param nif O NIF do utilizador.
     * @return `true` se o NIF já estiver registado, caso contrário, `false`.
     */
    public bool VerificarNIFExistente(int nif)
    {
        var user = ObterUtilizadorPorNIF(nif); // Busca o utilizador com o NIF fornecido
        return user != null; // Retorna true se o utilizador foi encontrado, caso contrário, false
    }

    /**
     * @brief Verifica se o contacto fornecido já está registado.
     * 
     * Este método verifica se o contacto fornecido já está associado a um utilizador existente no sistema.
     * 
     * @param contacto O contacto do utilizador.
     * @return `true` se o contacto já estiver registado, caso contrário, `false`.
     */
    public bool VerificarContactoExistente(string contacto)
    {
        var user = ObterUtilizadorPorContacto(contacto);
        return user != null; // Retorna true se o utilizador foi encontrado, caso contrário, false
    }

    /**
     * @brief Obtém um utilizador pelo NIF.
     * 
     * Este método recupera um utilizador específico a partir do seu NIF.
     * 
     * @param nif O NIF do utilizador a ser recuperado.
     * @return O utilizador correspondente ao NIF fornecido, ou `null` se não encontrado.
     */
    public Utilizador? ObterUtilizadorPorNIF(int nif)
    {
        return _repository.ObterPorNIF(nif);
    }

    /**
     * @brief Obtém um utilizador pelo contacto.
     * 
     * Este método recupera um utilizador específico a partir do seu contacto.
     * 
     * @param contacto O contacto do utilizador a ser recuperado.
     * @return O utilizador correspondente ao contacto fornecido, ou `null` se não encontrado.
     */
    public Utilizador? ObterUtilizadorPorContacto(string contacto)
    {
        return _repository.ObterPorContacto(contacto);
    }

    /**
     * @brief Obtém todos os utilizadores que são clientes e não administradores.
     * 
     * Este método retorna uma lista de utilizadores que são clientes e não têm privilégios administrativos, ordenados por nome.
     * 
     * @return Uma lista de utilizadores clientes.
     */
    public List<Utilizador> GetClientes()
    {
        var clientes = _repository.GetAllClientes();
        return clientes.OrderBy(c => c.Nome).ToList();
    }
}
