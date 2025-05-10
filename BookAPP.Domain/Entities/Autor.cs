using System.ComponentModel.DataAnnotations;

namespace BookAPP.Domain.Entities
{
    public class Autor
    {
        [Key]
        public int CodAu { get; set; }

        [MaxLength(40)]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Livro_Autor> Livro_Autores { get; set; } = new List<Livro_Autor>();
    }
}
