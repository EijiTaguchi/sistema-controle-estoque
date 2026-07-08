namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record CriarProdutoDto(
    string nome,
    string sku,
    decimal preco,
    int fornecedorId
    );
