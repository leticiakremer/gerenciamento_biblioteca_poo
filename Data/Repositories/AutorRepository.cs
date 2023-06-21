using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Repositories
{
    public class AutorRepository
    {
        private readonly DbContext context;

        public AutorRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public void AddAutor(Autor autor)
        {
            context.Set<Autor>().Add(autor);
            context.SaveChanges();
        }

        public Autor GetAutorById(int autorId)
        {
            return context.Set<Autor>().Find(autorId);
        }
    }
}