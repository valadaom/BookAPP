using BookAPP.API.Filters;
using BookAPP.Domain.Exceptions;
using BookAPP.Domain.Interfaces;
using BookAPP.Domain.Interfaces.Infrastructure;
using BookAPP.Repository.Database;
using BookAPP.Repository.Factories;
using BookAPP.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeta os repositórios
builder.Services.AddScoped<IExceptionHandlerFactory, ExceptionHandlerFactory>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<ILivroFormaCompraRepository, LivroFormaCompraRepository>();
builder.Services.AddScoped<IFormaCompraRepository, FormaCompraRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
})
.ConfigureApiBehaviorOptions(options =>
 {
     options.InvalidModelStateResponseFactory = context =>
     {
         var errors = context.ModelState
             .Where(ms => ms.Value.Errors.Count > 0)
             .ToDictionary(
                 kvp => kvp.Key,
                 kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
             );

         throw new ValidationException(errors);
     };
 });

// CORS (opcional - se for consumir de outro domínio/front)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // opcional

app.UseAuthorization();

app.MapControllers(); // mapeia controllers automaticamente

app.Run();
