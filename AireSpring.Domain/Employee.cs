namespace AireSpring.Domain;

public sealed class Employee
{
    public Employee()
    {
        EmployeeId = Guid.NewGuid();
        HireDate = DateTimeOffset.Now.ToString("MM/dd/yyyy");
    }
    public Guid EmployeeId { get; set; }
    public string? EmployeeLastName { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeePhone { get; set; }
    public string? EmployeeZip { get; set; }
    public string? HireDate { get; set; }
}
