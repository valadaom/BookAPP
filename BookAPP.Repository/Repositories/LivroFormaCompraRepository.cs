using BookAPP.Domain.DTOs.LivroPrecoDTO;
using BookAPP.Domain.Entities;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories
{
    public class LivroFormaCompraRepository : ILivroFormaCompraRepository
    {
        private readonly AppDbContext _context;
        private readonly IExceptionHandlerFactory _handler;

        public LivroFormaCompraRepository(AppDbContext context, IExceptionHandlerFactory handler)
        {
            _context = context;
            _handler = handler;
        }
        public Task UpdatePrecosAsync(LivroPrecoUpdateDto dto)
        {
            return _handler.HandleAsync(async () =>
            {
                var formasCompraIds = dto.Precos.Select(p => p.FormaCompraCodFC).ToList();

                var formasCompra = await _context.FormaCompra
                    .Where(fc => formasCompraIds.Contains(fc.CodFC))
                    .ToListAsync();

                var existentes = await _context.Livro_FormaCompra
                    .Where(x => x.Livro_CodL == dto.LivroCodL && formasCompraIds.Contains(x.FormaCompra_CodFC))
                    .ToListAsync();

                foreach (var precoDto in dto.Precos)
                {
                    var existente = existentes
                        .FirstOrDefault(x => x.FormaCompra_CodFC == precoDto.FormaCompraCodFC);

                    if (existente != null)
                    {
                        existente.Preco = precoDto.Preco;
                    }
                    else
                    {
                        var forma = formasCompra.First(fc => fc.CodFC == precoDto.FormaCompraCodFC);

                        _context.Livro_FormaCompra.Add(new Livro_FormaCompra
                        {
                            Livro_CodL = dto.LivroCodL,
                            FormaCompra_CodFC = forma.CodFC,
                            FormaCompra = forma,
                            Preco = precoDto.Preco
                        });
                    }
                }

                await _context.SaveChangesAsync();
            });
        }

        public Task<IEnumerable<LivroPrecoDto>> GetPrecosByLivroIdAsync(int livroId)
        {
            return _handler.HandleAsync(async () =>
            {
                var response = await _context.Livro_FormaCompra
                .Where(lf => lf.Livro_CodL == livroId)
                .Include(lf => lf.FormaCompra)
                .Select(lf => new LivroPrecoDto
                {
                    CodFC = lf.FormaCompra_CodFC,
                    FormaCompra = lf.FormaCompra.Nome,
                    Preco = lf.Preco
                })
                .ToListAsync();

                return response.AsEnumerable();
            });
        }

    }
}
