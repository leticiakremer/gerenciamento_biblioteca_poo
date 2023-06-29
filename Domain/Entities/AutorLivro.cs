using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class AutorLivro : Entity
    {
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; }


    }
}