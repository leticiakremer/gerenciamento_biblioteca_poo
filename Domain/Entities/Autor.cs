using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Autor
    {
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }


    }
}