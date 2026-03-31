using EmployeeService.Domain;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task AddAsync(Employee employee);
}