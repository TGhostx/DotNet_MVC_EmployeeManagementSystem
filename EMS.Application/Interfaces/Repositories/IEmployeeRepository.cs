using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Models;

namespace EMS.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        Task<Employee?> GetEmployeeWithDetailsAsync(int id); 
        Task<bool> EmailExistsAsync(string email);
    }
}