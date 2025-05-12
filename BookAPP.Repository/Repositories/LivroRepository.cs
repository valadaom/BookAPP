using BookAPP.Domain.DTOs.LivroDTO;
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

        public async Task<IEnumerable<LivroReadDto>> GetAllAsync()
        {
            var livros = await _context.Livro
                .Include(l => l.Livro_Autores).ThenInclude(la => la.Autor)
                .Include(l => l.Livro_Assuntos).ThenInclude(la => la.Assunto)
                .Include(l => l.Livro_FormasCompra).ThenInclude(lf => lf.FormaCompra)
                .ToListAsync();

            return livros.Select(LivroReadDto.FromEntity);
        }
        public async Task<Livro?> GetByIdAsync(int id) => await _context.Livro.FindAsync(id);
        public async Task AddAsync(Livro livro)
        {
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(LivroUpdateDto livro)
        {
            var livroExistente = await _context.Livro
                                           .Include(l => l.Livro_Autores)
                                           .Include(l => l.Livro_Assuntos)
                                           .FirstOrDefaultAsync(l => l.CodL == livro.CodL);

            if (livroExistente != null)
            {
                // Atualiza as propriedades do livro
                livroExistente.Titulo = livro.Titulo;
                livroExistente.Editora = livro.Editora;
                livroExistente.Edicao = livro.Edicao;
                livroExistente.AnoPublicacao = livro.AnoPublicacao;

                // Atualiza a lista de autores (livro pode ter múltiplos autores)
                livroExistente.Livro_Autores.Clear(); // Remove os autores antigos
                livroExistente.Livro_Autores = livro.AutoresIds.Select(autor => new Livro_Autor
                {
                    Livro_CodL = livro.CodL,
                    Autor_CodAu = autor
                }).ToList();

                // Atualiza a lista de assuntos (livro pode ter múltiplos assuntos)
                livroExistente.Livro_Assuntos.Clear(); // Remove os assuntos antigos
                livroExistente.Livro_Assuntos = livro.AssuntosIds.Select(assunto => new Livro_Assunto
                {
                    Livro_CodL = livro.CodL,
                    Assunto_CodAs = assunto
                }).ToList();

                // Salva as alterações no banco
                await _context.SaveChangesAsync();
            }
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
