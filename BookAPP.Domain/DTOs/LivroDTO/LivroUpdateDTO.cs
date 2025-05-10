using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.LivroDTO
{
    public class LivroUpdateDto
    {
        public int CodL { get; set; } // obrigatório para garantir a referência
        public string Titulo { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; } = string.Empty;

        public List<int> AutoresIds { get; set; } = new();
        public List<int> AssuntosIds { get; set; } = new();

        public void UpdateLivroEntity(Livro livro)
        {
            livro.Titulo = Titulo;
            livro.Editora = Editora;
            livro.Edicao = Edicao;
            livro.AnoPublicacao = AnoPublicacao;

            livro.Livro_Autores = AutoresIds.Select(id => new Livro_Autor { Livro_CodL = CodL, Autor_CodAu = id }).ToList();
            livro.Livro_Assuntos = AssuntosIds.Select(id => new Livro_Assunto { Livro_CodL = CodL, Assunto_CodAs = id }).ToList();
        }
    }

}
