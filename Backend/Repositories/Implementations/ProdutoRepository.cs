using backend_sistema_controle_estoque.Data;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_sistema_controle_estoque.Repositories.Implementations;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> AdicionarAsync(Produto produto)
    {
       await _context.Produtos.AddAsync(produto);
       await _context.SaveChangesAsync();
       return produto;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<IReadOnlyCollection<Produto>> BuscarPorFornecedorAsync(int fornecedorId)
    {
        return await _context.Produtos
            .Include(p => p.Fornecedor)
            .Where(p => p.FornecedorId == fornecedorId)
            .ToListAsync();
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        return await _context.Produtos
            .Include(p => p.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyCollection<Produto>> BuscarPorNomeAsync(string nome)
    {
        return await _context.Produtos
            .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
            .ToListAsync();
    }

    public async Task<Produto?> BuscarPorSkuAsync(string sku)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(p => p.Sku == sku);
    }

    public async Task<Produto> DesativarAsync(Produto produto)
    {
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<(IReadOnlyCollection<Produto> Produtos, int TotalRegistros)>
    ListarPaginadoAsync(
        string? busca,
        int pagina,
        int tamanhoPagina)
    {
        var query = _context.Produtos
            .Include(p => p.Fornecedor)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(busca))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.Nome, $"%{busca}%") ||
                EF.Functions.Like(p.Sku, $"%{busca}%"));
        }

        var totalRegistros = await query.CountAsync();

        var produtos = await query
            .OrderBy(p => p.Nome)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

        return (produtos, totalRegistros);
    }

    public async Task<IEnumerable<Produto?>> ListarTodosAsync()
    {
        return await _context.Produtos
            .Include(p => p.Fornecedor)
            .ToListAsync();
    }
}
