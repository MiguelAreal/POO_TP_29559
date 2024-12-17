/**
 * @file BaseController.cs
 * @brief Classe base abstrata para controlo de entidades genéricas.
 * 
 * Esta classe implementa a lógica base para operações CRUD (Criar, Ler, Atualizar e Apagar)
 * sobre um repositório genérico. A classe é projetada para ser extensível através da herança.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Collections.Generic;
using System.Linq;

/**
 * @class BaseController
 * @brief Classe base abstrata para a gestão de entidades genéricas.
 * 
 * A classe `BaseController` implementa funcionalidades base para controlo de itens genéricos
 * de um tipo `T`, onde `T` é uma classe que implementa a interface `IIdentifiable`.
 * Oferece métodos comuns para filtrar, adicionar, apagar e atualizar itens.
 * 
 * @tparam T Tipo genérico que deve ser uma classe e implementar a interface `IIdentifiable`.
 */
public abstract class BaseController<T> where T : class, IIdentifiable
{
    /// @brief Referência ao repositório base utilizado para operações nos itens.
    protected readonly BaseRepo<T> _repository;

    /// @brief Lista local de itens atualmente carregados.
    protected List<T> _items;

    /**
     * @brief Construtor da classe `BaseController`.
     * 
     * Inicializa o repositório com base no caminho de ficheiro fornecido.
     * 
     * @param filePath Caminho do ficheiro onde os dados serão armazenados.
     */
    public BaseController(string filePath) => _repository = new BaseRepo<T>(filePath);

    /**
     * @brief Filtra os itens da lista com base em uma coluna e um filtro fornecido.
     * 
     * Percorre os itens e filtra-os com base no valor da propriedade especificada
     * que contém uma substring correspondente ao filtro.
     * 
     * @param filtro Texto utilizado como filtro.
     * @param coluna Nome da coluna (propriedade) que será verificada.
     */
    public void FiltrarItens(string filtro, string coluna)
    {
        var itensFiltrados = _items.Where(model =>
        {
            if (string.IsNullOrEmpty(coluna)) return false;

            var prop = model.GetType().GetProperty(coluna);
            if (prop != null)
            {
                var value = prop.GetValue(model)?.ToString() ?? string.Empty;
                return value.Contains(filtro, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }).ToList();
    }

    /**
     * @brief Adiciona um novo item ao repositório.
     * 
     * Adiciona o item fornecido ao repositório e recarrega a lista de itens.
     * 
     * @param item O item a ser adicionado.
     */
    public void AddItem(T item)
    {
        _repository.Add(item);
        GetItems();
    }

    /**
     * @brief Apaga um item do repositório.
     * 
     * Tenta remover o item fornecido do repositório. Se o tipo for inválido, lança uma exceção.
     * 
     * @param item O item a ser removido.
     * @throw InvalidOperationException Se o tipo do item for inválido.
     */
    public void DeleteItem(object item)
    {
        if (item is T specificItem)
        {
            RemoveItem(specificItem);
            GetItems();
        }
        else
        {
            throw new InvalidOperationException("Tipo de item inválido para remoção.");
        }
    }

    /**
     * @brief Atualiza um item no repositório.
     * 
     * Tenta atualizar o item fornecido no repositório. Se o tipo for inválido, lança uma exceção.
     * 
     * @param item O item a ser atualizado.
     * @throw InvalidOperationException Se o tipo do item for inválido.
     */
    public void UpdateItem(object item)
    {
        if (item is T specificItem)
        {
            UpdateItem(specificItem);
            GetItems();
        }
        else
        {
            throw new InvalidOperationException("Tipo de item inválido para remoção.");
        }
    }

    /**
     * @brief Obtém um item pelo seu identificador.
     * 
     * Consulta o repositório e retorna o item que corresponde ao identificador fornecido.
     * 
     * @param id Identificador único do item a ser obtido.
     * @return O item correspondente ao identificador, ou null se não existir.
     */
    public object GetById(int id)
    {
        return _repository.GetById(id);
    }

    /**
     * @brief Remove um item específico.
     * 
     * Método virtual que pode ser re-implementado pelas classes derivadas
     * para definir a lógica de remoção de um item.
     * 
     * @param item O item a ser removido.
     */
    public virtual void RemoveItem(T item)
    {
        _repository.Remove(item);
    }

    /**
     * @brief Atualiza um item específico.
     * 
     * Método virtual que pode ser re-implementado pelas classes derivadas
     * para definir a lógica de atualização de um item.
     * 
     * @param item O item a ser atualizado.
     */
    public virtual void UpdateItem(T item)
    {
        _repository.Update(item);
    }
    

    /**
     * @brief Obtém todos os itens do repositório.
     * 
     * Método virtual que pode ser re-implementado pelas classes derivadas
     * para obter a lista de itens atuais.
     * 
     * @return Uma lista de objetos do tipo `T`.
     */
    public virtual object GetItems() {
        return _repository.GetAll();
    }
}
