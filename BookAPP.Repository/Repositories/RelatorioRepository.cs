using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _ctx;
        public RelatorioRepository(AppDbContext ctx) => _ctx = ctx;
        public Task<List<VwRelatorioLivrosPorAutor>> GetLivrosPorAutorAsync() =>
          _ctx.VwRelatorioLivrosPorAutor.ToListAsync();
    }
}
