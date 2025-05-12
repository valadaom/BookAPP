using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

public class AssuntoUpdateDto
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public void UpdateEntity(Assunto assunto)
    {
        assunto.Descricao = Descricao;
    }
}
