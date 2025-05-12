using BookAPP.Domain.DTOs.LivroPrecoDTO;

namespace BookAPP.Domain.Interfaces
{
    public interface ILivroFormaCompraRepository
    {
        Task UpdatePrecosAsync(LivroPrecoUpdateDto dto);
        Task<IEnumerable<LivroPrecoDto>> GetPrecosByLivroIdAsync(int livroId);
    }
}
