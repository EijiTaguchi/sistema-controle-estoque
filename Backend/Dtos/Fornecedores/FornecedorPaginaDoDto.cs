namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record FornecedorPaginaDoDto
(
    IEnumerable<FornecedorDto> Dados,
    int Pagina,
    int TamanhoPagina,
    int TotalRegistros,
    int TotalPaginas
);
