using System.ComponentModel.DataAnnotations;

namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record AtualizarFornecedorDto(
    int id,
    [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve possuir de 3 a 100 caracteres.")]
    string Nome,
    [Phone(ErrorMessage = "O telefone informado é inválido.")]
    string Telefone,
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    string Email
);
