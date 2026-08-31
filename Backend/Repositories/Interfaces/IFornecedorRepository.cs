using backend_sistema_controle_estoque.Dtos.Fornecedores;
using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Repositories.Interfaces;

public interface IFornecedorRepository
{

    Task<(IReadOnlyCollection<Fornecedor> Dados, int TotalRegistros)>
        ObterPaginadoAsync(
            string? busca,
            int pagina,
            int tamanhoPagina
        );

    Task<Fornecedor?> ObterPorIdAsync(int id);
    Task<Fornecedor?> ObterPorCnpjAsync(string cnpj);
    Task AdicionarAsync(Fornecedor fornecedor);
    Task AtualizarAsync(Fornecedor fornecedor);
}