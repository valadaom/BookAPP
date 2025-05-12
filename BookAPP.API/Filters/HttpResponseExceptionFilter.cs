using BookAPP.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.API.Filters
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException ve:
                    context.Result = new BadRequestObjectResult(new
                    {
                        error = ve.Message,
                        details = ve.Errors
                    });
                    break;
                case NotFoundException nf:
                    context.Result = new NotFoundObjectResult(new { error = nf.Message });
                    break;
                case ConflictException cf:
                    context.Result = new ConflictObjectResult(new { error = cf.Message });
                    break;
                case DomainException de:
                    context.Result = new ObjectResult(new { error = de.Message }) { StatusCode = 500 };
                    break;
                default:
                    context.Result = new ObjectResult(new { error = "Erro inesperado." }) { StatusCode = 500 };
                    break;
            }
            context.ExceptionHandled = true;
        }
    }
}
