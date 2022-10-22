using AireSpring.Domain;
using AireSpring.Domain.Dto;

namespace AireSpring.Application.Contracts;

/// <summary>
/// Interface of Employee repository to access the database with employee entity
/// </summary>
public interface IEmployeeRepository : IAsyncRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(IFilterEmployee filterEmployee);
}
