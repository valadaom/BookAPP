using BookAPP.Domain.Entities;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

public class AssuntoCreateDto
{
    public string Descricao { get; set; } = string.Empty;

    public Assunto ToEntity() => new Assunto { Descricao = Descricao };
}
