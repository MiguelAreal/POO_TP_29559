/**
 * @class UtilizadorRepo.cs
 * @brief Repositório especializado na manipulação de utilizadores.
 * 
 * A classe `UtilizadorRepo` é uma especialização da classe base `BaseRepo<Utilizador>`,
 * responsável pela persistência e manipulação de utilizadores. A classe lida com operações
 * específicas para objetos do tipo `Utilizador`, incluindo a busca por NIF, contacto e a obtenção
 * de todos os utilizadores clientes.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class UtilizadorRepo
     * @brief Repositório para a manipulação de utilizadores.
     * 
     * A classe `UtilizadorRepo` herda de `BaseRepo<Utilizador>` e é especializada na manipulação
     * de objetos do tipo `Utilizador`. Ela oferece funcionalidades adicionais para procurar utilizadores
     * pelo NIF ou Contacto, bem como obter todos os utilizadores clientes a partir de um ficheiro JSON.
     * 
     * @see BaseRepo
     */
    public class UtilizadorRepo : BaseRepo<Utilizador>
    {
        /**
         * @brief Construtor da classe `UtilizadorRepo`.
         * 
         * Inicializa o repositório de utilizadores com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/utilizadores.json`.
         */
        public UtilizadorRepo() : base("Data/utilizadores.json") { }

        /**
         * @brief Obtém um utilizador pelo NIF.
         * 
         * Este método permite buscar um utilizador através do seu NIF.
         * 
         * @param nif O NIF do utilizador a procurar.
         * @return O utilizador se encontrado; caso contrário, null.
         */
        public Utilizador? ObterPorNIF(int nif)
        {
            return GetByProperty(u => u.Nif, nif);
        }

        /**
         * @brief Obtém um utilizador pelo Contacto.
         * 
         * Este método permite buscar um utilizador através do seu Contacto.
         * Caso o Contacto fornecido seja inválido, o método retorna `null`.
         * 
         * @param contacto O Contacto do utilizador a procurar.
         * @return O utilizador se encontrado; caso contrário, null.
         */
        public Utilizador? ObterPorContacto(string contacto)
        {
            if (string.IsNullOrWhiteSpace(contacto))
            {
                return null; // Retorna null se o contacto for inválido
            }

            return GetByProperty(u => u.Contacto, contacto); // Busca o utilizador com o contacto fornecido
        }

        /**
         * @brief Obtém todos os utilizadores clientes.
         * 
         * Este método retorna uma lista de todos os utilizadores que não são administradores.
         * 
         * @return Uma lista de utilizadores clientes encontrados.
         */
        public List<Utilizador> GetAllClientes()
        {
            return items.Where(u => !u.IsAdmin).ToList();
        }
    }
}
