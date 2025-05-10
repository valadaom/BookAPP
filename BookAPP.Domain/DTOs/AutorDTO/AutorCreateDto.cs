using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.AutorDTO
{
    public class AutorCreateDto
    {
        public string Nome { get; set; } = string.Empty;

        public Autor ToAutorEntity()
        {
            return new Autor
            {
                Nome = Nome
            };
        }
    }
}
