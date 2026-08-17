using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record AtualizarProdutoDto(
    int Id,

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve possuir de 3 a 100 caracteres.")]
    string Nome,

    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    decimal Preco,

    [Range(1, int.MaxValue, ErrorMessage = "Fornecedor inválido.")]
    int FornecedorId
    );
