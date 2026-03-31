using EmployeeService.Application.Interfaces;
using EmployeeService.Domain;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Infrastructure.Repositories;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private static readonly List<Employee> _employees = new();

    public Task<List<Employee>> GetAllAsync()
    {
        return Task.FromResult(_employees);
    }

    public Task AddAsync(Employee employee)
    {
        employee.Id = _employees.Count + 1;
        _employees.Add(employee);
        return Task.CompletedTask;
    }
}