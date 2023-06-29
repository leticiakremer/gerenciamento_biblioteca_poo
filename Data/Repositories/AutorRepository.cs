
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DbContext _context;

        public AutorRepository(DbContext context)
        {
            _context = context;
        }

        public IList<Autor> GetAllAutores()
        {
            return _context.Autores.ToList();
        }

        public Autor GetAutorById(int id)
        {
            return _context.Autores.Find(id);
        }

        public void AddAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void UpdateAutor(Autor autor)
        {
            _context.Autores.Update(autor);
            _context.SaveChanges();
        }

        public void DeleteAutor(Autor autor)
        {
            _context.Autores.Remove(autor);
            _context.SaveChanges();
        }

        public IList<Autor> GetAllAutor()
        {
            throw new NotImplementedException();
        }
    }
}