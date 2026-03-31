using EmployeeService.Application.Interfaces;
using EmployeeService.Domain;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        await _repository.AddAsync(employee);
    }
}