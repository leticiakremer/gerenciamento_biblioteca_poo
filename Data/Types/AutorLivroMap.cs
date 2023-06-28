using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoDeBiblioteca.Data.Types
{
    public class AutorLivroMap : IEntityTypeConfiguration<AutorLivro>
    {
        public void Configure(EntityTypeBuilder<AutorLivro> builder)
        {
            builder.ToTable("autor_livro");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.AutorId).IsRequired();
            builder.Property(i => i.AutorId).HasColumnName("autor_id");
            builder.HasOne(i => i.Autor)
                .WithMany(i => i.Livros)
                .HasForeignKey(i => i.AutorId);

            builder.Property(i => i.LivroId).IsRequired();
            builder.Property(i => i.LivroId).HasColumnName("livro_id");
            builder.HasOne(i => i.Livro)
                .WithMany(i => i.Autores)
                .HasForeignKey(i => i.LivroId);
        }
    }



}