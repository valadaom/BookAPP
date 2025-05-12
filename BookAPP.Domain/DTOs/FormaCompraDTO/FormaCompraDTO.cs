using BookAPP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Domain.DTOs.FormaCompraDTO;

[ModelMetadataType(typeof(FormaCompra))]
public class FormaCompraDto
{
    public int CodFC { get; set; }
    public string Nome { get; set; } = string.Empty;
}
