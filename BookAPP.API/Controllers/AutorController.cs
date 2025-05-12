using BookAPP.Domain.DTOs.AssuntoDtos;
using BookAPP.Domain.DTOs.AutorDTO;
using BookAPP.Domain.DTOs.AutorDtos;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Repositories;
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
    public async Task<IEnumerable<AutorReadDto>> GetAll()
    => (await _autorRepository.GetAllAsync())
             .Select(AutorReadDto.FromEntity);

    [HttpGet("{id}")]
    public async Task<AutorReadDto> GetById(int id)
     => AutorReadDto.FromEntity(await _autorRepository.GetByIdAsync(id));

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
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _autorRepository.DeleteAsync(id);
        return Ok();
    }
}
