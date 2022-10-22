using AireSpring.Application.Contracts;
using AireSpring.Domain;
using MediatR;

namespace AireSpring.Application.Features.Employees.Queries.GetEmployees;

/// <summary>
/// Implementation of query <see cref="GetEmployeesQuery"/>
/// </summary>
public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository repo;

    public GetEmployeesQueryHandler(IEmployeeRepository repo)
    {
        this.repo = repo;
    }

    public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetEmployeesAsync(request.Filter);
    }
}
