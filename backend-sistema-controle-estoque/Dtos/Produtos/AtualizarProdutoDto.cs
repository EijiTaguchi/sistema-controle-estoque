namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record AtualizarProdutoDto(
    int id,
    string nome,
    string sku,
    decimal preco,
    int fornecedorId
    );
