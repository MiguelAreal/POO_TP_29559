using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace poo_tp_29559.Controllers
{
    public class MarcaController
    {
        private readonly MarcasForm _view;
        private readonly MarcaRepo _repository;

        // Armazena a lista completa de produtos
        private List<Marca> _marcas;

        public MarcaController(MarcasForm view)
        {
            _view = view;
            _repository = new MarcaRepo();
            CarregaMarcas();
        }

        // Carrega produtos e exibe na view
        private void CarregaMarcas()
        {
            _marcas = _repository.GetMarcas();
            _view.MostraMarcas(_marcas);
        }

        // Filtra produtos com base no nome e atualiza a view
        public void FiltrarMarcas(string filtro)
        {
            var marcasFiltradas = _marcas
                .Where(p => !string.IsNullOrEmpty(p.Nome) && p.Nome.ToLower().Contains(filtro.ToLower()))
                .ToList();

            _view.MostraMarcas(marcasFiltradas);
        }

        // Adiciona novo produto, e atualiza a view
        public void AddMarcas(Marca produto)
        {
            _repository.AddMarca(produto);
            CarregaMarcas();
        }

        // Remove produto, e atualiza a view
        public void RemMarca(Marca marca)
        {
            _repository.RemMarca(marca);
            CarregaMarcas();
        }

        // Altera o produto, e atualiza a view
        public void UpdMarca(Marca marca)
        {
            _repository.UpdMarca(marca);
            CarregaMarcas();
        }
    }
}
