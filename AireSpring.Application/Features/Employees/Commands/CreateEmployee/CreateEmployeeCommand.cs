using AireSpring.Application.Common;
using AireSpring.Domain;

namespace AireSpring.Application.Features.Employees.Commands.CreateEmployee;

/// <summary>
/// Command to create a new <see cref="Employee"/> that command contain all the properties required to create a new <see cref="Employee"/>
/// </summary>
public sealed class CreateEmployeeCommand : ICommandBase<Employee>
{
    public string? EmployeeLastName { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeePhone { get; set; }
    public string? EmployeeZip { get; set; }
}
