using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Interfaces.Repositories;
using EMS.Domain.Enums;
using EMS.Domain.Models;
using EMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(EmsDbContext context) : base(context) { }

        public async Task<IReadOnlyList<LeaveRequest>> GetPendingAsync()
        {
            return await _context.LeaveRequests.Where(l => l.Status == LeaveStatus.Pending).ToListAsync();
        }
    }
}