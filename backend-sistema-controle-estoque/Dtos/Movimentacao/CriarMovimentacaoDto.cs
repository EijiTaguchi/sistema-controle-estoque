using backend_sistema_controle_estoque.Models;

namespace backend_sistema_controle_estoque.Dtos.Movimentacao;

public record CriarMovimentacaoDto(
    int ProdutoId,
    TipoMovimentacao TipoMovimentacao,
    int Quantidade
    );
