﻿using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class ProdutoRepo : BaseRepo<Produto>
    {
        public ProdutoRepo() : base("Data/produtos.json") { }

       

    }
}