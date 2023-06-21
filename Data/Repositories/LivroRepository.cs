using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class LivroRepository
    {
        private readonly DbContext context;

        public LivroRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public void AddLivro(Livro livro)
        {
            context.Set<Livro>().Add(livro);
            context.SaveChanges();
        }

        public Livro GetLivroById(int livroId)
        {
            return context.Set<Livro>().Find(livroId);
        }
    }
}