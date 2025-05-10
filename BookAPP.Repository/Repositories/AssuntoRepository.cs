using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class AssuntoRepository : IAssuntoRepository
{
    private readonly AppDbContext _context;

    public AssuntoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Assunto>> GetAllAsync() =>
        await _context.Assunto.ToListAsync();

    public async Task<Assunto?> GetByIdAsync(int id) =>
        await _context.Assunto.FindAsync(id);

    public async Task AddAsync(Assunto assunto)
    {
        _context.Assunto.Add(assunto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Assunto assunto)
    {
        _context.Assunto.Update(assunto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var assunto = await _context.Assunto.FindAsync(id);
        if (assunto != null)
        {
            _context.Assunto.Remove(assunto);
            await _context.SaveChangesAsync();
        }
    }
}
