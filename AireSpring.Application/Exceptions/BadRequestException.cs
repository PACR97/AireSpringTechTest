namespace AireSpring.Application.Exceptions;

/// <summary>
/// Exception will be throwing when a request will be wrogn
/// </summary>
public class BadRequestException : ApplicationException
{
    public BadRequestException(string? message) : base(message)
    {
    }
}
