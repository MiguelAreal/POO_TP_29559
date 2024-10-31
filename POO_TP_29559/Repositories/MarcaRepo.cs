using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class MarcaRepo : BaseRepo<Marca>
    {
        public MarcaRepo() : base("Data/marcas.json") { }


    }
}