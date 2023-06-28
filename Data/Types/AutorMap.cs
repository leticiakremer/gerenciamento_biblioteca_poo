using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoDeBiblioteca.Data.Types
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Autor> builder)
        {

            builder.ToTable("autor");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Livros);

            builder.Property(i => i.Nome).HasColumnName("nome");
            builder.Property(i => i.Nome).IsRequired();
        }
    }
}