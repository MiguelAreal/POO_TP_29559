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

    [DisplayName("NIF")]
    public string? Nif { get; set; } // Exibe o NIF do cliente se o cliente estiver associado

    [DisplayName("Produtos Vendidos")]
    public List<ItemVenda>? Produtos { get; set; } // Alterado para uma lista de ItemVenda, uma venda pode ser composta por vários produtos.

    [DisplayName("Quantidade Total de Produtos")]
    public int Quantidade => Produtos?.Sum(item => item.Quantidade) ?? 0; // Total de unidades de produto vendidos

    [DisplayName("Percentagem Descontada")]
    public int Percentagem { get; set; }

    [DisplayName("Preço Total")]
    public decimal PrecoTotal { get; set; }

    [DisplayName("Data da Venda")]
    public DateTime DataVenda { get; set; }

    [DisplayName("Método de Pagamento")]
    public MetodoPagamento? MetodoPagamento { get; set; }

    [DisplayName("Garantia (Meses)")]
    public int GarantiaMeses { get; set; }

    // Construtor
    public Venda(Cliente? cliente)
    {
        Percentagem = 0;
        DataVenda = DateTime.Now;

        // Set GarantiaMeses based on the Cliente's IsParticular property
        GarantiaMeses = cliente?.IsParticular == true ? 36 : 12;
        Nif = cliente?.Nif;
    }

}