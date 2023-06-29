using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeBiblioteca.Data.Context;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public void AddLivro(Livro livro)
        {
            _context.Set<Livro>().Add(livro);
            _context.SaveChanges();
        }

        public void DeleteLivro(Livro livro)
        {
            _context.Set<Livro>().Remove(livro);
            _context.SaveChanges();
        }

        public IList<Livro> GetAllLivros()
        {
            return _context.Set<Livro>().ToList();
        }

        public Livro GetLivrosById(int id)
        {
            return _context.Set<Livro>().Find(id);
        }

        public void UpdateLivro(Livro livro)
        {
            _context.Set<Livro>().Update(livro);
            _context.SaveChanges(); ;
        }
    }
}