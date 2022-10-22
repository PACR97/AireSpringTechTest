using AireSpring.Application.Common;
using AireSpring.Domain;

namespace AireSpring.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// Query to get <see cref="Employee"/> by <see cref="Id"/>
/// </summary>
public sealed class GetEmployeeByIdQuery : IQueryBase<Employee>
{
    public Guid Id { get; set; }
}
