namespace BookAPP.Domain.Entities
{
    public class Livro_FormaCompra
    {
        public int Livro_CodL { get; set; }
        public Livro Livro { get; set; } = null!;

        public int FormaCompra_CodFC { get; set; }
        public FormaCompra FormaCompra { get; set; } = null!;

        public decimal Preco { get; set; }
    }

}
