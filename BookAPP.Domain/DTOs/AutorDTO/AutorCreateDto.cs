using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AutorDTO;

[ModelMetadataType(typeof(Autor))]
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
