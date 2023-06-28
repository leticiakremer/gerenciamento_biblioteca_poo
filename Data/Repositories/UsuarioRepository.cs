using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly DbContext _context;

        public UsuarioRepository(DbContext context)
        {
            _context = context;
        }

        public void AddUsuario(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            return _context.Set<Usuario>().Find(usuarioId);
        }
    }
}