using backend_sistema_controle_estoque.Dtos.Produtos;

namespace backend_sistema_controle_estoque.Services.Interfaces;

public interface IProdutoService
{
    Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto dto);
    Task<ProdutoDto> AtualizarProdutoAsync(AtualizarProdutoDto dto);
    Task<ProdutoDto> DesativarProdutoAsync(int id);
   
}
