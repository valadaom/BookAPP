using BookAPP.Domain.DTOs.FormaCompraDTO;

namespace BookAPP.Domain.Interfaces
{
    public interface IFormaCompraRepository
    {
        Task<IEnumerable<FormaCompraDto>> GetAllAsync();
    }
}
