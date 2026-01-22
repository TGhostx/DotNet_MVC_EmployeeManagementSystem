using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Department;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));

            CreateMap<CreateDepartmentDto, Department>().ConstructUsing(dto => new Department(dto.Name, dto.Location));
        }
    }
}