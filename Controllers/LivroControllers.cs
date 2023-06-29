using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.DTOs;
using GerenciamentoDeBiblioteca.Domain.ViewModels;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroControllers : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IAutorLivroRepository _autorLivroRepository;
        private readonly IMapper _mapper;

        public LivroControllers(ILivroRepository livroRepository, IAutorRepository autorRepository, IAutorLivroRepository autorLivroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _autorLivroRepository = autorLivroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllLivros()
        {
            var livros = _livroRepository.GetAllLivros();
            var livroDTO = _mapper.Map<List<LivroDTO>>(livros);

            return Ok(livroDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetLivroById(int id)
        {
            var livro = _livroRepository.GetLivroById(id);

            if (livro == null)
            {
                return NotFound();
            }

            var livroDTO = _mapper.Map<LivroDTO>(livro);

            return Ok(livroDTO);
        }

        [HttpPost]
        public IActionResult AddLivro(LivroViewModel livroViewModel)
        {
            var livro = _mapper.Map < Livro(livroViewModel);

            // Adiciona o autor ao livro
            foreach (var autorId in livroViewModel.AutoresId)
            {
                var autor = _autorRepository.GetAutorById(autorId);
                if (autor == null)
                {
                    autor = new Autor { Id = autorId };
                    _autorRepository.AddAutor(autor);

                    // Crie um objeto AutorLivro e atribua os valores apropriados
                    var autorLivro = new AutorLivro
                    {
                        LivroId = livro.Id,
                        AutorId = autor.Id
                    };

                    // Adicione o objeto AutorLivro repositório IAutorLivroRepository
                    _autorLivroRepository.AddAutor(autor);
                }
            }

            _livroRepository.AddLivro(livro);

            var livroDTO = _mapper.Map<LivroDTO>(livro);

            return CreatedAtAction(nameof(GetLivroById), new { id = livroDTO.Id }, livroDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivro(int id, LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var livro = _livroRepository.GetLivroById(id);

            if (livro == null)
            {
                return NotFound();
            }

            _mapper.Map(livroViewModel, livro);
            _livroRepository.UpdateLivro(livro);

            return Ok(new
            {
                StatusCode = 200,
                Message = "Livor atualizado com sucesso!"
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            var livro = _livroRepository.GetLivroById(id);

            if (livro == null)
            {
                return NotFound();
            }

            _livroRepository.DeleteLivro(livro);

            return Ok(new
            {
                StatusCode = 200,
                Message = "Livro deletado com sucesso!"
            });
        }
    }
}