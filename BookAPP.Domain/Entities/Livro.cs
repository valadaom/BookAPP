using System.ComponentModel.DataAnnotations;

namespace BookAPP.Domain.Entities
{
    public class Livro
    {
        [Key]
        public int CodL { get; set; }

        [MaxLength(40)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(40)]
        public string Editora { get; set; } = string.Empty;

        public int Edicao { get; set; }

        [MaxLength(4)]
        public string AnoPublicacao { get; set; } = string.Empty;

        public ICollection<Livro_Autor> Livro_Autores { get; set; } = new List<Livro_Autor>();
        public ICollection<Livro_Assunto> Livro_Assuntos { get; set; } = new List<Livro_Assunto>();
        public ICollection<Livro_FormaCompra> Livro_FormasCompra { get; set; } = new List<Livro_FormaCompra>();

    }
}
