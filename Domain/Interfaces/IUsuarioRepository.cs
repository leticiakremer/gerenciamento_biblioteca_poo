using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Domain.Entities;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public class IUsuarioRepository
    {
        IList<Usuario> GetAllUsers();
        Usuario GetUserById(int id);
        void AddUsuario(Usuario user);
        void UpdateUsuario(Usuario user);
        void DeleteUsuario(Usuario user);
    }
}