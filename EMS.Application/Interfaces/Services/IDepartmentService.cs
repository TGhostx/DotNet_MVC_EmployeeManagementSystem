using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Department;

namespace EMS.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IReadOnlyList<DepartmentDto>> GetAllAsync();
        Task<int> CreateAsync(CreateDepartmentDto dto);
    }
}