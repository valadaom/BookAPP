using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.AutorDTO
{
    public class AutorUpdateDto
    {
        public int CodAu { get; set; }
        public string Nome { get; set; } = string.Empty;

        public void UpdateAutorEntity(Autor autor)
        {
            autor.Nome = Nome;
        }
    }
}
