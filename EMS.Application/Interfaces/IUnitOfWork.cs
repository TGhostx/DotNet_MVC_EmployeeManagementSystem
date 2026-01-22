using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Interfaces.Repositories;

namespace EMS.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IJobRepository Jobs { get; }
        IAttendanceRepository Attendances { get; }
        ILeaveRequestRepository LeaveRequests { get; }
        IPayrollRepository Payrolls { get; }

        Task<int> SaveChangesAsync();
    }
}