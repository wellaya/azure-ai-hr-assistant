using EmployeeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();

        Task AddAsync(Employee employee);
    }
}
