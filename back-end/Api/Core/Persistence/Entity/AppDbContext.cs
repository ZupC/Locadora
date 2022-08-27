using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Api.Core.Persistence.Entity
{
    public class AppDbContext : DbContext
    {
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Locacao> Locacao { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost; database=locadora; user=root; port=3306;password=123456", ServerVersion.AutoDetect("server=localhost; database=locadora; user=root; port=3306;password=123456"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);

            #region Cliente
            var Cliente = builder.Entity<Cliente>();

            Cliente.ToTable("Cliente");
            Cliente.HasKey(p => p.Id);

            Cliente.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            Cliente.Property(p => p.Nome).IsRequired().HasMaxLength(200);
            Cliente.Property(p => p.CPF).IsRequired().HasMaxLength(11);
            Cliente.Property(p => p.DataNascimento).IsRequired().HasColumnType("Date");

            var clientes = new List<Cliente>()
            {
                new Cliente { Id = 1, Nome = "Germano Pereira" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) },
                new Cliente { Id = 2, Nome = "Pedro Teixeira" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) },
                new Cliente { Id = 3, Nome = "Eduardo Silva" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) },
                new Cliente { Id = 4, Nome = "Carlos Alberto" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) },
                new Cliente { Id = 5, Nome = "Fernanda Costa" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) },
                new Cliente { Id = 6, Nome = "Lethicia Menez" ,CPF ="11111111111", DataNascimento = new System.DateTime(1999, 3, 01) }
            };

            Cliente.HasData(clientes);
            #endregion

            #region Filme
            var Filme = builder.Entity<Filme>();

            Filme.ToTable("Filme");
            Filme.HasKey(p => p.Id);

            Filme.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            Filme.Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            Filme.Property(p => p.ClassificacaoIndicativa).IsRequired();
            Filme.Property(p => p.Lancamento).IsRequired();

            var filmes = new List<Filme>()
            {
                new Filme { Id = 1, Titulo = "harry potter", ClassificacaoIndicativa = 14, Lancamento = 1 },
                new Filme { Id = 2, Titulo = "Senhor dos aneis", ClassificacaoIndicativa = 16, Lancamento = 0 },
                new Filme { Id = 3, Titulo = "O alto da compadecida", ClassificacaoIndicativa = 18, Lancamento = 0 }
            };

            Filme.HasData(filmes);
            #endregion

            #region Locacao
            var Locacao = builder.Entity<Locacao>();

            Locacao.ToTable("Locacao");
            Locacao.HasKey(p => p.Id);

            Locacao.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            Locacao.Property(p => p.DataLocacao).IsRequired().HasColumnType("Date");
            Locacao.Property(p => p.DataDevolucao).IsRequired().HasColumnType("Date");
            Locacao.Property(p => p.Cliente).IsRequired().HasMaxLength(200);
            Locacao.Property(p => p.ClienteId).IsRequired();
            Locacao.Property(p => p.Filme).IsRequired().HasMaxLength(50);
            Locacao.Property(p => p.FilmeId).IsRequired();

            var locacoes = new List<Locacao>()
            {
                new Locacao
                {
                    Id = 1,
                    Cliente = "Germano Pereira",
                    ClienteId = 1,
                    Filme = "harry potter",
                    FilmeId = 1,
                    DataLocacao = new System.DateTime(2022, 8, 22),
                    DataDevolucao = new System.DateTime(2022, 8, 24),
                },
                new Locacao
                {
                    Id = 2,
                    Cliente = "Eduardo Silva",
                    ClienteId = 3,
                    Filme = "O alto da compadecida",
                    FilmeId = 3,
                    DataLocacao = new System.DateTime(2022, 8, 22),
                    DataDevolucao = new System.DateTime(2022, 8, 25),
                },
                new Locacao
                {
                    Id = 3,
                    Cliente = "Eduardo Silva",
                    ClienteId = 4,
                    Filme = "Senhor dos aneis",
                    FilmeId = 2,
                    DataLocacao = new System.DateTime(2022, 8, 22),
                    DataDevolucao = new System.DateTime(2022, 8, 25),
                },
                new Locacao
                {
                    Id = 4,
                    Cliente = "Pedro Teixeira",
                    ClienteId = 2,
                    Filme = "Senhor dos aneis",
                    FilmeId = 2,
                    DataLocacao = new System.DateTime(2022, 8, 22),
                    DataDevolucao = new System.DateTime(2022, 8, 25),
                },
            };

            Locacao.HasData(locacoes);
            #endregion
        }
    }
}
