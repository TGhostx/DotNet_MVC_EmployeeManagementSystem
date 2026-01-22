using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Department;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Services;
using EMS.Domain.Models;

namespace EMS.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<DepartmentDto>> GetAllAsync()
        {
            var departments = await _work.Departments.GetAllAsync();

             return _mapper.Map<IReadOnlyList<DepartmentDto>>(departments);
        }

        public async Task<int> CreateAsync(CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);

            await _work.Departments.AddAsync(department);
            await _work.SaveChangesAsync();

            return department.Id;
        }

    }
}