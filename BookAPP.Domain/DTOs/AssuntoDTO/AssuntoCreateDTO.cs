using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AssuntoDtos;

[ModelMetadataType(typeof(Assunto))]
public class AssuntoCreateDto
{
    public string Descricao { get; set; } = string.Empty;

    public Assunto ToEntity() => new Assunto { Descricao = Descricao };
}
