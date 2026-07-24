using backend_sistema_controle_estoque.Models;
using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Movimentacao;

public record MovimentacaoDto(
    int Id,
    string NomeUsuario,
    string NomeProduto,
    string SkuProduto,
    TipoMovimentacao TipoMovimentacao,
    int Quantidade,
    DateTime DataHora
    );