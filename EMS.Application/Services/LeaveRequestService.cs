using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.LeaveRequest;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Services;
using EMS.Domain.Models;

namespace EMS.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public LeaveRequestService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateLeaveRequestDto dto)
        {
            var request = _mapper.Map<LeaveRequest>(dto);

            await _work.LeaveRequests.AddAsync(request);
            await _work.SaveChangesAsync();

            return request.Id;
        }

        public async Task ApproveAsync(int id)
        {
            var request = await _work.LeaveRequests.GetByIdAsync(id) ?? throw new KeyNotFoundException("Leave request not found");

            request.Approve();
            await _work.SaveChangesAsync();
        }

        public async Task RejectAsync(int id)
        {
            var request = await _work.LeaveRequests.GetByIdAsync(id) ?? throw new KeyNotFoundException("Leave request not found");

            request.Reject();
            await _work.SaveChangesAsync();
        }
    }
}