using BookAPP.Domain.DTOs.AssuntoDTO;
using BookAPP.Domain.DTOs.AutorDTO;
using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.LivroDTO
{
    public class LivroReadDto
    {
        public int CodL { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; } = string.Empty;

        public List<AutorDto> Autores { get; set; } = new();
        public List<AssuntoDto> Assuntos { get; set; } = new();

        public static LivroReadDto FromEntity(Livro livro)
        {
            return new LivroReadDto
            {
                CodL = livro.CodL,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Autores = livro.Livro_Autores
                    .Where(la => la.Autor != null)
                    .Select(la => new AutorDto
                    {
                        CodAu = la.Autor.CodAu,
                        Nome = la.Autor.Nome
                    }).ToList(),
                Assuntos = livro.Livro_Assuntos
                    .Where(la => la.Assunto != null)
                    .Select(la => new AssuntoDto
                    {
                        CodAs = la.Assunto.CodAs,
                        Descricao = la.Assunto.Descricao
                    }).ToList()
            };
        }
    }
}
