using AireSpring.Application.Common;

namespace AireSpring.Application.Features.Employees.Commands.DeleteEmployee;

/// <summary>
/// Command definition with the required properties to remove a <see cref="Employee"/>
/// </summary>
public class DeleteEmployeeCommand : ICommandBase
{
    public DeleteEmployeeCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }}
