using BookAPP.Domain.DTOs.FormaCompraDTO;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class FormaCompraRepository : IFormaCompraRepository
{
    private readonly AppDbContext _context;

    public FormaCompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FormaCompraDto>> GetAllAsync()
    {
        return await _context.FormaCompra
            .Select(fc => new FormaCompraDto
            {
                CodFC = fc.CodFC,
                Nome = fc.Nome
            })
            .ToListAsync();
    }
}
