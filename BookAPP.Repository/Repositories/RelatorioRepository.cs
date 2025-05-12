using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IExceptionHandlerFactory _handler;
        public RelatorioRepository(AppDbContext ctx, IExceptionHandlerFactory handker)
        {
            _ctx = ctx;
            _handler = handker;
        }
        public Task<List<VwRelatorioLivrosPorAutor>> GetLivrosPorAutorAsync()
        {
            return _handler.HandleAsync(async () =>
            {
                return await _ctx.VwRelatorioLivrosPorAutor.ToListAsync();
            });
        }

    }
}
