using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.DTOs;
using GerenciamentoDeBiblioteca.Domain.ViewModels;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioControllers : ControllerBase
    {


        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioControllers(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var usuario = _usuarioRepository.GetAllUsuario();
            var usuarioDTOs = _mapper.Map<List<UsuarioDTO>>(usuario);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            _usuarioRepository.AddUsuario(usuario);

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return CreatedAtAction(nameof(GetUserById), new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _mapper.Map(usuarioViewModel, usuario);
            _usuarioRepository.UpdateUsuario(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.DeleteUsuario(usuario);

            return NoContent();
        }
    }
}