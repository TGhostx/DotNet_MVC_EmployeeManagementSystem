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
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(EmsDbContext context) : base(context) { }

        public async Task<Payroll?> GetByPeriodAsync(int employeeId, int month, int year)
        {
            return await _context.Payrolls.FirstOrDefaultAsync(p => p.EmployeeId == employeeId && p.Month == month && p.Year == year);
        }
    }
}