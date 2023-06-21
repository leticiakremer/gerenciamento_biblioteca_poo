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
        private readonly DbContext context;

        public UsuarioRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public void AddUsuario(Usuario usuario)
        {
            context.Set<Usuario>().Add(usuario);
            context.SaveChanges();
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            return context.Set<Usuario>().Find(usuarioId);
        }
    }
}