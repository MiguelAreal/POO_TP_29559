using System.ComponentModel;

public class Cliente : IIdentifiable
{
    public int Id { get; set; }

    [DisplayName("Nome de Cliente")]
    public string? Nome { get; set; }

    [DisplayName("Contacto")]
    public string? Contacto { get; set; }

    [DisplayName("Morada")]
    public string? Morada { get; set; }

    [DisplayName("NIF")]
    public string? Nif { get; set; }

    [DisplayName("Data de Nascimento")]
    public string? DataNasc { get; set; }

    [DisplayName("Data de Criação")]
    public string? DataAdicao { get; set; }

    // Se NIF começar com '1', '2' ou '3', É cliente particular. Outrora, é Empresa.
    // Faz diferença no cálculo da garantia associada.
    public bool IsParticular => Nif != null && (Nif.StartsWith("1") || Nif.StartsWith("2") || Nif.StartsWith("3"));

    // Construtor
    public Cliente()
    {
        DataAdicao = DateTime.Now.ToString();
    }
}
