
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeBiblioteca.Data.Context;



namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

        public AutorRepository(DataContext context)
        {
            _context = context;
        }



        public Autor GetAutorById(int id)
        {
            return _context.Set<Autor>().Find(id);
        }

        public void AddAutor(Autor autor)
        {
            _context.Set<Autor>().Add(autor);
            _context.SaveChanges();
        }

        public void UpdateAutor(Autor autor)
        {
            _context.Set<Autor>().Update(autor);
            _context.SaveChanges();
        }

        public void DeleteAutor(Autor autor)
        {
            _context.Set<Autor>().Remove(autor);
            _context.SaveChanges();
        }

        public IList<Autor> GetAllAutor()
        {
            throw new NotImplementedException();
        }
    }
}