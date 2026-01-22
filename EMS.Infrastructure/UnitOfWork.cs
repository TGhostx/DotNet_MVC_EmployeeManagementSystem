using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Repositories;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories;

namespace EMS.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EmsDbContext _context;

        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        public IJobRepository Jobs { get; }
        public IAttendanceRepository Attendances { get; }
        public ILeaveRequestRepository LeaveRequests { get; }
        public IPayrollRepository Payrolls { get; }


        public UnitOfWork(EmsDbContext context)
        {
            _context = context;

            Employees = new EmployeeRepository(_context);
            Departments = new DepartmentRepository(_context);
            Jobs = new JobRepository(_context);
            Attendances = new AttendanceRepository(_context);
            LeaveRequests = new LeaveRequestRepository(_context);
            Payrolls = new PayrollRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}