using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.LivroDTO
{
    public class LivroUpdateDto
    {
        public int CodL { get; set; }
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

            foreach (var id in AutoresIds.Distinct())
            {
                livro.Livro_Autores.Add(new Livro_Autor
                {
                    Livro_CodL = livro.CodL,
                    Autor_CodAu = id
                });
            }

            foreach (var id in AssuntosIds.Distinct())
            {
                livro.Livro_Assuntos.Add(new Livro_Assunto
                {
                    Livro_CodL = livro.CodL,
                    Assunto_CodAs = id
                });
            }
        }
    }

}
