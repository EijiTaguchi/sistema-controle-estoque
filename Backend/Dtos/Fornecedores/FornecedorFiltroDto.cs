namespace backend_sistema_controle_estoque.Dtos.Fornecedores;

public record FornecedorFiltroDto
(
    string? Busca,
    int Pagina = 1,
    int TamanhoPagina = 10
);
