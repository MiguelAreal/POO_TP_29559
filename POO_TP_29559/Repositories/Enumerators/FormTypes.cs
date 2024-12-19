/**
 * @file FormTypes.cs
 * @brief Enumeração para os tipos de formulários disponíveis na aplicação.
 * 
 * Esta enumeração define os tipos de formulários que a aplicação utiliza para a gestão de diferentes
 * entidades, como produtos, categorias, marcas, entre outros. A enumeração é utilizada em várias 
 * partes da aplicação para identificar e aceder aos diferentes tipos de formulários.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

namespace poo_tp_29559.Repositories.Enumerators
{
    /**
     * @enum FormTypes
     * @brief Enumeração que representa os tipos de formulários na aplicação.
     * 
     * A enumeração `FormTypes` contém os diferentes tipos de formulários utilizados
     * na aplicação para a gestão de várias entidades. Cada valor da enumeração corresponde
     * a um tipo específico de formulário, sendo utilizado para realizar operações de
     * manipulação e visualização de dados em diferentes áreas da aplicação.
     */
    public enum FormTypes
    {
        /**
         * @brief Formulário para gestão de produtos.
         * 
         * Este tipo de formulário é utilizado para realizar operações de criação,
         * leitura, atualização e remoção (CRUD) de produtos na aplicação.
         */
        Produtos,

        /**
         * @brief Formulário para gestão de categorias de produtos.
         * 
         * Este tipo de formulário permite realizar operações de CRUD sobre as categorias
         * de produtos.
         */
        Categorias,

        /**
         * @brief Formulário para gestão de marcas de produtos.
         * 
         * Utilizado para realizar operações de CRUD sobre as marcas associadas aos produtos.
         */
        Marcas,

        /**
         * @brief Formulário para gestão de vendas.
         * 
         * Este tipo de formulário é utilizado para a gestão de transações de vendas,
         * permitindo o controlo e registo das vendas realizadas.
         */
        Vendas,

        /**
         * @brief Formulário para gestão de utilizadores da aplicação.
         * 
         * Permite a gestão de utilizadores do sistema, incluindo operações como
         * criação, atualização e remoção de utilizadores.
         */
        Utilizadores,

        /**
         * @brief Formulário para gestão de campanhas promocionais.
         * 
         * Utilizado para gerir as campanhas promocionais dentro da aplicação,
         * incluindo a criação, monitorização e edição de campanhas.
         */
        Campanhas,

        /**
         * @brief Formulário para gestão de compras.
         * 
         * Este tipo de formulário é utilizado para gerir as compras realizadas,
         * permitindo a adição, edição e remoção de registos de compras na aplicação.
         */
        Compras
    }
}
