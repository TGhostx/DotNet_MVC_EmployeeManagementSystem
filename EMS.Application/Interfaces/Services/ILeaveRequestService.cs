using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.LeaveRequest;

namespace EMS.Application.Interfaces.Services
{
    public interface ILeaveRequestService
    {
        Task<int> CreateAsync(CreateLeaveRequestDto dto);
        Task ApproveAsync(int id);
        Task RejectAsync(int id);
    }
}