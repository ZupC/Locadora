﻿// <auto-generated />
using System;
using Api.Core.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Germano Pereira"
                        },
                        new
                        {
                            Id = 2,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Pedro Teixeira"
                        },
                        new
                        {
                            Id = 3,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Eduardo Silva"
                        },
                        new
                        {
                            Id = 4,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Carlos Alberto"
                        },
                        new
                        {
                            Id = 5,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Fernanda Costa"
                        },
                        new
                        {
                            Id = 6,
                            CPF = "11111111111",
                            DataNascimento = new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Lethicia Menez"
                        });
                });

            modelBuilder.Entity("Api.Domain.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassificacaoIndicativa")
                        .HasColumnType("int");

                    b.Property<int>("Lancamento")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Filme", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassificacaoIndicativa = 14,
                            Lancamento = 1,
                            Titulo = "harry potter"
                        },
                        new
                        {
                            Id = 2,
                            ClassificacaoIndicativa = 16,
                            Lancamento = 0,
                            Titulo = "Senhor dos aneis"
                        },
                        new
                        {
                            Id = 3,
                            ClassificacaoIndicativa = 18,
                            Lancamento = 0,
                            Titulo = "O alto da compadecida"
                        });
                });

            modelBuilder.Entity("Api.Domain.Models.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("Date");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locacao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            DataDevolucao = new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataLocacao = new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FilmeId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 3,
                            DataDevolucao = new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataLocacao = new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FilmeId = 3
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 5,
                            DataDevolucao = new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataLocacao = new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FilmeId = 2
                        },
                        new
                        {
                            Id = 4,
                            ClienteId = 6,
                            DataDevolucao = new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataLocacao = new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FilmeId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}