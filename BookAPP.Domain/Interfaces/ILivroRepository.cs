using BookAPP.Domain.DTOs.LivroDTO;
using BookAPP.Domain.Entities;

namespace BookAPP.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroReadDto>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task AddAsync(Livro livro);
        Task UpdateAsync(LivroUpdateDto livro);
        Task DeleteAsync(int id);
    }

}
