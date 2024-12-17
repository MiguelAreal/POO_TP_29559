
using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CampanhaController : BaseController<Campanha>, IEntityController
{
    private List<CampanhaViewModel>? _campanhasComNomes;

    public CampanhaController() : base("Data/campanhas.json") { }

    public override object GetItems()
    {
        List<Campanha> campanhas = _repository.GetAll();

        _campanhasComNomes = new List<CampanhaViewModel>();

        foreach (var campanha in campanhas)
        {
            // Traduz IDs para nomes
            Categoria? categoria = new CategoriaRepo().GetById(campanha.CategoriaId);

            // Cria view model com campanhas em vez de IDS para visualização
            var campanhaViewModel = new CampanhaViewModel
            {
                Id = campanha.Id,
                Nome = campanha.Nome,
                PercentagemDesc = campanha.PercentagemDesc,
                DataInicio = campanha.DataInicio,
                DataFim = campanha.DataFim,
                CategoriaNome = categoria?.Nome,
            };

            _campanhasComNomes.Add(campanhaViewModel);
        }

        // Pass the list of translated products to the view
        return _campanhasComNomes;
    }

    
}
