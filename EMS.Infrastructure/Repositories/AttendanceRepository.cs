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
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(EmsDbContext context) : base(context) { }

        public async Task<IReadOnlyList<Attendance>> GetByEmployeeAsync(int employeeId)
        {
            return await _context.Attendances.Where(a => a.EmployeeId == employeeId).ToListAsync();
        }
    }
}