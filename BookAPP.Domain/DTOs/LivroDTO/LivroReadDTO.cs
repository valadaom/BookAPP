using BookAPP.Domain.DTOs.AssuntoDtos;
using BookAPP.Domain.DTOs.AutorDtos;
using BookAPP.Domain.DTOs.LivroPrecoDTO;
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
        public List<LivroPrecoDto> Precos { get; set; } = new();

        public List<AutorReadDto> Autores { get; set; } = new();
        public List<AssuntoReadDto> Assuntos { get; set; } = new();

        public static LivroReadDto FromEntity(Livro livro)
        {
            return new LivroReadDto
            {
                CodL = livro.CodL,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Precos = livro.Livro_FormasCompra.Select(p => new LivroPrecoDto
                {
                    CodFC = p.FormaCompra_CodFC,
                    FormaCompra = p.FormaCompra.Nome,
                    Preco = p.Preco
                }).ToList(),
                Autores = livro.Livro_Autores
                    .Where(la => la.Autor != null)
                    .Select(la => new AutorReadDto
                    {
                        CodAu = la.Autor.CodAu,
                        Nome = la.Autor.Nome
                    }).ToList(),
                Assuntos = livro.Livro_Assuntos
                    .Where(la => la.Assunto != null)
                    .Select(la => new AssuntoReadDto
                    {
                        CodAs = la.Assunto.CodAs,
                        Descricao = la.Assunto.Descricao
                    }).ToList()
            };
        }
    }
}
