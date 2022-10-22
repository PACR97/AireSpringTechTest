namespace AireSpring.Application.Exceptions;

/// <summary>
/// Exception will be throwing when a Entity was not found
/// </summary>
public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key})  was not found")
    {
    }
}
