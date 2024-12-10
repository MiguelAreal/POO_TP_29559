using poo_tp_29559.Controllers;
using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

public class CampanhaController : BaseController<Campanha, ChildForm>, IEntityController
{
    private List<CampanhaViewModel>? _campanhasComNomes; 

    public CampanhaController(ChildForm view) : base(view, "Data/campanhas.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Campanha> campanhas)
    {
        // Create a temporary list to hold translated products
        _campanhasComNomes = new List<CampanhaViewModel>();

        foreach (var campanha in campanhas)
        {
            // Translate IDs to names
            Categoria? categoria = new CategoriaRepo().GetById(campanha.CategoriaId);

            // Create a view model for the product with names instead of IDs
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
        _view.MostraItens(_campanhasComNomes);
    }

    protected override void RemoveItem(Campanha item)
    {
        _repository.Remove(item);
        
    }

    protected override void UpdateItem(Campanha item)
    {
        throw new NotImplementedException();
    }


    
}
