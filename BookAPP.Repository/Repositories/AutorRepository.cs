using BookAPP.Domain.Entities;
using BookAPP.Domain.Exceptions;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;
    private readonly IExceptionHandlerFactory _handler;

    public AutorRepository(AppDbContext context, IExceptionHandlerFactory handler)
    {
        _context = context;
        _handler = handler;
    }

    public Task<IEnumerable<Autor>> GetAllAsync()
    {
        return _handler.HandleAsync(async () =>
        {
            var response = await _context.Autor.ToListAsync();
            return response.AsEnumerable();
        });
    }


    public Task<Autor> GetByIdAsync(int id)
    {
        return _handler.HandleAsync(async () =>
        {
            var response = await _context.Autor.FindAsync(id);
            if (response == null)
                throw new NotFoundException($"Autor {id} não encontrado.");

            return response;
        });
    }


    public Task AddAsync(Autor autor)
    {
        return _handler.HandleAsync(async () =>
        {
            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
        });
    }

    public Task UpdateAsync(Autor autor)
    {
        return _handler.HandleAsync(async () =>
        {
            _context.Autor.Update(autor);
            await _context.SaveChangesAsync();
        });

    }

    public Task DeleteAsync(int id)
    {
        return _handler.HandleAsync(async () =>
        {
            var autor = await GetByIdAsync(id);
            
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
        });
    }
}
