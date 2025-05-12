namespace BookAPP.Domain.Entities
{
    public class VwRelatorioLivrosPorAutor
    {
        public int AutorId { get; set; }
        public string AutorNome { get; set; } = "";
        public int LivroId { get; set; }
        public string Titulo { get; set; } = "";
        public string Editora { get; set; } = "";
        public string AnoPublicacao { get; set; } = "";
        public int Edicao { get; set; }
        public int? AssuntoId { get; set; }
        public string? AssuntoDescricao { get; set; }
    }
}
