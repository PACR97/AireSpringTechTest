using AireSpring.Application.Common;
using AireSpring.Domain;
using AireSpring.Domain.Dto;

namespace AireSpring.Application.Features.Employees.Queries.GetEmployees
{
    /// <summary>
    /// Query to get a <see cref="IEnumerable{Employee}"/> filtered by <see cref="Employee.EmployeeLastName"/> or <see cref="Employee.EmployeePhone"/>
    /// </summary>
    public class GetEmployeesQuery : IQueryBase<IEnumerable<Employee>>
    {
        public GetEmployeesQuery(IFilterEmployee filter)
        {
            Filter = filter;
        }
        public IFilterEmployee Filter { get; set; }
    }
}
