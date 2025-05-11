namespace BookAPP.Domain.DTOs.LivroPrecoDTO
{
    public class LivroPrecoUpdateDto
    {
        public int LivroCodL { get; set; }
        public List<PrecoUnitarioDto> Precos { get; set; } = new();
    }
}
