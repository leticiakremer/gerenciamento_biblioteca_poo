using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; set; }
        public IList<Autor> Livros { get; set; }


    }
}