using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; set; }

        public IList<AutorLivro> Autores { get; set; }

    }
}