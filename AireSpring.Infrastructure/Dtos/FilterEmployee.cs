using AireSpring.Domain.Dto;

namespace AireSpring.Infrastructure.Dtos;

/// <summary>
/// Dto to use to filter employees by <see cref="FirstName"/> and <see cref="LastName"/>
/// </summary>
public sealed class FilterEmployee : IFilterEmployee
{
    public string? PropertyFilter { get; set; }
}
