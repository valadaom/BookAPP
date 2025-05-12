using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

public class AssuntoReadDto
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public static AssuntoReadDto FromEntity(Assunto assunto)
    {
        return new AssuntoReadDto
        {
            CodAs = assunto.CodAs,
            Descricao = assunto.Descricao
        };
    }
}
