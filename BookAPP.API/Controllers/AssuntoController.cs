using BookAPP.Domain.DTOs.AssuntoDtos;
using BookAPP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssuntoController : ControllerBase
{
    private readonly IAssuntoRepository _assuntoRepository;

    public AssuntoController(IAssuntoRepository assuntoRepository)
    {
        _assuntoRepository = assuntoRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<AssuntoReadDto>> GetAll()
        => (await _assuntoRepository.GetAllAsync())
             .Select(AssuntoReadDto.FromEntity);

    [HttpGet("{id}")]
    public async Task<AssuntoReadDto> GetById(int id)
        => AssuntoReadDto.FromEntity(await _assuntoRepository.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssuntoCreateDto dto)
    {
        var assunto = dto.ToEntity();
        await _assuntoRepository.AddAsync(assunto);
        return CreatedAtAction(nameof(GetById), new { id = assunto.CodAs }, AssuntoReadDto.FromEntity(assunto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AssuntoUpdateDto dto)
    {
        if (id != dto.CodAs) return BadRequest();

        var entity = await _assuntoRepository.GetByIdAsync(id);
        dto.UpdateEntity(entity);
        await _assuntoRepository.UpdateAsync(entity);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _assuntoRepository.DeleteAsync(id);
        return Ok();
    }
}
