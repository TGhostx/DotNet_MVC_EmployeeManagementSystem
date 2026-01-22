using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Interfaces.Repositories;
using EMS.Domain.Models;
using EMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmsDbContext context) : base(context) { }

        public async Task<Department?> GetWithEmployeesAsync(int id)
        {
            return await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}