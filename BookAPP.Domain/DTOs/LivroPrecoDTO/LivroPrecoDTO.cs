namespace BookAPP.Domain.DTOs.LivroPrecoDTO
{
    public class LivroPrecoDto
    {
        public int CodFC { get; set; }
        public string FormaCompra { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
