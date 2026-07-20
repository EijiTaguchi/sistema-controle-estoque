using backend_sistema_controle_estoque.Dtos.Movimentacao;

namespace backend_sistema_controle_estoque.Services.Interfaces;

public interface IMovimentacaoService
{
    Task<MovimentacaoDto> AdicionarMovimentacaoAsync(CriarMovimentacaoDto dto);
    Task<IEnumerable<MovimentacaoDto>> ObterTodasMovimentacoesAsync();
    Task<MovimentacaoDto> ObterMovimentacaoPorIdAsync(int id);
}
