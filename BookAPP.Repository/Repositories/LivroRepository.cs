using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetAllAsync() => await _context.Livro.ToListAsync();
        public async Task<Livro?> GetByIdAsync(int id) => await _context.Livro.FindAsync(id);
        public async Task AddAsync(Livro livro)
        {
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Livro livro)
        {
            _context.Livro.Update(livro);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }

}
