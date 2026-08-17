namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record ProdutoFiltroDto
(
    string? Busca,
    int Pagina = 1,
    int TamanhoPagina = 10
);
