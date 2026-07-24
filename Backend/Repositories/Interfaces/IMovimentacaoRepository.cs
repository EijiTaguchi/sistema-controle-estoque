using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Repositories.Interfaces;

public interface IMovimentacaoRepository
{
    Task<MovimentacaoEstoque?> ObterMovimentacaoPorIdAsync(int id);
    Task<IEnumerable<MovimentacaoEstoque>> ObterTodasMovimentacoesAsync();
    Task<MovimentacaoEstoque> AdicionarMovimentacaoAsync(MovimentacaoEstoque movimentacao);
}
