using BookAPP.Domain.DTOs.LivroDTO;
using BookAPP.Domain.Entities;
using BookAPP.Domain.Exceptions;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace BookAPP.Repository.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;
        private readonly IExceptionHandlerFactory _handler;

        public LivroRepository(AppDbContext context, IExceptionHandlerFactory handler)
        {
            _context = context;
            _handler = handler;
        }

        public Task<IEnumerable<LivroReadDto>> GetAllAsync()
        {
            return _handler.HandleAsync(async () =>
            {
                var livros = await _context.Livro
                .Include(l => l.Livro_Autores).ThenInclude(la => la.Autor)
                .Include(l => l.Livro_Assuntos).ThenInclude(la => la.Assunto)
                .Include(l => l.Livro_FormasCompra).ThenInclude(lf => lf.FormaCompra)
                .ToListAsync();

                return livros.Select(LivroReadDto.FromEntity);
            });
        }
        public Task<Livro> GetByIdAsync(int id)
        {
            return _handler.HandleAsync(async () =>
            {
                var response = await _context.Livro.FindAsync(id);
                if (response == null)
                    throw new NotFoundException($"Livro {id} não encontrado.");

                return response;
            });
        }
        public Task AddAsync(Livro livro)
        {
            return _handler.HandleAsync(async () =>
            {
                _context.Livro.Add(livro);
                await _context.SaveChangesAsync();
            });
        }
        public Task UpdateAsync(LivroUpdateDto livro)
        {
            return _handler.HandleAsync(async () =>
            {
                var livroExistente = await _context.Livro
                                           .Include(l => l.Livro_Autores)
                                           .Include(l => l.Livro_Assuntos)
                                           .FirstOrDefaultAsync(l => l.CodL == livro.CodL);

                if (livroExistente != null)
                {
                    livroExistente.Titulo = livro.Titulo;
                    livroExistente.Editora = livro.Editora;
                    livroExistente.Edicao = livro.Edicao;
                    livroExistente.AnoPublicacao = livro.AnoPublicacao;

                    livroExistente.Livro_Autores.Clear();
                    livroExistente.Livro_Autores = livro.AutoresIds.Select(autor => new Livro_Autor
                    {
                        Livro_CodL = livro.CodL,
                        Autor_CodAu = autor
                    }).ToList();

                    livroExistente.Livro_Assuntos.Clear();
                    livroExistente.Livro_Assuntos = livro.AssuntosIds.Select(assunto => new Livro_Assunto
                    {
                        Livro_CodL = livro.CodL,
                        Assunto_CodAs = assunto
                    }).ToList();

                    await _context.SaveChangesAsync();
                }
            });

        }
        public Task DeleteAsync(int id)
        {
            return _handler.HandleAsync(async () =>
            {
                var livro = await GetByIdAsync(id);

                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();
            });
        }
    }

}
