using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Employees;

namespace EMS.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task UpdateAsync(UpdateEmployeeDto dto);

        Task DeactivateAsync(int id);
    }
}