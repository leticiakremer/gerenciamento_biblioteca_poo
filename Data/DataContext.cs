using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeBiblioteca.Domain.Entities;
using System.IO;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        public DataContext()
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Combine(path, "Biblioteca.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Livros)
                .UsingEntity(j => j.ToTable("LivroAutor"));

            modelBuilder.Entity<Livro>()
                .HasMany(l => l.UsuariosEmprestimo)
                .WithMany(u => u.LivrosEmprestados)
                .UsingEntity(j => j.ToTable("LivroUsuario"));

            // Outras configurações do modelo, se necessário
        }
    }


}
