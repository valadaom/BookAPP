namespace BookAPP.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("Erro(s) de validação nos dados de entrada.")
        {
            Errors = errors;
        }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message) { }
    }

    public class DomainException : Exception
    {
        public DomainException(string message, Exception? inner = null)
            : base(message, inner) { }
    }
}
