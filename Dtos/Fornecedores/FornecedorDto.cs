namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record FornecedorDto(
    int Id,
    string Nome,
    string Cnpj,
    string Telefone,
    string Email
);