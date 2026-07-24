using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Repositories.Interfaces;

public interface IFornecedorRepository
{
    Task<IEnumerable<Fornecedor>> ObterTodosAsync();
    Task<Fornecedor?> ObterPorIdAsync(int id);
    Task<Fornecedor?> ObterPorCnpjAsync(string cnpj);
    Task AdicionarAsync(Fornecedor fornecedor);
    Task AtualizarAsync(Fornecedor fornecedor);
}