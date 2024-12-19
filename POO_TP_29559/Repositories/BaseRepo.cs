/**
 * @file BaseRepo.cs
 * @brief Classe base para o repositório genérico com operações CRUD.
 * 
 * A classe `BaseRepo<T>` implementa um repositório genérico para a manipulação de dados
 * com operações de criação, leitura, atualização e remoção (CRUD). Os itens são
 * armazenados em formato JSON num ficheiro, permitindo a persistência dos dados entre
 * as execuções da aplicação.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using poo_tp_29559.Interfaces;

/**
 * @interface IIdentifiable
 * @brief Interface para garantir que a classe possui um campo `Id`.
 * 
 * A interface `IIdentifiable` exige que as classes que a implementem possuam um campo `Id`,
 * que é utilizado para identificar de forma única cada item dentro do sistema.
 */
public interface IIdentifiable
{
    /**
     * @brief Identificador único do item.
     * 
     * O campo `Id` é utilizado para identificar de forma única cada item numa coleção.
     * Este campo deve ser implementado pelas classes que utilizam esta interface.
     */
    int Id { get; set; }
}

/**
 * @class BaseRepo
 * @brief Repositório genérico para manipulação de dados.
 * 
 * A classe `BaseRepo<T>` implementa um repositório genérico para realizar operações de CRUD
 * (Criar, Ler, Atualizar, Apagar) em itens do tipo `T`. Os itens são carregados e guardados
 * em ficheiros JSON, o que garante persistência entre as execuções da aplicação.
 * 
 * @tparam T Tipo genérico representando a entidade armazenada no repositório, que deve
 *         implementar a interface `IIdentifiable`.
 */
public class BaseRepo<T> : IRepo<T> where T : class, IIdentifiable
{
    protected readonly string filePath; ///< Caminho para o ficheiro onde os dados são armazenados.
    protected List<T> items; ///< Lista de itens armazenados no repositório.

    /**
     * @brief Construtor da classe `BaseRepo`.
     * 
     * Inicializa o repositório com o caminho do ficheiro onde os dados serão armazenados.
     * Carrega os itens existentes no ficheiro, se houver algum.
     * 
     * @param filePath Caminho do ficheiro onde os dados serão guardados.
     */
    public BaseRepo(string filePath)
    {
        this.filePath = filePath;
        items = LoadItems();
    }

    /**
     * @brief Carrega os itens do ficheiro JSON.
     * 
     * Este método carrega os itens salvos no ficheiro JSON. Se o ficheiro não existir,
     * ele retorna uma lista vazia.
     * 
     * @return Uma lista de itens do tipo `T` carregados do ficheiro, ou uma lista vazia
     *         se o ficheiro não existir ou estiver vazio.
     */
    private List<T> LoadItems()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                IncludeFields = true, ///< Inclui campos na desserialização.
                PropertyNameCaseInsensitive = true ///< Permite a desserialização com nomes de propriedades insensíveis a maiúsculas/minúsculas.
            };

            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }
        else
        {
            return new List<T>();
        }
    }

    /**
     * @brief Obtém todos os itens do repositório.
     * 
     * Carrega os itens e os retorna como uma lista.
     * 
     * @return Uma lista de todos os itens armazenados no repositório.
     */
    public List<T> GetAll()
    {
        items = LoadItems();
        return items;
    }

    /**
     * @brief Adiciona um item ao repositório.
     * 
     * Adiciona um novo item ao repositório, atribuindo-lhe um ID único e persistindo
     * as mudanças no ficheiro JSON.
     * 
     * @param item O item a ser adicionado ao repositório.
     * @throw ArgumentNullException Se o item fornecido for `null`.
     */
    public virtual void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item não pode ser null.");

        SetId(item);
        items.Add(item);
        SaveChanges();
    }

    /**
     * @brief Remove um item do repositório.
     * 
     * Remove o item fornecido do repositório e persiste as mudanças no ficheiro JSON.
     * 
     * @param item O item a ser removido do repositório.
     */
    public virtual void Remove(T item)
    {
        items.Remove(item);
        SaveChanges();
    }

    /**
     * @brief Atualiza um item no repositório.
     * 
     * Atualiza os dados de um item existente no repositório com base no seu ID.
     * 
     * @param itemAlterado O item com os dados atualizados.
     * @throw ArgumentNullException Se o item fornecido for `null`.
     * @throw KeyNotFoundException Se o item não for encontrado no repositório.
     */
    public virtual void Update(T itemAlterado)
    {
        if (itemAlterado == null)
            throw new ArgumentNullException(nameof(itemAlterado), "Item não pode ser null.");

        var index = items.FindIndex(item => item.Id == itemAlterado.Id);

        if (index != -1)
        {
            items[index] = itemAlterado;
            SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Item não encontrado.");
        }
    }

    /**
     * @brief Obtém um item pelo seu identificador.
     * 
     * Retorna o item correspondente ao ID fornecido, ou `null` se não encontrado.
     * 
     * @param id Identificador único do item a ser recuperado.
     * @return O item correspondente ao ID fornecido, ou `null` se não encontrado.
     */
    public virtual T GetById(int? id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }

    /**
     * @brief Obtém um item com base em uma propriedade.
     * 
     * Retorna o primeiro item que possui a propriedade especificada com o valor fornecido.
     * 
     * @param propertySelector Função que seleciona a propriedade a ser comparada.
     * @param value Valor a ser comparado com a propriedade selecionada.
     * @return O item correspondente, ou `null` se não encontrado.
     */
    public virtual T? GetByProperty(Func<T, object> propertySelector, object value)
    {
        return items.FirstOrDefault(item => propertySelector(item)?.Equals(value) == true);
    }

    /**
     * @brief guarda as mudanças no ficheiro JSON.
     * 
     * Persiste as alterações realizadas na lista de itens no ficheiro JSON.
     */
    protected void SaveChanges()
    {
        string? directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    /**
     * @brief Atribui um novo ID ao item.
     * 
     * Define um ID único para o item com base no próximo ID disponível.
     * 
     * @param item O item ao qual será atribuído um ID único.
     */
    protected void SetId(T item)
    {
        item.Id = GetProximoId();
    }

    /**
     * @brief Obtém o próximo ID disponível.
     * 
     * Retorna o próximo ID disponível para ser atribuído a um item. O ID é
     * gerado com base no maior ID atual somado a 1.
     * 
     * @return O próximo ID disponível.
     */
    private int GetProximoId()
    {
        if (items.Count == 0)
        {
            return 1;
        }
        return items.Max(item => item.Id) + 1;
    }
}
