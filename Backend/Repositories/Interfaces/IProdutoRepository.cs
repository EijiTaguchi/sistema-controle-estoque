using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Repositories.Interfaces;

public interface IProdutoRepository
{
    Task<Produto?> BuscarPorIdAsync(int id);
    Task<Produto?> BuscarPorSkuAsync(string sku);
    Task<IReadOnlyCollection<Produto>> BuscarPorNomeAsync(string nome);
    Task<IReadOnlyCollection<Produto>> BuscarPorFornecedorAsync(int fornecedorId);

    Task<IEnumerable<Produto?>> ListarTodosAsync();

    Task<(IReadOnlyCollection<Produto> Produtos, int TotalRegistros)>
       ListarPaginadoAsync(
           string? busca,
           int pagina,
           int tamanhoPagina
       );

    Task<Produto> AdicionarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<Produto> DesativarAsync(Produto produto);

}
