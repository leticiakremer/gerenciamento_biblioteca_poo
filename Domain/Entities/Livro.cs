using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Autor> Autores { get; set; }
        public List<Usuario> UsuariosEmprestimos { get; set; }
        public object UsuariosEmprestimo { get; internal set; }
    }
}