using poo_tp_29559.Models;
using poo_tp_29559.Interfaces;
using System.ComponentModel;

public class Produto : IIdentifiable
{
    public int Id { get; set; }

    [DisplayName("Nome do Produto")]
    public string? Nome { get; set; }

    [DisplayName("Categoria")]
    public int? CategoriaID { get; set; }

    [DisplayName("Marca")]
    public int? MarcaID { get; set; }

    [DisplayName("Preço")]
    public decimal Preco { get; set; }

    [DisplayName("Stock")]
    public int QuantidadeEmStock { get; set; }

    [DisplayName("Data de Adição")]
    public string DataAdicao { get; set; }

    // Constructor
    public Produto()
    {
        DataAdicao = DateTime.Now.ToString();
        QuantidadeEmStock = 0;
    }
}
