using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Models;

namespace EMS.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository: IGenericRepository<Department>
    {
        Task<Department?> GetWithEmployeesAsync(int id);
    }
}