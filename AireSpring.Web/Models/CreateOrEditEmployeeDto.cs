using System.ComponentModel.DataAnnotations;

namespace AireSpring.Web.Models;

public class CreateOrEditEmployeeDto
{
    public Guid EmployeeId { get; set; }

    [Display(Name ="Last Name")]
    [Required]
    public string? EmployeeLastName { get; set; }

    [Display(Name = "First Name")]
    [Required]
    public string? EmployeeFirstName { get; set; }

    [Display(Name = "Phone")]
    [Required]
    public string? EmployeePhone { get; set; }

    [Display(Name = "Zip")]
    [Required]
    [MinLength(3)]
    [MaxLength(4)]
    public string? EmployeeZip { get; set; }
    public string? HireDate { get; set; }

    public bool IsNewEmployee() => EmployeeId == Guid.Empty;
}
