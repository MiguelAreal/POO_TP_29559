/// <summary>
/// Interface para garantir que uma classe possui um identificador único.
/// </summary>
/// <remarks>
/// A interface <c>IIdentifiable</c> exige que as classes que a implementem possuam uma propriedade <c>Id</c>.  
/// Essa propriedade é usada para identificar de forma única cada instância dentro do sistema ou coleção.
/// </remarks>
public interface IIdentifiable
{
    /// <summary>
    /// Identificador único do item.
    /// </summary>
    /// <remarks>
    /// Deve ser implementado pelas classes que utilizam esta interface para permitir uma identificação única.
    /// </remarks>
    int Id { get; set; }
}
