using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class CategoriaRepo : BaseRepo<Categoria>
    {
        public CategoriaRepo() : base("Data/categorias.json") { }


    }
}