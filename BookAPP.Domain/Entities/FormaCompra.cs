using System.ComponentModel.DataAnnotations;

namespace BookAPP.Domain.Entities
{
    public class FormaCompra
    {
        [Key]
        public int CodFC { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Livro_FormaCompra> Livro_FormasCompra { get; set; } = new List<Livro_FormaCompra>();
    }

}
