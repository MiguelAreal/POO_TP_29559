using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Enumerators;
using System.ComponentModel;



public class VendaCompra : IIdentifiable
{
    [Browsable(false)]
    public int Id { get; set; }

    [DisplayName("Cliente")]
    public int? ClienteID { get; set; } // Cliente associado, se aplicável

    [DisplayName("NIF")]
    public int? NIF { get; set; } // NIF associado, se aplicável

    public List<ItemVenda>? Itens { get; set; } = new List<ItemVenda>();

    // Total de unidades de produtos vendidos (soma de cada produto)
    public int ItensTotal => Itens?.Sum(item => item.Unidades) ?? 0;

    // Total de valor de produtos vendidos, sem descontos.
    public decimal TotalBruto { get; set; }
    
    // Total de valor de produtos vendidos, com descontos.
    public decimal TotalLiquido { get; set; }

    // Data a que a venda foi efetuada
    public string DataVenda { get; set; }


    // Data de fim da garantia, por defeito, 36 meses.
    public string? FimDataGarantia { get; set; }

    // Pagamento Utilizado, consoante Enumerador
    public MetodoPagamento? MetodoPagamento { get; set; }

    // Construtor
    public VendaCompra()
    {
        DataVenda = DateTime.Now.ToString();
        FimDataGarantia = DateTime.Now.AddMonths(36).ToString();
    }

}