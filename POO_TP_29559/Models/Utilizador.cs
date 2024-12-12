using System;
using System.ComponentModel;

public class Utilizador : IIdentifiable
{
    public int Id { get; set; }

    [DisplayName("Nome de Cliente")]
    public string? Nome { get; set; }

    [DisplayName("Contacto")]
    public string Contacto { get; set; }

    [DisplayName("Morada")]
    public string? Morada { get; set; }

    [DisplayName("NIF")]
    public int Nif { get; set; } // Identificador Único

    [DisplayName("Data de Nascimento")]
    public string? DataNasc { get; set; }

    [DisplayName("Data de Criação")]
    public string? DataAdicao { get; set; }

    [DisplayName("Password")]
    public string? Password { get; set; }

    [DisplayName("Admin.")]
    public bool IsAdmin { get; set; } 


    // Construtor
    public Utilizador()
    {
        DataAdicao = DateTime.Now.ToString();
        IsAdmin = false; // Define por padrão que o utilizador é um cliente
    }

}
