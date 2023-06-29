using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.ViewModels
{
    public class LivroViewModel
    {
        public string Titulo { get; set; }
        public IList<int> AutoresId { get; set; }
    }
}