using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

[ModelMetadataType(typeof(Assunto))]
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
