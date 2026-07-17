using backend_sistema_controle_estoque.Dtos.Fornecedores;

namespace backend_sistema_controle_estoque.Services.Interfaces;

public interface IFornecedorService
{
    Task<FornecedorDto> CriarFornecedorAsync(CriarFornecedorDto dto);
    Task<FornecedorDto> AtualizarFornecedorAsync(AtualizarFornecedorDto dto);
    Task<IEnumerable<FornecedorDto>> ListarFornecedoresAsync();
    Task<FornecedorDto?> ObterFornecedorPorIdAsync(int id);
    Task<FornecedorDto> DesativarFornecedorAsync(int id);
}
