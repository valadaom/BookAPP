using BookAPP.Domain.Exceptions;
using BookAPP.Domain.Interfaces.Infrastructure;
using System.Data.Common;

namespace BookAPP.Repository.Factories
{
    public class ExceptionHandlerFactory : IExceptionHandlerFactory
    {
        public async Task<T> HandleAsync<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"[DB ERROR] {dbEx.GetType().Name}: {dbEx.Message}");
                throw new ConflictException("Erro ao acessar o banco de dados.");
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UNHANDLED] {ex.GetType().Name}: {ex.Message}");
                throw new DomainException("Erro interno de serviço.", ex);
            }
        }

        public async Task HandleAsync(Func<Task> action)
        {
            await HandleAsync(async () => { await action(); return true; });
        }
    }
}
