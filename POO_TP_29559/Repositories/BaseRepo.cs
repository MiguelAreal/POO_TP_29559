using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using poo_tp_29559.Interfaces;

namespace poo_tp_29559.Repositories
{
    #region Class BaseRepo
    /// <summary>
    /// Repositório genérico para manipulação de dados.
    /// </summary>
    /// <remarks>
    /// A classe <c>BaseRepo&lt;T&gt;</c> implementa um repositório genérico para realizar operações de CRUD
    /// (Criar, Ler, Atualizar, Apagar) em itens do tipo <c>T</c>. Os itens são carregados e guardados
    /// em ficheiros JSON, garantindo persistência entre as execuções da aplicação.
    /// </remarks>
    /// <typeparam name="T">Tipo genérico representando a entidade armazenada no repositório, que deve
    /// implementar a interface <c>IIdentifiable</c>.</typeparam>
    public class BaseRepo<T> : IRepo<T> where T : class, IIdentifiable
    {
        #region Fields
        /// <summary>
        /// Caminho para o ficheiro onde os dados são armazenados.
        /// </summary>
        protected readonly string filePath;

        /// <summary>
        /// Lista de itens armazenados no repositório.
        /// </summary>
        protected List<T> items;
        #endregion

        #region Constructor
        /// <summary>
        /// Construtor da classe <c>BaseRepo&lt;T&gt;</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório com o caminho do ficheiro onde os dados serão armazenados.
        /// Carrega os itens existentes no ficheiro, se houver algum.
        /// </remarks>
        /// <param name="filePath">Caminho do ficheiro onde os dados serão guardados.</param>
        public BaseRepo(string filePath)
        {
            this.filePath = filePath;
            items = LoadItems();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Carrega os itens do ficheiro JSON.
        /// </summary>
        /// <remarks>
        /// Este método carrega os itens salvos no ficheiro JSON. Se o ficheiro não existir,
        /// ele retorna uma lista vazia.
        /// </remarks>
        /// <returns>Uma lista de itens do tipo <c>T</c> carregados do ficheiro, ou uma lista vazia
        /// se o ficheiro não existir ou estiver vazio.</returns>
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

        /// <summary>
        /// Guarda as mudanças no ficheiro JSON.
        /// </summary>
        /// <remarks>
        /// Persiste as alterações realizadas na lista de itens no ficheiro JSON.
        /// </remarks>
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

        /// <summary>
        /// Atribui um novo ID ao item.
        /// </summary>
        /// <remarks>
        /// Define um ID único para o item com base no próximo ID disponível.
        /// </remarks>
        /// <param name="item">O item ao qual será atribuído um ID único.</param>
        protected void SetId(T item)
        {
            item.Id = GetProximoId();
        }

        /// <summary>
        /// Obtém o próximo ID disponível.
        /// </summary>
        /// <remarks>
        /// Retorna o próximo ID disponível para ser atribuído a um item. O ID é
        /// gerado com base no maior ID atual somado a 1.
        /// </remarks>
        /// <returns>O próximo ID disponível.</returns>
        private int GetProximoId()
        {
            if (items.Count == 0)
            {
                return 1;
            }
            return items.Max(item => item.Id) + 1;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Obtém todos os itens do repositório.
        /// </summary>
        /// <remarks>
        /// Carrega os itens e os retorna como uma lista.
        /// </remarks>
        /// <returns>Uma lista de todos os itens armazenados no repositório.</returns>
        public List<T> GetAll()
        {
            items = LoadItems();
            return items;
        }

        /// <summary>
        /// Adiciona um item ao repositório.
        /// </summary>
        /// <remarks>
        /// Adiciona um novo item ao repositório, atribuindo-lhe um ID único e persistindo
        /// as mudanças no ficheiro JSON.
        /// </remarks>
        /// <param name="item">O item a ser adicionado ao repositório.</param>
        /// <exception cref="ArgumentNullException">Se o item fornecido for <c>null</c>.</exception>
        public virtual void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item não pode ser null.");

            SetId(item);
            items.Add(item);
            SaveChanges();
        }

        /// <summary>
        /// Remove um item do repositório.
        /// </summary>
        /// <remarks>
        /// Remove o item fornecido do repositório e persiste as mudanças no ficheiro JSON.
        /// </remarks>
        /// <param name="item">O item a ser removido do repositório.</param>
        public virtual void Remove(T item)
        {
            items.Remove(item);
            SaveChanges();
        }

        /// <summary>
        /// Atualiza um item no repositório.
        /// </summary>
        /// <remarks>
        /// Atualiza os dados de um item existente no repositório com base no seu ID.
        /// </remarks>
        /// <param name="itemAlterado">O item com os dados atualizados.</param>
        /// <exception cref="ArgumentNullException">Se o item fornecido for <c>null</c>.</exception>
        /// <exception cref="KeyNotFoundException">Se o item não for encontrado no repositório.</exception>
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

        /// <summary>
        /// Obtém um item pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Retorna o item correspondente ao ID fornecido, ou <c>null</c> se não encontrado.
        /// </remarks>
        /// <param name="id">Identificador único do item a ser recuperado.</param>
        /// <returns>O item correspondente ao ID fornecido, ou <c>null</c> se não encontrado.</returns>
        public virtual T GetById(int? id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Obtém um item com base em uma propriedade.
        /// </summary>
        /// <remarks>
        /// Retorna o primeiro item que possui a propriedade especificada com o valor fornecido.
        /// </remarks>
        /// <param name="propertySelector">Função que seleciona a propriedade a ser comparada.</param>
        /// <param name="value">Valor a ser comparado com a propriedade selecionada.</param>
        /// <returns>O item correspondente, ou <c>null</c> se não encontrado.</returns>
        public virtual T? GetByProperty(Func<T, object> propertySelector, object value)
        {
            return items.FirstOrDefault(item => propertySelector(item)?.Equals(value) == true);
        }
        #endregion
    }
    #endregion
}
