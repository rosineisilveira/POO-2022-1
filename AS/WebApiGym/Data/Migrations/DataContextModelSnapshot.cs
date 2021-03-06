// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("nome");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("aluno", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Repeticao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Series")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DbSetExercicio");
                });

            modelBuilder.Entity("Domain.Entities.Instrutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("instrutor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Mensalidadeid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TreinoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("Mensalidadeid");

                    b.HasIndex("TreinoId");

                    b.ToTable("DbSetMatricula");
                });

            modelBuilder.Entity("Domain.Entities.Planos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("valor")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("DbSetPlanos");
                });

            modelBuilder.Entity("Domain.Entities.Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExercicioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstrutorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("InstrutorId");

                    b.ToTable("DbSetTreino");
                });

            modelBuilder.Entity("Domain.Entities.Matricula", b =>
                {
                    b.HasOne("Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("Domain.Entities.Planos", "Mensalidade")
                        .WithMany()
                        .HasForeignKey("Mensalidadeid");

                    b.HasOne("Domain.Entities.Treino", "Treino")
                        .WithMany()
                        .HasForeignKey("TreinoId");

                    b.Navigation("Aluno");

                    b.Navigation("Mensalidade");

                    b.Navigation("Treino");
                });

            modelBuilder.Entity("Domain.Entities.Treino", b =>
                {
                    b.HasOne("Domain.Entities.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId");

                    b.HasOne("Domain.Entities.Instrutor", "Instrutor")
                        .WithMany()
                        .HasForeignKey("InstrutorId");

                    b.Navigation("Exercicio");

                    b.Navigation("Instrutor");
                });
#pragma warning restore 612, 618
        }
    }
}
