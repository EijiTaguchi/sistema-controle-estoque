using backend_sistema_controle_estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Movimentacao;

public record CriarMovimentacaoDto(
    [Range(1, int.MaxValue, ErrorMessage = "O ID do produto é obrigatório.")]
    int ProdutoId,

    [Required( ErrorMessage = "O ID do usuário é obrigatório.")]
    string UsuarioId,

    [Range(1, 2, ErrorMessage = "O tipo de movimentação só pode ser 1(Entrada) ou 2(Saída).")]
    TipoMovimentacao TipoMovimentacao,

    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    int Quantidade
    );
