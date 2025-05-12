using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.LivroDTO;

[ModelMetadataType(typeof(Livro))]
public class LivroCreateDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Editora { get; set; } = string.Empty;
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; } = string.Empty;

    public List<int> AutoresIds { get; set; } = new();
    public List<int> AssuntosIds { get; set; } = new();

    public Livro ToLivroEntity()
    {
        return new Livro
        {
            Titulo = Titulo,
            Editora = Editora,
            Edicao = Edicao,
            AnoPublicacao = AnoPublicacao,
            Livro_Autores = AutoresIds.Select(id => new Livro_Autor { Autor_CodAu = id }).ToList(),
            Livro_Assuntos = AssuntosIds.Select(id => new Livro_Assunto { Assunto_CodAs = id }).ToList()
        };
    }
}
