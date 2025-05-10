using System.ComponentModel.DataAnnotations;

namespace BookAPP.Domain.Entities
{
    public class Assunto
    {
        [Key]
        public int CodAs { get; set; }

        [MaxLength(20)]
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Livro_Assunto> Livro_Assuntos { get; set; } = new List<Livro_Assunto>();
    }
}
