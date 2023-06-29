using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IList<Usuario> GetAllUsuario();
        Usuario GetUsuarioById(int id);
        void AddUsuario(Usuario user);
        void UpdateUsuario(Usuario user);
        void DeleteUsuario(Usuario user);
    }
}