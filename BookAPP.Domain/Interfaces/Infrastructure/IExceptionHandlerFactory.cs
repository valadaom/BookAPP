namespace BookAPP.Domain.Interfaces.Infrastructure
{
    public interface IExceptionHandlerFactory
    {
        Task<T> HandleAsync<T>(Func<Task<T>> action);
        Task HandleAsync(Func<Task> action);
    }
}
