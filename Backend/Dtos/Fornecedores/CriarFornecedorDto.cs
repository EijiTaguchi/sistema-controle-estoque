using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record CriarFornecedorDto(
    [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve possuir de 3 a 100 caracteres.")]
    string Nome,
    
    [Required(ErrorMessage = "O CNPJ do fornecedor é obrigatório.")]
    [StringLength(18, MinimumLength = 14, ErrorMessage = "O CNPJ deve possuir de 14 a 18 caracteres.")]
    [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ informado é inválido.")]
    string Cnpj,

    [Required(ErrorMessage = "O telefone informado é inválido.")]
    [RegularExpression(@"^\(\d{2}\)\s\d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido.")]
    string Telefone,
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    string Email
);