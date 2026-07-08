using backend_sistema_controle_estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_sistema_controle_estoque.Data.Configurations;

public class MovimentacaoEstoqueConfiguration : IEntityTypeConfiguration<MovimentacaoEstoque>
{
    public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
    {
        builder.ToTable("Movimentacoes");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.TipoMovimentacao)
            .IsRequired();

        builder.Property(m => m.Quantidade)
            .IsRequired();

        builder.Property(m => m.DataHora)
            .IsRequired();


        builder.HasOne(m => m.Produto)
            .WithMany(u => u.Movimentacoes)
            .HasForeignKey(m => m.ProdutoId);

        builder.HasOne(m => m.Usuario)
            .WithMany(u => u.Movimentacoes)
            .HasForeignKey(m => m.UsuarioId);
    }

}

