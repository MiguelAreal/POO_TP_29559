using System;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa um utilizador no sistema.
    /// </summary>
    /// <remarks>
    /// A classe <c>Utilizador</c> armazena informações pessoais de um cliente ou administrador, incluindo o nome,
    /// contacto, morada, NIF, data de nascimento, e outras propriedades associadas ao utilizador. 
    /// Esta classe é usada para gerir as informações de um utilizador no sistema.
    /// </remarks>
    public class Utilizador : IIdentifiable
    {
        /// <summary>
        /// Identificador único do utilizador.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único do utilizador.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome do utilizador (cliente).
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome do utilizador (cliente).
        /// </remarks>
        [DisplayName("Nome de Cliente")]
        public string? Nome { get; set; }

        /// <summary>
        /// Contacto do utilizador.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o número de contacto do utilizador.
        /// </remarks>
        [DisplayName("Contacto")]
        public string Contacto { get; set; }

        /// <summary>
        /// Morada do utilizador.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a morada do utilizador.
        /// </remarks>
        [DisplayName("Morada")]
        public string? Morada { get; set; }

        /// <summary>
        /// Número de Identificação Fiscal (NIF).
        /// </summary>
        /// <remarks>
        /// Este campo armazena o NIF (número de identificação fiscal) do utilizador. É o identificador único do utilizador.
        /// </remarks>
        [DisplayName("NIF")]
        public int Nif { get; set; }

        /// <summary>
        /// Data de nascimento do utilizador.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data de nascimento do utilizador, representada como uma string.
        /// </remarks>
        [DisplayName("Data de Nascimento")]
        public string? DataNasc { get; set; }

        /// <summary>
        /// Data de criação do utilizador no sistema.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data de criação do utilizador no sistema, representada como uma string.
        /// </remarks>
        [DisplayName("Data de Criação")]
        public string? DataAdicao { get; set; }

        /// <summary>
        /// Palavra-passe do utilizador.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a palavra-passe do utilizador. A propriedade é marcada com <c>[Browsable(false)]</c>
        /// para garantir que ela não seja exibida na interface de utilizador.
        /// </remarks>
        [Browsable(false)]
        [DisplayName("Password")]
        public string? Password { get; set; }

        /// <summary>
        /// Indicador de administrador.
        /// </summary>
        /// <remarks>
        /// Este campo indica se o utilizador tem permissões de administrador. A propriedade é do tipo booleano,
        /// onde <c>true</c> significa que o utilizador é um administrador, e <c>false</c> significa que é um cliente.
        /// </remarks>
        [DisplayName("Admin.")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Construtor da classe <c>Utilizador</c>.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa a data de adição com a data e hora atuais e define a propriedade <c>IsAdmin</c>
        /// como <c>false</c> por padrão, indicando que o utilizador é um cliente comum.
        /// </remarks>
        public Utilizador()
        {
            DataAdicao = DateTime.Now.ToString();
            IsAdmin = false;
        }
    }
}
