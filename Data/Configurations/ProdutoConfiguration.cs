using backend_sistema_controle_estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_sistema_controle_estoque.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{

    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Sku)
              .IsRequired()
              .HasMaxLength(50);

        builder.HasIndex(p => p.Sku)
            .IsUnique();

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasPrecision(18,2);

        builder.HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos)
            .HasForeignKey(p => p.FornecedorId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
