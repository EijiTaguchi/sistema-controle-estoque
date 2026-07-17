namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record AtualizarFornecedorDto(
    int id,
    string Nome,
    string Telefone,
    string Email
);
