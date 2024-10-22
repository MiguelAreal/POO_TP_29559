using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.Collections.Generic;

namespace poo_tp_29559.Controllers
{
    public class MarcaController : BaseController<Marca, MarcasForm, MarcaRepo>
    {
        public MarcaController(MarcasForm view) : base(view)
        {
        }

        // Método implementado para mostrar as marcas na view
        protected override void ExibeItensNaView(List<Marca> marcas)
        {
            _view.MostraMarcas(marcas);
        }

        // Método específico para filtrar marcas pelo nome
        public void FiltrarMarcas(string filtro)
        {
            // Usa o método da classe BaseController, passando a função de filtro para procurar pelo nome
            FiltrarItens(filtro, marca => marca.Nome != null && marca.Nome.ToLower().Contains(filtro.ToLower()));
        }
    }
}
