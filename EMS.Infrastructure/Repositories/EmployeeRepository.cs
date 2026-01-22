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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmsDbContext context) : base(context) { }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Employees.AnyAsync(e => e.Email == email);
        }

        public async Task<Employee?> GetEmployeeWithDetailsAsync(int id)
        {
            return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Job)
            .Include(e => e.Attendances)
            .Include(e => e.LeaveRequests)
            .Include(e => e.Payrolls)
            .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}