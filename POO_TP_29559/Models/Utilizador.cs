using System;
using System.ComponentModel;

public class Utilizador : IIdentifiable
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

    [DisplayName("Password")]
    public string? Password { get; set; }

    public bool IsAdmin { get; set; } // Para identificar se o utilizador se é administrador ou cliente


    // Construtor
    public Utilizador()
    {
        DataAdicao = DateTime.Now.ToString();
        IsAdmin = false; // Define por padrão que o usuário é um cliente
    }

    // Método de verificação de password - Apenas um exemplo simples (para fins de demonstração)
    public bool VerificarPassword(string password)
    {
        return Password == password;
    }
}
