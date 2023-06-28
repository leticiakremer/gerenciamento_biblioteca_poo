using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public class IAutorLivroRepository
    {
        void AddAutor(Autor autor);
        void AddLivro(Livro Livro);
    }
}