using backend_sistema_controle_estoque.Dtos.Produtos;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using backend_sistema_controle_estoque.Services.Interfaces;

namespace backend_sistema_controle_estoque.Services.Implementations;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ProdutoDto> AtualizarProdutoAsync(AtualizarProdutoDto dto)
    {
        var produtoExistente = await _produtoRepository.BuscarPorIdAsync(dto.Id);
        if (produtoExistente == null)
        {
            throw new InvalidOperationException($"Produto com ID '{dto.Id}' não encontrado.");
        }

        produtoExistente.Atualizar(dto.Nome, dto.Preco , dto.FornecedorId);

        await _produtoRepository.AtualizarAsync(produtoExistente);

        return MapToProdutoDto(produtoExistente);
    }

    public async Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto dto)
    {
        var skuExistente = await _produtoRepository.BuscarPorSkuAsync(dto.Sku);
        if (skuExistente != null)
        {
            throw new InvalidOperationException($"Já existe um produto com o SKU '{dto.Sku}'.");
        }
       

        var produto = new Produto
        (
            dto.Nome,
            dto.Sku,
            dto.Preco,
            dto.FornecedorId);

        await _produtoRepository.AdicionarAsync(produto);

        return MapToProdutoDto(produto);
    }

    public async Task<ProdutoDto> DesativarProdutoAsync(int id)
    {
        var produtoExistente = await _produtoRepository.BuscarPorIdAsync(id);
        if (produtoExistente == null)
        {
            throw new InvalidOperationException($"Produto com ID '{id}' não encontrado.");
        }

        produtoExistente.Desativar();

        await _produtoRepository.DesativarAsync(produtoExistente);

        return MapToProdutoDto(produtoExistente);
    }

    public async Task<ProdutoPaginadoDto> ListarProdutosAsync(string? busca,int pagina,int tamanhoPagina)
    {
        if (pagina < 1)
        {
            pagina = 1;
        }

        if (tamanhoPagina < 1)
        {
            tamanhoPagina = 10;
        }

        if (tamanhoPagina > 100)
        {
            tamanhoPagina = 100;
        }

        var resultado = await _produtoRepository.ListarPaginadoAsync(
            busca,
            pagina,
            tamanhoPagina
        );

        var produtos = resultado.Produtos
            .Select(MapToProdutoDto)
            .ToList();

        var totalPaginas = (int)Math.Ceiling(
            resultado.TotalRegistros / (double)tamanhoPagina
        );

        return new ProdutoPaginadoDto(
            produtos,
            pagina,
            tamanhoPagina,
            resultado.TotalRegistros,
            totalPaginas
        );
    }

    public async Task<ProdutoDto> ObterProdutoPorIdAsync(int id)
    {
        var produto = await _produtoRepository.BuscarPorIdAsync(id);
        if (produto == null)
        {
            throw new InvalidOperationException($"Produto com ID '{id}' não encontrado.");
        }

        return MapToProdutoDto(produto);
    }

    private static ProdutoDto MapToProdutoDto(Produto produto)
    {
        return new ProdutoDto
        (
            produto.Id,
            produto.Nome,
            produto.Sku,
            produto.Preco,
            produto.QuantidadeEmEstoque,
            produto.Ativo,
            produto.FornecedorId,
            produto.Fornecedor.Nome
        );
    }
}