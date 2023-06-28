using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Data.Context;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class AutorLivroRepository : IAutorLivroRepository
    {
        private readonly DataContext _context;

        public AutorLivroRepository(DataContext context)
        {
            _context = context;
        }

        public void AddAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void AddLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }
    }
}