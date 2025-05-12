using BookAPP.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;

[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioRepository _repo;
    private readonly IWebHostEnvironment _env;

    public RelatoriosController(IRelatorioRepository repo, IWebHostEnvironment env)
    {
        _repo = repo;
        _env = env;
    }

    [HttpGet("livros-por-autor")]
    public async Task<IActionResult> GerarPdfLivrosPorAutor()
    {
        var dados = await _repo.GetLivrosPorAutorAsync();

        var report = new LocalReport();

        using var fs = System.IO.File.OpenRead(
            Path.Combine(_env.ContentRootPath, "Reports", "RelatorioLivrosPorAutor.rdlc")
        );
        report.LoadReportDefinition(fs);

        report.DataSources.Add(new ReportDataSource("DataSetRelatorio", dados));

        var pdfBytes = report.Render("PDF");
        return File(pdfBytes, "application/pdf", "RelatorioLivrosPorAutor.pdf");
    }
}
