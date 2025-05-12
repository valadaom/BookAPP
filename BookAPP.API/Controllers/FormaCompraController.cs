using BookAPP.Domain.DTOs.FormaCompraDTO;
using BookAPP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormaCompraController : ControllerBase
{
    private readonly IFormaCompraRepository _repository;

    public FormaCompraController(IFormaCompraRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormaCompraDto>>> GetAll()
    {
        var result = await _repository.GetAllAsync();
        return Ok(result);
    }
}
