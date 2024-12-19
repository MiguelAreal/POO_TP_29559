using System;
using System.ComponentModel;


/**
 * @class Utilizador
 * @brief Representa um utilizador no sistema.
 * 
 * A classe `Utilizador` armazena informações pessoais de um cliente ou administrador, incluindo o nome, contacto,
 * morada, NIF, data de nascimento, e outras propriedades associadas ao utilizador. Esta classe é usada para gerir
 * as informações de um utilizador no sistema.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

public class Utilizador : IIdentifiable
{
    /**
     * @brief Identificador único do utilizador.
     * 
     * Este campo armazena o identificador único do utilizador.
     */
    public int Id { get; set; }

    /**
     * @brief Nome do utilizador.
     * 
     * Este campo armazena o nome do utilizador (cliente).
     */
    [DisplayName("Nome de Cliente")]
    public string? Nome { get; set; }

    /**
     * @brief Contacto do utilizador.
     * 
     * Este campo armazena o número de contacto do utilizador.
     */
    [DisplayName("Contacto")]
    public string Contacto { get; set; }

    /**
     * @brief Morada do utilizador.
     * 
     * Este campo armazena a morada do utilizador.
     */
    [DisplayName("Morada")]
    public string? Morada { get; set; }

    /**
     * @brief Número de Identificação Fiscal (NIF).
     * 
     * Este campo armazena o NIF (número de identificação fiscal) do utilizador. É o identificador único do utilizador.
     */
    [DisplayName("NIF")]
    public int Nif { get; set; }

    /**
     * @brief Data de nascimento do utilizador.
     * 
     * Este campo armazena a data de nascimento do utilizador, representada como uma string.
     */
    [DisplayName("Data de Nascimento")]
    public string? DataNasc { get; set; }

    /**
     * @brief Data de criação do utilizador.
     * 
     * Este campo armazena a data de criação do utilizador no sistema, representada como uma string.
     */
    [DisplayName("Data de Criação")]
    public string? DataAdicao { get; set; }

    /**
     * @brief Palavra-passe do utilizador.
     * 
     * Este campo armazena a palavra-passe do utilizador.
     */
    [DisplayName("Password")]
    public string? Password { get; set; }

    /**
     * @brief Indicador de administrador.
     * 
     * Este campo indica se o utilizador tem permissões de administrador.
     * A propriedade é do tipo booleano, onde `true` significa que o utilizador é um administrador,
     * e `false` significa que é um cliente.
     */
    [DisplayName("Admin.")]
    public bool IsAdmin { get; set; }

    /**
     * @brief Construtor da classe `Utilizador`.
     * 
     * Este construtor inicializa a data de adição com a data e hora atuais e define a propriedade `IsAdmin` como `false` por padrão,
     * indicando que o utilizador é um cliente comum.
     */
    public Utilizador()
    {
        DataAdicao = DateTime.Now.ToString();
        IsAdmin = false;
    }
}
