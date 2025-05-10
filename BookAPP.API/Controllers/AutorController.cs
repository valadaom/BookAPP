using BookAPP.Domain.DTOs.AutorDTO;
using BookAPP.Domain.DTOs.AutorDtos;
using BookAPP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository _autorRepository;

    public AutorController(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _autorRepository.GetAllAsync();
        var result = autores.Select(AutorReadDto.FromEntity);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null) return NotFound();

        return Ok(AutorReadDto.FromEntity(autor));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AutorCreateDto dto)
    {
        var autor = dto.ToAutorEntity();
        await _autorRepository.AddAsync(autor);
        return CreatedAtAction(nameof(GetById), new { id = autor.CodAu }, AutorReadDto.FromEntity(autor));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AutorUpdateDto dto)
    {
        if (id != dto.CodAu) return BadRequest();

        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null) return NotFound();

        dto.UpdateAutorEntity(autor);
        await _autorRepository.UpdateAsync(autor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null) return NotFound();

        await _autorRepository.DeleteAsync(id);
        return NoContent();
    }
}
