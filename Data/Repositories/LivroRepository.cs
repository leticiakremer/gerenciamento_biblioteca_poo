using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class LivroRepository : ILivroRepository
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

        public void DeleteLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public IList<Livro> GetAllLivros()
        {
            throw new NotImplementedException();
        }

        public Livro GetLivroById(int livroId)
        {
            return _context.Set<Livro>().Find(livroId);
        }

        public Livro GetLivrosById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLivro(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}