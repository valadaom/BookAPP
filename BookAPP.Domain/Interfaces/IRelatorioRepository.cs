using BookAPP.Domain.Entities;

namespace BookAPP.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<VwRelatorioLivrosPorAutor>> GetLivrosPorAutorAsync();
    }
}
