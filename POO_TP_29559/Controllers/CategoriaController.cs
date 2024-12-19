using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

/**
 * @class CategoriaController
 * @brief Controlador para a gestão de categorias.
 * 
 * A classe `CategoriaController` implementa a lógica para a gestão das categorias, incluindo operações de leitura,
 * remoção e verificação de condições para eliminação de categorias associadas a produtos. Herda de `BaseController<Categoria>`
 * e implementa a interface `IEntityController`, oferecendo funcionalidades específicas para o trabalho com categorias.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class CategoriaController : BaseController<Categoria>, IEntityController
{
    /**
     * @brief Construtor da classe `CategoriaController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde as categorias serão armazenadas.
     */
    public CategoriaController() : base("Data/categorias.json") { }

    /**
     * @brief Remove uma categoria do repositório.
     * 
     * Este método sobrepõe o método `RemoveItem` da classe base e tenta remover a categoria fornecida do repositório,
     * mas apenas se a categoria não estiver associada a nenhum produto. Caso contrário, é exibida uma mensagem de erro.
     * 
     * @param item A categoria a ser removida.
     */
    public override void RemoveItem(object item)
    {
        if (item is Categoria specificItem)
        {
            var produtos = new ProdutoRepo().GetAll();

            if (specificItem.PodeSerEliminada(produtos))
            {
                _repository.Remove(specificItem);
            }
            else
            {
                MessageBox.Show("Esta categoria não pode ser eliminada porque está associada a um ou mais produtos.");
            }
        }

      
    }
}
