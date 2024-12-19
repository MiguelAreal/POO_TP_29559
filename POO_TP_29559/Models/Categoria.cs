using poo_tp_29559.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /**
     * @class Categoria
     * @brief Representa uma categoria de produtos.
     * 
     * A classe `Categoria` é utilizada para armazenar informações relacionadas a uma categoria de produtos no sistema.
     * Cada categoria possui um identificador único, nome, descrição e data de criação. Além disso, a classe oferece um
     * método para verificar se a categoria pode ser eliminada, o que é possível apenas caso não esteja associada a 
     * nenhum produto.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public class Categoria : IIdentifiable
    {
        /**
         * @brief Identificador único da categoria.
         * 
         * Este campo armazena o identificador único de cada categoria, utilizado para referenciar a categoria
         * no sistema.
         */
        public int Id { get; set; }

        /**
         * @brief Nome da categoria.
         * 
         * Este campo armazena o nome da categoria, que será utilizado para exibir a categoria no sistema.
         */
        [DisplayName("Nome")]
        public string? Nome { get; set; }

        /**
         * @brief Descrição da categoria.
         * 
         * Este campo armazena uma descrição mais detalhada sobre a categoria. Pode ser utilizada para fornecer
         * mais informações sobre os produtos que pertencem a esta categoria.
         */
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        /**
         * @brief Data de criação da categoria.
         * 
         * Este campo armazena a data em que a categoria foi criada. O valor é atribuído automaticamente
         * quando a categoria é instanciada, utilizando a data e hora atuais.
         */
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        /**
         * @brief Construtor da classe Categoria.
         * 
         * O construtor da classe inicializa o campo `DataCriacao` com a data e hora atuais, indicando
         * que a categoria foi criada no momento da sua instância.
         */
        public Categoria()
        {
            DataCriacao = DateTime.Now;
        }

        /**
         * @brief Verifica se a categoria pode ser eliminada.
         * 
         * Este método verifica se a categoria pode ser eliminada, garantindo que a categoria não esteja associada
         * a nenhum produto. Caso a categoria esteja associada a algum produto, ela não pode ser eliminada.
         * 
         * @param produtos Lista de produtos do sistema.
         * @return Retorna `true` se a categoria não estiver associada a nenhum produto e, portanto, pode ser eliminada;
         *         caso contrário, retorna `false`.
         */
        public bool PodeSerEliminada(List<Produto> produtos)
        {
            return !produtos.Any(p => p.CategoriaID == this.Id);
        }
    }
}
