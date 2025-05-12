using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync() =>
        await _context.Autor.ToListAsync();

    public async Task<Autor?> GetByIdAsync(int id) =>
        await _context.Autor.FindAsync(id);

    public async Task AddAsync(Autor autor)
    {
        _context.Autor.Add(autor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Autor autor)
    {
        _context.Autor.Update(autor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _context.Autor.FindAsync(id);
        if (autor != null)
        {
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }
}
