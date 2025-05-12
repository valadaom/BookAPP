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
    public async Task<IActionResult> GetAll()
    {
        var assuntos = await _assuntoRepository.GetAllAsync();
        var result = assuntos.Select(AssuntoReadDto.FromEntity);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var assunto = await _assuntoRepository.GetByIdAsync(id);
        if (assunto == null) return NotFound();

        return Ok(AssuntoReadDto.FromEntity(assunto));
    }

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

        var assunto = await _assuntoRepository.GetByIdAsync(id);
        if (assunto == null) return NotFound();

        dto.UpdateEntity(assunto);
        await _assuntoRepository.UpdateAsync(assunto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var assunto = await _assuntoRepository.GetByIdAsync(id);
        if (assunto == null) return NotFound();

        await _assuntoRepository.DeleteAsync(id);
        return Ok();
    }
}
