using BookAPP.Domain.Entities;

namespace BookAPP.Domain.Interfaces;

public interface IAssuntoRepository
{
    Task<IEnumerable<Assunto>> GetAllAsync();
    Task<Assunto> GetByIdAsync(int id);
    Task AddAsync(Assunto assunto);
    Task UpdateAsync(Assunto assunto);
    Task DeleteAsync(int id);
}
