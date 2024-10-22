using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class MarcaRepo : BaseRepo<Marca>
    {
        public MarcaRepo() : base("Data/marcas.json") { }

       

        protected override int GetId(Marca item)
        {
            return item.Id;
        }
        
        protected override void SetId(Marca item)
        {
            item.Id = GetProximoId();
        }

        private int GetProximoId()
        {
            if (items.Count == 0)
            {
                return 1;
            }
            return items[^1].Id + 1;
        }

        protected override void UpdateProperties(Marca original, Marca updated)
        {
            original = updated;
        }

    }
}
