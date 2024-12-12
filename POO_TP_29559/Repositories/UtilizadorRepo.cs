using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class UtilizadorRepo : BaseRepo<Utilizador>
    {
        public UtilizadorRepo() : base("Data/utilizadores.json") { }

        /// <summary>
        /// Obtém um utilizador pelo NIF.
        /// </summary>
        /// <param name="nif">O NIF do utilizador a procurar.</param>
        /// <returns>O utilizador se encontrado; caso contrário, null.</returns>
        public Utilizador? ObterPorNIF(int nif)
        {
            return GetByProperty(u => u.Nif, nif);
        }

        /// <summary>
        /// Obtém um utilizador pelo Contacto.
        /// </summary>
        /// <param name="contacto">O Contacto do utilizador a procurar.</param>
        /// <returns>O utilizador se encontrado; caso contrário, null.</returns>
        public Utilizador? ObterPorContacto(string contacto)
        {
            if (string.IsNullOrWhiteSpace(contacto))
            {
                return null; // Retorna null se o contacto for inválido
            }

            return GetByProperty(u => u.Contacto, contacto); // Busca o utilizador com o contacto fornecido
        }

        /// <summary>
        /// Obtém todos os utilizadores clientes.
        /// </summary>
        /// <returns>Utilizadores encontrados; caso contrário, null.</returns>
        public List<Utilizador> GetAllClientes()
        {
            return items.Where(u => !u.IsAdmin).ToList();
        }


    }
}