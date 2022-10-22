using AireSpring.Application.Contracts;
using AireSpring.Application.Exceptions;
using AireSpring.Domain;
using MediatR;

namespace AireSpring.Application.Features.Employees.Commands.CreateEmployee;

/// <summary>
/// Implementation of command <see cref="CreateEmployeeCommand"/>
/// </summary>
public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository repo;

    public CreateEmployeeCommandHandler(IEmployeeRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = new Employee()
        {
            EmployeeFirstName = request.EmployeeFirstName,
            EmployeeLastName = request.EmployeeLastName,
            EmployeePhone = request.EmployeePhone,
            EmployeeZip = request.EmployeeZip
        };
        var result = await repo.AddAsync(newEmployee);
        if (result == 0)
            throw new BadRequestException($"Could not be added the Employee {request.EmployeeFirstName} {request.EmployeeLastName}");
        return newEmployee;
    }
}
