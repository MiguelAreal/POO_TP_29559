namespace poo_tp_29559.Repositories.Enumerators
{
    /// <summary>
    /// Enumeração que representa os tipos de formulários na aplicação.
    /// </summary>
    /// <remarks>
    /// A enumeração <c>FormTypes</c> contém os diferentes tipos de formulários utilizados na aplicação
    /// para a gestão de várias entidades. Cada valor da enumeração corresponde a um tipo específico
    /// de formulário, sendo utilizado para realizar operações de manipulação e visualização de dados
    /// em diferentes áreas da aplicação.
    /// </remarks>
    public enum FormTypes
    {
        /// <summary>
        /// Formulário para gestão de produtos.
        /// </summary>
        /// <remarks>
        /// Este tipo de formulário é utilizado para realizar operações de criação,
        /// leitura, atualização e remoção (CRUD) de produtos na aplicação.
        /// </remarks>
        Produtos,

        /// <summary>
        /// Formulário para gestão de categorias de produtos.
        /// </summary>
        /// <remarks>
        /// Este tipo de formulário permite realizar operações de CRUD sobre as categorias
        /// de produtos.
        /// </remarks>
        Categorias,

        /// <summary>
        /// Formulário para gestão de marcas de produtos.
        /// </summary>
        /// <remarks>
        /// Utilizado para realizar operações de CRUD sobre as marcas associadas aos produtos.
        /// </remarks>
        Marcas,

        /// <summary>
        /// Formulário para gestão de vendas.
        /// </summary>
        /// <remarks>
        /// Este tipo de formulário é utilizado para a gestão de transações de vendas,
        /// permitindo o controlo e registo das vendas realizadas.
        /// </remarks>
        Vendas,

        /// <summary>
        /// Formulário para gestão de utilizadores da aplicação.
        /// </summary>
        /// <remarks>
        /// Permite a gestão de utilizadores do sistema, incluindo operações como
        /// criação, atualização e remoção de utilizadores.
        /// </remarks>
        Utilizadores,

        /// <summary>
        /// Formulário para gestão de campanhas promocionais.
        /// </summary>
        /// <remarks>
        /// Utilizado para gerir as campanhas promocionais dentro da aplicação,
        /// incluindo a criação, monitorização e edição de campanhas.
        /// </remarks>
        Campanhas,

        /// <summary>
        /// Formulário para gestão de compras.
        /// </summary>
        /// <remarks>
        /// Este tipo de formulário é utilizado para gerir as compras realizadas,
        /// permitindo a adição, edição e remoção de registos de compras na aplicação.
        /// </remarks>
        Compras
    }
}
