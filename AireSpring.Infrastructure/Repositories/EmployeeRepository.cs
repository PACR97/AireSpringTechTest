using AireSpring.Application.Contracts;
using AireSpring.Domain;
using AireSpring.Domain.Dto;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace AireSpring.Infrastructure.Repositories;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly IConfiguration configuration;

    public EmployeeRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<int> AddAsync(Employee entity)
    {
        string query = @"
            INSERT INTO Employee
           (
            EmployeeId
           ,EmployeeLastName
           ,EmployeeFirstName
           ,EmployeePhone
           ,EmployeeZip
           ,HireDate
            )
            VALUES
            (
             @EmployeeId,
             @EmployeeLastName,
             @EmployeeFirstName,
             @EmployeePhone,
             @EmployeeZip,
             @HireDate
            )";

        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.ExecuteAsync(query, entity);
        await connection.CloseAsync();
        return result;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.ExecuteAsync(query, new { EmployeeId = id });
        await connection.CloseAsync();
        return result;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        string query = "SELECT * FROM Employee ORDER BY EmployeeFirstName";
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<Employee>(query);
        return result;
    }

    public async Task<Employee> GetByIdAsync(Guid id)
    {
        string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { EmployeeId  = id});
        return result;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(IFilterEmployee filterEmployee)
    {
        string query = @"
                        SELECT * FROM Employee 
                        WHERE (EmployeeLastName like @Filter) OR (EmployeePhone  like @Filter)
                        ORDER BY EmployeeFirstName";
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<Employee>(query, 
            new 
            {
                Filter = $"%{filterEmployee.PropertyFilter}%",
            });
        return result;
    }

    public async Task<Employee> UpdateAsync(Employee entity)
    {
        var query = @"
                    UPDATE Employee 
                    set EmployeeLastName = @EmployeeLastName,
                    EmployeeFirstName = @EmployeeFirstName,
                    EmployeePhone = @EmployeePhone,
                    EmployeeZip = @EmployeeZip
                    where EmployeeId = @EmployeeId
                    ";
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();
        var result = await connection.ExecuteAsync(query, entity);
        await connection.CloseAsync();
        return entity;
    }

    private SqlConnection CreateConnection()
    {
        var connString = configuration.GetConnectionString("DefaultConnection");
        if (connString is null)
            throw new NullReferenceException($"Connection string cannot be null");
        return new SqlConnection(connString);
    }
}
