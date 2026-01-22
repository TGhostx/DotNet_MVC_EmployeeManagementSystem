using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Employees;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));

            CreateMap<CreateEmployeeDto, Employee>()
                .ConstructUsing(dto => new Employee(dto.FirstName, dto.LastName, dto.Email, dto.DateOfBirth, dto.HireDate, dto.DepartmentId, dto.JobId));
        }
    }
}