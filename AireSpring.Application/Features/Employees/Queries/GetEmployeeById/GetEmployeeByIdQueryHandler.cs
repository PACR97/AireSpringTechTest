using AireSpring.Application.Contracts;
using AireSpring.Application.Exceptions;
using AireSpring.Domain;
using MediatR;

namespace AireSpring.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// Implementation of query <see cref="GetEmployeeByIdQuery"/>
/// </summary>
public sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IEmployeeRepository repo;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await repo.GetByIdAsync(request.Id);
        if (employee == null)
            throw new NotFoundException(nameof(employee), request.Id);
        return employee;
    }
}
