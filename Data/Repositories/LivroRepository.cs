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
        private readonly DbContext _context;

        public LivroRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddLivro(Livro livro)
        {
            _context.Set<Livro>().Add(livro);
            _context.SaveChanges();
        }

        public Livro GetLivroById(int livroId)
        {
            return _context.Set<Livro>().Find(livroId);
        }
    }
}