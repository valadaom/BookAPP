using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AutorDtos;

[ModelMetadataType(typeof(Autor))]
public class AutorReadDto
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;

    public static AutorReadDto FromEntity(Autor autor)
    {
        return new AutorReadDto
        {
            CodAu = autor.CodAu,
            Nome = autor.Nome
        };
    }
}
