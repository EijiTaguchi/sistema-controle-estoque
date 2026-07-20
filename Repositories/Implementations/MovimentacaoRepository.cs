using backend_sistema_controle_estoque.Data;
using backend_sistema_controle_estoque.Models;
using backend_sistema_controle_estoque.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_sistema_controle_estoque.Repositories.Implementations;

public class MovimentacaoRepository : IMovimentacaoRepository
{

    private readonly AppDbContext _context;

    public MovimentacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MovimentacaoEstoque> AdicionarMovimentacaoAsync(MovimentacaoEstoque movimentacao)
    {
        await _context.Movimentacoes.AddAsync(movimentacao);
        await _context.SaveChangesAsync();
        return movimentacao;
    }

    public async Task<MovimentacaoEstoque?> ObterMovimentacaoPorIdAsync(int id)
    {
        return await _context.Movimentacoes
            .Include(m => m.Produto)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<MovimentacaoEstoque>> ObterTodasMovimentacoesAsync()
    {
        return await _context.Movimentacoes
            .Include(m => m.Produto)
            .AsNoTracking()
            .ToListAsync();
    }
}
