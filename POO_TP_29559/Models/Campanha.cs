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
     * @class Campanha
     * @brief Representa uma campanha de marketing ou promoção.
     * 
     * A classe `Campanha` armazena informações sobre campanhas promocionais, incluindo o nome, a percentagem de desconto, as datas de início e fim, e a categoria à qual a campanha está associada. 
     * Esta classe implementa a interface `IIdentifiable`, permitindo que cada campanha tenha um identificador único.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public class Campanha : IIdentifiable
    {
        /**
         * @brief Identificador único da campanha.
         * 
         * Este campo armazena o identificador único de cada campanha.
         */
        public int Id { get; set; }

        /**
         * @brief Nome da campanha.
         * 
         * Este campo armazena o nome da campanha, que será exibido na interface de utilizador.
         */
        [DisplayName("Nome de Campanha")]
        public string? Nome { get; set; }

        /**
         * @brief Percentagem de desconto da campanha.
         * 
         * Este campo armazena a percentagem de desconto oferecida pela campanha. 
         * O valor deve ser uma porcentagem, como 10.00 para um desconto de 10%.
         */
        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }

        /**
         * @brief Data de início da campanha.
         * 
         * Este campo armazena a data de início da campanha. A data deve ser fornecida como uma string no formato adequado.
         */
        [DisplayName("Data de Inicio")]
        public string? DataInicio { get; set; }

        /**
         * @brief Data de fim da campanha.
         * 
         * Este campo armazena a data de fim da campanha. A data deve ser fornecida como uma string no formato adequado.
         */
        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }

        /**
         * @brief Identificador da categoria associada à campanha.
         * 
         * Este campo armazena o identificador da categoria à qual a campanha está associada. 
         * Cada campanha pode ser aplicada a uma categoria específica de produtos.
         */
        [DisplayName("Categoria Aplicada")]
        public int CategoriaId { get; set; }
    }
}
