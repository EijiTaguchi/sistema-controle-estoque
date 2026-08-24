namespace backend_sistema_controle_estoque.Dtos.Produtos;

public record ProdutoPaginadoDto(
    IEnumerable<ProdutoDto> Dados,
    int Pagina,
    int TamanhoPagina,
    int TotalRegistros,
    int TotalPaginas
);