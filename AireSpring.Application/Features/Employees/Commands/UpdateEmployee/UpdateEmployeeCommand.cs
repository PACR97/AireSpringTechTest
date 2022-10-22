using AireSpring.Application.Common;
using AireSpring.Domain;

namespace AireSpring.Application.Features.Employees.Commands.UpdateEmployee;

/// <summary>
/// Command to update <see cref="Employee"/> with the required properties to update a <see cref="Employee"/>
/// </summary>
public sealed class UpdateEmployeeCommand : ICommandBase<Employee>
{
    public Guid EmployeeId { get; set; }
    public string? EmployeeLastName { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeePhone { get; set; }
    public string? EmployeeZip { get; set; }
}
