using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Models;

namespace EMS.Application.Interfaces.Repositories
{
    public interface IAttendanceRepository: IGenericRepository<Attendance>
    {
        Task<IReadOnlyList<Attendance>> GetByEmployeeAsync(int employeeId);
    }
}