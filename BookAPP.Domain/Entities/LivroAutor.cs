namespace BookAPP.Domain.Entities
{
    public class Livro_Autor
    {
        public int Livro_CodL { get; set; }
        public Livro Livro { get; set; } = null!;

        public int Autor_CodAu { get; set; }
        public Autor Autor { get; set; } = null!;
    }
}
