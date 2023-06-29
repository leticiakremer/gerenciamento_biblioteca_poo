using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.DTOs;
using GerenciamentoDeBiblioteca.Domain.ViewModels;
using AutoMapper;


namespace GerenciamentoDeBiblioteca.Controllers
{
    [ApiController]
    [Route("api/autor")]
    public class AutorControllers : ControllerBase

    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorLivroRepository _autorLivroRepository;
        private readonly IMapper _mapper;

        public AutorControllers(IAutorRepository autorRepository, ILivroRepository livroRepository, IAutorLivroRepository autorLivroRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _livroRepository = livroRepository;
            _autorLivroRepository = autorLivroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAutores()
        {
            var autores = _autorRepository.GetAllAutor();
            var autorDTO = _mapper.Map<List<AutorDTO>>(autores);

            return Ok(autorDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetAutorById(int id)
        {
            var autor = _autorRepository.GetAutorById(id);

            if (autor == null)
            {
                return NotFound();
            }

            var autorDTO = _mapper.Map<AutorDTO>(autor);

            return Ok(autorDTO);
        }

        [HttpPost]
        public IActionResult CreateAutor(AutorViewModel autorViewModel)
        {
            var autor = _mapper.Map<Autor>(autorViewModel);
            _autorRepository.AddAutor(autor);

            var autorDTO = _mapper.Map<AutorDTO>(autor);

            return CreatedAtAction(nameof(GetAutorById), new { id = autorDTO.Id }, autorDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAutor(int id, AutorViewModel autorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var autor = _autorRepository.GetAutorById(id);

            if (autor == null)
            {
                return NotFound();
            }

            _mapper.Map(autorViewModel, autor);
            _autorRepository.UpdateAutor(autor);

            return Ok(new
            {
                StatusCode = 200,
                Message = "Autor atualizado com sucesso!"
            });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAutor(int id)
        {
            var autor = _autorRepository.GetAutorById(id);

            if (autor == null)
            {
                return NotFound();
            }

            _autorRepository.DeleteAutor(autor);

            return Ok(new
            {
                StatusCode = 200,
                Message = "Autor deletado com sucesso!"
            });
        }
    }
}