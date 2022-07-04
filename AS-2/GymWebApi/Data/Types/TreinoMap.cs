using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class TreinoMap : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.ToTable("treino");

            builder.Property(i => i.Id)
            .HasColumnName("id");   

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
            .HasColumnName("nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(i => i.InstrutorId)
            .HasColumnName("instrutor_id")
            .HasColumnType("INTEGER")
            .IsRequired();

            //Relacionamentos

            builder.HasOne(x => x.Instrutor)
                .WithMany(x => x.Treinos)
                .HasConstraintName("FK_Treino_Instrutor")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.Exercicios)
                .WithMany(i => i.Treinos)
                .UsingEntity<Dictionary<string, object>>(
                    "treino_exercicio",
                    exercicio => exercicio
                        .HasOne<Exercicio>()
                        .WithMany()
                        .HasForeignKey("exercicio_id")
                        .HasConstraintName("FK_treino_exercicio_exercicio_id")
                        .OnDelete(DeleteBehavior.Restrict),
                    treino => treino
                        .HasOne<Treino>()
                        .WithMany()
                        .HasForeignKey("treino_id")
                        .HasConstraintName("FK_treino_exercicio_treino_id")
                        .OnDelete(DeleteBehavior.Restrict));

            /*builder
                .HasMany(i => i.Matriculas)
                .WithMany(i => i.Treinos)
                .UsingEntity<Dictionary<string, object>>(
                    "treino_matricula",
                    matricula => matricula
                        .HasOne<Matricula>()
                        .WithMany()
                        .HasForeignKey("matricula_id")
                        .HasConstraintName("FK_treino_matricula_matricula_id")
                        .OnDelete(DeleteBehavior.Restrict),
                    treino => treino
                        .HasOne<Treino>()
                        .WithMany()
                        .HasForeignKey("treino_id")
                        .HasConstraintName("FK_treino_matricula_treino_id")
                        .OnDelete(DeleteBehavior.Restrict));*/
        }
    }
}