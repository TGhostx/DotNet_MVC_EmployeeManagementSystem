using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Employees;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Services;
using EMS.Domain.Models;

namespace EMS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeDto>> GetAllAsync()
        {
            var employees = await _work.Employees.GetAllAsync();

            return _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _work.Employees.GetEmployeeWithDetailsAsync(id);
            
            return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            if (await _work.Employees.EmailExistsAsync(dto.Email))
                throw new InvalidOperationException("Email already exists");
            
            var employee = _mapper.Map<Employee>(dto);

            await _work.Employees.AddAsync(employee);
            await _work.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(UpdateEmployeeDto dto)
        {
            var employee = await _work.Employees.GetByIdAsync(dto.Id) ?? throw new KeyNotFoundException("Employee not found");

            employee.UpdatePersonalInfo(dto.FirstName, dto.LastName);
            await _work.SaveChangesAsync();
        }

        public async Task DeactivateAsync(int id)
        {
            var employee = await _work.Employees.GetByIdAsync(id) ?? throw new KeyNotFoundException("Employee not found");

            employee.Deactivate();
            await _work.SaveChangesAsync();
        }
    }
}