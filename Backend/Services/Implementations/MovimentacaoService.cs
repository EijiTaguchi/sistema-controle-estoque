using backend_sistema_controle_estoque.Dtos.Movimentacao;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using backend_sistema_controle_estoque.Services.Interfaces;

namespace backend_sistema_controle_estoque.Services.Implementations;

public class MovimentacaoService : IMovimentacaoService
{

    private readonly IMovimentacaoRepository _movimentacaoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, IProdutoRepository produtoRepository)
    {
        _movimentacaoRepository = movimentacaoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<MovimentacaoDto> AdicionarMovimentacaoAsync(CriarMovimentacaoDto dto)
    {

        var produto = await _produtoRepository.BuscarPorIdAsync(dto.ProdutoId);

        if (produto is null)
            throw new KeyNotFoundException("Produto não encontrado.");

        switch (dto.TipoMovimentacao)
        {
            case TipoMovimentacao.Entrada:
                produto.EntradaEstoque(dto.Quantidade);
                break;

            case TipoMovimentacao.Saida:
                produto.SaidaEstoque(dto.Quantidade);
                break;

            default:
                throw new KeyNotFoundException("Tipo de movimentação inválido.");
        }

        var movimentacao = new MovimentacaoEstoque
          (
            dto.TipoMovimentacao,
            dto.Quantidade,
            dto.ProdutoId,
            dto.UsuarioId
           );

        await _produtoRepository.AtualizarAsync(produto);

        await _movimentacaoRepository.AdicionarMovimentacaoAsync(movimentacao);

        return MapearParaDto(movimentacao, produto);

    }

    public async Task<MovimentacaoDto> ObterMovimentacaoPorIdAsync(int id)
    {
        var movimentacao = await _movimentacaoRepository.ObterMovimentacaoPorIdAsync(id);

        if (movimentacao is null)
            throw new KeyNotFoundException("Movimentação não encontrada.");

        return MapearParaDto(movimentacao, movimentacao.Produto);

    }

    public async Task<IEnumerable<MovimentacaoDto>> ObterTodasMovimentacoesAsync()
    {
        var movimentacoes = await _movimentacaoRepository.ObterTodasMovimentacoesAsync();

        return movimentacoes.Select(m => MapearParaDto(m, m.Produto));
    }

    private static MovimentacaoDto MapearParaDto(MovimentacaoEstoque movimentacao, Produto produto)
    {
        return new MovimentacaoDto
        (
            movimentacao.Id,
            movimentacao.UsuarioId,
            produto.Nome,
            produto.Sku,
            movimentacao.TipoMovimentacao,
            movimentacao.Quantidade,
            movimentacao.DataHora
        );
    }
}
