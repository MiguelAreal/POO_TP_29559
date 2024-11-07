using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Enumerators;
using System.ComponentModel;



public class Venda : IIdentifiable
{
    [Browsable(false)]
    public int Id { get; set; }

    [DisplayName("Cliente")]
    public int ClienteID { get; set; } // Cliente associado
    
    public List<ItemVenda>? Itens { get; set; } = new List<ItemVenda>();

    // Total de unidades de produtos vendidos
    public int Quantidade => Itens?.Sum(item => item.Unidades) ?? 0;

    // Total de valor de produtos vendidos, incluindo a percentagem de desconto de cada produto diferente vendido.
    public decimal PrecoTotal => Itens?.Sum(item =>
    (item.PrecoUnitario * item.Unidades) * (1-item.PercentagemDesc/100)
    ) ?? 0;

    // Data a que a venda foi efetuada
    public string DataVenda { get; set; }

    // Pagamento Utilizado, consoante Enumerador
    public MetodoPagamento? MetodoPagamento { get; set; }

    // Construtor
    public Venda()
    {
        DataVenda = DateTime.Now.ToString();

        // Por defeito coloca o número de garantia em meses, baseado em saber se o cliente é particular ou não
        //GarantiaMeses = cliente?.IsParticular == true ? 36 : 12;
    }

}