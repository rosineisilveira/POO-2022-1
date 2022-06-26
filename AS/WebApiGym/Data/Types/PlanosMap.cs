using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class PlanosMap : IEntityTypeConfiguration<Planos>
    {

        public void Configure(EntityTypeBuilder<Planos> builder)
        {
            builder.ToTable("planos");

            builder.Property(i => i.Id)
            .HasColumnName("id");   

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
            .HasColumnName("nome")
            .HasColumnType("Nvarchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(i => i.Valor)
            .HasColumnName("valor")
            .HasColumnType("decimal")
            .HasMaxLength(11)
            .IsRequired();
        }
    }
}