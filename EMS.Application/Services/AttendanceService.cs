using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Attenance;
using EMS.Domain.Models;

namespace EMS.Application.Interfaces.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task RecordAsync(CreateAttendanceDto dto)
        {
            var attendance = _mapper.Map<Attendance>(dto);

            await _work.Attendances.AddAsync(attendance);
            await _work.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<AttendanceDto>> GetByEmployeeAsync(int employeeId)
        {
            var records = await _work.Attendances.GetByEmployeeAsync(employeeId);

            return _mapper.Map<IReadOnlyList<AttendanceDto>>(records);
        }
    }
}