using poo_tp_29559.Repositories.Interfaces;
using System.ComponentModel;

public class Marca : IIdentifiable
{
   
    public int Id { get; set; }

    [DisplayName("Nome da Marca")]
    public string? Nome { get; set; }

    [DisplayName("Descrição")]
    public string? Descricao { get; set; }

    [DisplayName("Data de Criação")]
    public DateTime DataCriacao { get; set; }

    [DisplayName("País de Origem")]
    public string? PaisOrigem { get; set; }

    // Construtor
    public Marca()
    {
        DataCriacao = DateTime.Now;
    }

    // Método para verificar se a marca pode ser eliminada
    // Só pode ser eliminada se a marca não tiver em nenhum produto.
    public bool PodeSerEliminada(List<Produto> produtos)
    {
        return !produtos.Any(p => p.MarcaID == this.Id);
    }
}
