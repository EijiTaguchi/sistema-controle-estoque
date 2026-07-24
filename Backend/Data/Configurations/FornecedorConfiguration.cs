using backend_sistema_controle_estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_sistema_controle_estoque.Data.Configurations;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedores");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Cnpj)
            .HasMaxLength(14)
            .IsRequired();

        builder.HasIndex(f => f.Cnpj)
            .IsUnique();

        builder.Property(f => f.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.Telefone)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(f => f.Ativo)
            .IsRequired();

    }
}
