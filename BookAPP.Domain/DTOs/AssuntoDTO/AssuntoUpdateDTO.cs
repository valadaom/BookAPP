using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

[ModelMetadataType(typeof(Assunto))]
public class AssuntoUpdateDto
{
    public int CodAs { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public void UpdateEntity(Assunto assunto)
    {
        assunto.Descricao = Descricao;
    }
}
