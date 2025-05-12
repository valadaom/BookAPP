using BookAPP.Domain.DTOs.LivroDTO;
using BookAPP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroRepository.GetAllAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LivroCreateDto dto)
        {
            var livroEntity = dto.ToLivroEntity();

            await _livroRepository.AddAsync(livroEntity);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LivroUpdateDto dto)
        {
            if (id != dto.CodL) return BadRequest();
            await _livroRepository.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null) return NotFound();

            await _livroRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
