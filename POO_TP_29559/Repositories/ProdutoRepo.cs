using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class ProdutoRepo : BaseRepo<Produto>
    {
        public ProdutoRepo() : base("Data/produtos.json") { }

        protected override int GetId(Produto item)
        {
            return item.Id;
        }

        protected override void SetId(Produto item)
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

        protected override void UpdateProperties(Produto original, Produto updated)
        {
            original = updated;
        }

       
    }
}
