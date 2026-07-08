using backend_sistema_controle_estoque.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend_sistema_controle_estoque.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    DbSet<Produto> Produtos { get; set; } = null!;
    DbSet<Fornecedor> Fornecedores { get; set; } = null!;
    DbSet<MovimentacaoEstoque> Movimentacoes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
