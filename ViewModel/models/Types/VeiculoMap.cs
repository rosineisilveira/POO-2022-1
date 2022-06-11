using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViewModel.models.domain;

namespace ViewModel.models.Types
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("customer");

            builder.Property(i => i.Id)
            .HasColumnName("id");   

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
            .HasColumnName("nome")
            .HasColumnType("Nvarchar")
            .HasMaxLength(50)
            .IsRequired();

             builder.Property(i => i.AnoFabricacao)
            .HasColumnName("fabricacao")
            .HasColumnType("Smalldatetime")
            .IsRequired();
        }
    }
}