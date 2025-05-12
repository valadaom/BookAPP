using BookAPP.Domain.Entities;
using BookAPP.Domain.Exceptions;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories;

public class AssuntoRepository : IAssuntoRepository
{
    private readonly AppDbContext _context;
    private readonly IExceptionHandlerFactory _handler;

    public AssuntoRepository(AppDbContext context, IExceptionHandlerFactory handler)
    {
        _context = context;
        _handler = handler;
    }

    public Task<IEnumerable<Assunto>> GetAllAsync()
    {
        return _handler.HandleAsync(async () =>
        {
            var lista = await _context.Assunto.ToListAsync();
            return lista.AsEnumerable();
        });
    }

    public Task<Assunto> GetByIdAsync(int id)
    {
        return _handler.HandleAsync(async () =>
        {
            var response = await _context.Assunto.FindAsync(id);
            if (response == null)
                throw new NotFoundException($"Assunto {id} não encontrado.");

            return response;
        });
    }


    public Task AddAsync(Assunto assunto)
    {
        return _handler.HandleAsync(async () =>
        {
            _context.Assunto.Add(assunto);
            await _context.SaveChangesAsync();
        });
    }

    public Task UpdateAsync(Assunto assunto)
    {
        return _handler.HandleAsync(async () =>
        {
            _context.Assunto.Update(assunto);
            await _context.SaveChangesAsync();
        });
    }

    public Task DeleteAsync(int id)
    {
        return _handler.HandleAsync(async () =>
        {
            var assunto = await GetByIdAsync(id);

            _context.Assunto.Remove(assunto);
            await _context.SaveChangesAsync();
        });
    }
}
