using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Attenance;

namespace EMS.Application.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task RecordAsync(CreateAttendanceDto dto);
        Task<IReadOnlyList<AttendanceDto>> GetByEmployeeAsync(int employeeId);
    }
}