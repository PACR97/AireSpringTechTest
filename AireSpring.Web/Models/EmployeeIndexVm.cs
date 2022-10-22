using AireSpring.Domain;
using AireSpring.Infrastructure.Dtos;

namespace AireSpring.Web.Models
{
    public class EmployeeIndexVm
    {
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public FilterEmployee? Filter { get; set; }
    }
}
