namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record ProdutoDto(
    int Id,
    string Nome,
    string Sku,
    decimal Preco,
    int QuantidadeEstoque,
    bool Ativo,
    int FornecedorId
    );
