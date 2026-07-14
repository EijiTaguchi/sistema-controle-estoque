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
        var produtoExistente = await _produtoRepository.BuscarPorIdAsync(dto.id);
        if (produtoExistente == null)
        {
            throw new InvalidOperationException($"Produto com ID '{dto.id}' não encontrado.");
        }

        produtoExistente.Atualizar(dto.nome, dto.preco, dto.fornecedorId);

        await _produtoRepository.AtualizarAsync(produtoExistente);  

        return new ProdutoDto
        (
            produtoExistente.Id,
            produtoExistente.Nome,
            produtoExistente.Sku,
            produtoExistente.Preco,
            produtoExistente.QuantidadeEmEstoque,
            produtoExistente.Ativo,
            produtoExistente.FornecedorId
        );
    }

    public async Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto dto)
    {
        var skuExistente = await _produtoRepository.BuscarPorSkuAsync(dto.sku);
        if (skuExistente != null)
        {
            throw new InvalidOperationException($"Já existe um produto com o SKU '{dto.sku}'.");
        }
       

        var produto = new Produto
        (
            dto.nome,
            dto.sku,
            dto.preco,
            dto.fornecedorId);

        await _produtoRepository.AdicionarAsync(produto);

        return new ProdutoDto
        (
            produto.Id,
            produto.Nome,
            produto.Sku,
            produto.Preco,
            produto.QuantidadeEmEstoque,
            produto.Ativo,
            produto.FornecedorId
            );
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

        return new ProdutoDto
        (
            produtoExistente.Id,
            produtoExistente.Nome,
            produtoExistente.Sku,
            produtoExistente.Preco,
            produtoExistente.QuantidadeEmEstoque,
            produtoExistente.Ativo,
            produtoExistente.FornecedorId
        );
    }
}