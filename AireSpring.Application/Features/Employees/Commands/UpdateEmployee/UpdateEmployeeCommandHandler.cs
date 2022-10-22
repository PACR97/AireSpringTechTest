using AireSpring.Application.Contracts;
using AireSpring.Application.Exceptions;
using AireSpring.Domain;
using MediatR;

namespace AireSpring.Application.Features.Employees.Commands.UpdateEmployee;

/// <summary>
/// Implementation of command <see cref="UpdateEmployeeCommand"/>
/// </summary>
public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository repo;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repo.GetByIdAsync(request.EmployeeId);
        if (employee == null)
            throw new NotFoundException(nameof(employee), request.EmployeeId);

        employee.EmployeeFirstName = request.EmployeeFirstName;
        employee.EmployeeLastName = request.EmployeeLastName;
        employee.EmployeePhone = request.EmployeePhone;
        employee.EmployeeZip = request.EmployeeZip;
        
        employee = await repo.UpdateAsync(employee);
        return employee;
    }
}
