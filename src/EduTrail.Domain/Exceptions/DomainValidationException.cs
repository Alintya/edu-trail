namespace EduTrail.Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException() : base()
    {
    }

    public DomainValidationException(string message) : base(message)
    {
    }

    public DomainValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

