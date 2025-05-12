using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.AutorDTO;

[ModelMetadataType(typeof(Autor))]
public class AutorUpdateDto
{
    public int CodAu { get; set; }
    public string Nome { get; set; } = string.Empty;

    public void UpdateAutorEntity(Autor autor)
    {
        autor.Nome = Nome;
    }
}
