using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository
    {
        IList<Livro> GetAllLivros();
        Livro GetLivrosById(int id);

        void AddLivro(Livro livro);
        void UpdateLivro(Livro livro);
        void DeleteLivro(Livro livro);
    }
}