using BookAPP.Domain.DTOs.LivroPrecoDTO;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroFormaCompraController : ControllerBase
{
    private readonly ILivroFormaCompraRepository _repository;

    public LivroFormaCompraController(ILivroFormaCompraRepository repository)
    {
        _repository = repository;
    }

    [HttpPut("atualizar-precos")]
    public async Task<IActionResult> AtualizarPrecos([FromBody] LivroPrecoUpdateDto dto)
    {
        await _repository.UpdatePrecosAsync(dto);
        return NoContent();
    }

    [HttpGet("{livroId}")]
    public async Task<ActionResult<IEnumerable<LivroPrecoDto>>> GetByLivroId(int livroId)
    {
        var precos = await _repository.GetPrecosByLivroIdAsync(livroId);
        return Ok(precos);
    }

}
