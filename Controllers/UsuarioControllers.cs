using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class UsuarioControllers
    {
        [ApiController]
        [Route("api/users")]
        public class UserController : ControllerBase
        {
            private readonly IUsuarioRepository _usuarioRepository;
            private readonly IMapper _mapper;

            public UserController(IUsuarioRepository usuarioRepository, IMapper mapper)
            {
                _usuariorRepository = usuarioRepository;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult GetAllUsers()
            {
                var usuarios = _usuariorRepository.GetAllUsers();
                var usuarioDTOs = _mapper.Map<List<UsuarioDTO>>(usuarios);

                return Ok();
            }

            [HttpGet("{id}")]
            public IActionResult GetUserById(int id)
            {
                var usuario = _usuariorRepository.GetUserById(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

                return Ok();
            }

            [HttpPost]
            public IActionResult CreateUser(UsuariorViewModel usuarioViewModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var usuario = _mapper.Map<User>(usuarioViewModel);
                _usuariorRepository.AddUsuario(usuario);

                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

                return CreatedAtAction(nameof(GetUserById), new { id = usuarioDTO.Id }, usuarioDTO);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateUser(int id, UserViewModel userViewModel)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var usuario = _usuariorRepository.GetUserById(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                _mapper.Map(userViewModel, usuario);
                _usuariorRepository.UpdateUser(usuario);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteUsuario(int id)
            {
                var usuario = _usuariorRepository.GetUserById(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                _usuariorRepository.DeleteUsuario(usuario);

                return NoContent();
            }
        }
    }
}