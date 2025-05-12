using BookAPP.Domain.Entities;

namespace BookAPP.Domain.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAllAsync();
        Task<Autor?> GetByIdAsync(int id);
        Task AddAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task DeleteAsync(int id);
    }
}
