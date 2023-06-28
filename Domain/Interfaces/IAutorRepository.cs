using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public class IAutorRepository
    {
        IList<Autor> GetAllAuthors();
        Autor GetAuthorById(int id);
        void AddAutor(Autor autor);
        void UpdateAutor(Autor autor);
        void DeleteAutor(Autor autor);
    }
}