using BookAPP.Domain.DTOs.FormaCompraDTO;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class FormaCompraRepository : IFormaCompraRepository
{
    private readonly AppDbContext _context;
    private readonly IExceptionHandlerFactory _handler;

    public FormaCompraRepository(AppDbContext context, IExceptionHandlerFactory handler)
    {
        _context = context;
        _handler = handler;
    }

    public Task<IEnumerable<FormaCompraDto>> GetAllAsync()
    {
        return _handler.HandleAsync(async () =>
        {
            var response = await _context.FormaCompra
            .Select(fc => new FormaCompraDto
            {
                CodFC = fc.CodFC,
                Nome = fc.Nome
            })
            .ToListAsync();

            return response.AsEnumerable();
        });

    }
}
