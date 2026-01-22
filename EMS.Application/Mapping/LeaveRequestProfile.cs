using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.LeaveRequest;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class LeaveRequestProfile: Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateLeaveRequestDto, LeaveRequest>().ConstructUsing(dto => new LeaveRequest(dto.EmployeeId, dto.From, dto.To));
        }
    }
}