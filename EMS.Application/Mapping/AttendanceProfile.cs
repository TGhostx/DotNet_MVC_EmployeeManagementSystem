using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Attenance;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class AttendanceProfile: Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Attendance, AttendanceDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateAttendanceDto, Attendance>().ConstructUsing(dto => new Attendance(dto.EmployeeId, dto.Date));
        }
    }
}