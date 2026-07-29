using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record AtualizarFornecedorDto(
    int id,
    [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve possuir de 3 a 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O telefone informado é inválido.")]
    [RegularExpression(@"^\(\d{2}\)\s\d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido.")]
    string Telefone,

    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    string Email
);
