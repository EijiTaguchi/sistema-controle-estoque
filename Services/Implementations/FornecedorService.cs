using backend_sistema_controle_estoque.Dtos.Fornecedores;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using backend_sistema_controle_estoque.Services.Interfaces;

namespace backend_sistema_controle_estoque.Services.Implementations;

public class FornecedorService : IFornecedorService
{

    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }


    public async Task<FornecedorDto> AtualizarFornecedorAsync(AtualizarFornecedorDto dto)
    {
        var fornecedorExistente = await _fornecedorRepository.ObterPorIdAsync(dto.id);

        if (fornecedorExistente == null )
            throw new InvalidOperationException("Fornecedor não encontrado.");

        fornecedorExistente.Atualizar(dto.Nome, dto.Telefone, dto.Email);

        await _fornecedorRepository.AtualizarAsync(fornecedorExistente);

        return MapearParaDto(fornecedorExistente);
    }

    public async Task<FornecedorDto> CriarFornecedorAsync(CriarFornecedorDto dto)
    {
        var fornecedorExistente = await _fornecedorRepository.ObterPorCnpjAsync(dto.Cnpj);

        if (fornecedorExistente != null)
            throw new InvalidOperationException("Fornecedor já existe.");

        var fornecedor = new Fornecedor
        (
            dto.Nome,
            dto.Cnpj,
            dto.Telefone,
            dto.Email
        );

        await _fornecedorRepository.AdicionarAsync(fornecedor);

        return MapearParaDto(fornecedor);

    }

    public async Task<FornecedorDto> DesativarFornecedorAsync(int id)
    {
        var fornecedorExistente = await _fornecedorRepository.ObterPorIdAsync(id);

        if (fornecedorExistente == null)
            throw new InvalidOperationException("Fornecedor não encontrado.");

        fornecedorExistente.Desativar();

        await _fornecedorRepository.AtualizarAsync(fornecedorExistente);

        return MapearParaDto(fornecedorExistente);
    }

    public async Task<IEnumerable<FornecedorDto>> ListarFornecedoresAsync()
    {
        var fornecedores = await _fornecedorRepository.ObterTodosAsync();

        return fornecedores.Select(MapearParaDto);

    }

    public async Task<FornecedorDto?> ObterFornecedorPorIdAsync(int id)
    {
        var fornecedor = await _fornecedorRepository.ObterPorIdAsync(id);

        if (fornecedor == null)
            return null;

        return MapearParaDto(fornecedor);
    }

    private static FornecedorDto MapearParaDto(Fornecedor fornecedor)
    {
        return new FornecedorDto(
            fornecedor.Id,
            fornecedor.Nome,
            fornecedor.Cnpj,
            fornecedor.Telefone,
            fornecedor.Email
        );
    }

}
