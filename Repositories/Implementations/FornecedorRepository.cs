using backend_sistema_controle_estoque.Data;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_sistema_controle_estoque.Repositories.Implementations;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Fornecedor>> ObterTodosAsync()
    {
        return await _context.Fornecedores
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Fornecedor?> ObterPorIdAsync(int id)
    {
        return await _context.Fornecedores
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Fornecedor?> ObterPorCnpjAsync(string cnpj)
    {
        return await _context.Fornecedores
            .FirstOrDefaultAsync(f => f.Cnpj == cnpj);
    }

    public async Task AdicionarAsync(Fornecedor fornecedor)
    {
        await _context.Fornecedores.AddAsync(fornecedor);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Fornecedor fornecedor)
    {
        _context.Fornecedores.Update(fornecedor);
        await _context.SaveChangesAsync();
    }
}
