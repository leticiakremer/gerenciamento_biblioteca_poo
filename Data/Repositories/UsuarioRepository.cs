
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeBiblioteca.Data.Context;
namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void AddUsuario(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);
            _context.SaveChanges();
        }

        public void DeleteUsuario(Usuario user)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> GetAllUsuario()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            return _context.Set<Usuario>().Find(usuarioId);
        }

        public void UpdateUsuario(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}