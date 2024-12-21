using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Controlador para a gestão de categorias.
/// Implementa a lógica para a gestão das categorias, incluindo operações de leitura,
/// remoção e verificação de condições para eliminação de categorias associadas a produtos.
/// Herda de <see cref="BaseController{Categoria}"/> e implementa a interface <see cref="IEntityController"/>.
/// </summary>
public class CategoriaController : BaseController<Categoria>, IEntityController
{
    /// <summary>
    /// Construtor da classe <see cref="CategoriaController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde as categorias serão armazenadas.
    /// </summary>
    public CategoriaController() : base("Data/categorias.json") { }

    /// <summary>
    /// Remove uma categoria do repositório.
    /// Este método sobrepõe o método <see cref="BaseController{T}.RemoveItem"/> da classe base
    /// e tenta remover a categoria fornecida do repositório, mas apenas se a categoria não estiver associada a nenhum produto.
    /// Caso contrário, é exibida uma mensagem de erro.
    /// </summary>
    /// <param name="item">A categoria a ser removida.</param>
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
